using DAL;
using DAL.ReturnFunction;

namespace BLL;

/// <summary>
///     收藏单词业务逻辑层
/// </summary>
public class FavoriteWordService
{
    //DAL层对象，只读属性保证始终指向同一个对象，用于后续调用方法
    private readonly FavoriteWordsManagement _dal = new();
    private readonly FavoriteWordDetailQueryDAL _detailDal = new();

    /// <summary>
    /// 获取当前用户ID
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    private int GetCurrentUserId()
    {
        string? username = BLL.HandleUserInput.UserStateDeliver.GetCurrentUser();
        if (string.IsNullOrEmpty(username))
            throw new InvalidOperationException("当前未登录用户");
        return DAL.UserDataMover.GetUserId(username);
    }

    /// <summary>
    /// 获取当前用户的所有收藏单词详情
    /// </summary>
    /// <returns></returns>
    public List<FavoriteWordDetail> GetCurrentUserFavorites()
    {
        int userId = GetCurrentUserId();
        return GetFavoriteDetails(userId);
    }

    /// <summary>
    /// 添加收藏
    /// </summary>
    public void AddFavorite(string word, string dictType)
    {
        int userId = GetCurrentUserId();
        int wordId = GetWordId(word, dictType);
        _dal.AddFavorite(userId, wordId, dictType);
    }

    /// <summary>
    /// 移除收藏
    /// </summary>
    public void RemoveFavorite(int wordId, string dictType)
    {
        int userId = GetCurrentUserId();
        if (string.IsNullOrEmpty(dictType))
            throw new ArgumentNullException(nameof(dictType), "词典类型不能为空");
        _dal.RemoveFavorite(userId, wordId, dictType);
    }

    /// <summary>
    /// 获取用户所有收藏
    /// </summary>
    /// <param name="userId">用户ID</param>
    public List<FavoriteWordDetail> GetFavoriteDetails(int userId)
    {
        var favorites = _dal.GetFavorites(userId); // 获取用户的收藏列表
        var result = new List<FavoriteWordDetail>(); // 创建一个列表来存储结果
        foreach (var fav in favorites) // 遍历每个收藏
        {
            // 获取单词原文、词性和释义
            var (word, posList, translationsList) = _detailDal.GetWordDetail(fav.DictionaryType, fav.WordId);
            // 把词性和释义拼接成字符串
            var translation = string.Join("; ", translationsList.Zip(posList, (tran, p) => $"{p}. {tran}"));
            result.Add(new FavoriteWordDetail // 组装成 FavoriteWordDetail 对象后添加到列表
            {
                Id = fav.Id, // 收藏ID
                DictionaryType = fav.DictionaryType, // 词典类型
                WordId = fav.WordId, // 单词ID
                Word = word, // 单词原文
                Translation = translation // 词性+释义
            });
        }
        return result; // 返回结果列表
    }
    /// <summary>
    /// 获取单词ID
    /// </summary>
    /// <param name="word">单词</param>
    /// <param name="dictType">词典类型</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public int GetWordId(string word, string dictType)
    {
        if (!Enum.TryParse<Formid>(dictType, out var formid))
            throw new ArgumentException("未知词典类型", nameof(dictType));
        return WordMover.GetWordId(word, formid);
    }
}

public class FavoriteWordDetail
{
    public int Id { get; set; }
    public string? DictionaryType { get; init; }
    public int WordId { get; init; }
    public string? Word { get; set; }
    public string? Translation { get; set; }
}


