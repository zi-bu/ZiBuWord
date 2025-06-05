using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLLBridgeDAL;
using DAL;
namespace BLL.HandleUserInput
{
    /// <summary>
    /// 该类本质上是DAL的UserDataNow的搬运，外加一点点安全检验
    /// </summary>
    public static class UserStateDeliver
    {
        static IUserStateDeliver Deliverymen = new UserDataNow();
        /// <summary>
        /// 让程序定位到指定的词典<br/>
        /// 传递到DAL层词典信息，用于linq查询定位词库
        /// </summary>
        /// <param name="wordform"></param>
        /// <returns></returns>
        public static bool DeliverDictionarySelect(string wordform)
        {
            if (wordform == null || wordform == "")
            {
                return false;
                throw new ArgumentException("word is null or empty");
            }
            Deliverymen.SelectDictionary(wordform);
            return true;
        }
        /// <summary>
        /// 让程序记住现在是哪个用户<br/>
        /// 传递到DAL层用户名信息，用于linq查询定位用户数据<br/>
        /// 若输入null，相当于退出登录
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool RememberUser(string? user)
        {
            if (user == null) return false;
            Deliverymen.RememberUser(user);
            return true;
        }
        /// <summary>
        /// 使程序单词进度与对应用户的数据库里的进度同步<br/>
        /// 使用地点：选择表时触发一下获取进度；每次背诵前触发一下，避免中断背诵导致进度不准确。
        /// </summary>
        public static bool ProgressSync()
        {
            Deliverymen.ProgressSync();
            return true;
        }
        /// <summary>
        /// 更新用户的进度<br/>
        /// 参数为进度增加值，可以为负数
        /// </summary>
        /// <param name="upprogress"></param>
        public static bool UpdateProgress(int upprogress)
        {
            Deliverymen.UpdateProgress(upprogress);
            return true;
        }
        /// <summary>
        /// 获取当前用户ID<br/>
        /// </summary>
        /// <returns></returns>
        public static string? GetCurrentUser()
        {
            return ((DAL.UserDataNow)Deliverymen).GetNowUser();
        }
        /// <summary>
        /// 获取当前词典类型（如"CET4"、"CET6"等）
        /// </summary>
        public static string GetCurrentDictType()
        {
            return ((DAL.UserDataNow)Deliverymen).GetCurrentDictType();
        }
    }
}
