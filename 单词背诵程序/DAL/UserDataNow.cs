using IBLLBridgeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 暂存用户的状态信息。
    /// </summary>
    public class UserDataNow:IUserStateDeliver
    {
        internal static Formid userDictionarySelect;

        internal static string? NowUser;

        internal static int Progress = 0;//索引


        /// <summary>
        /// 让程序定位到用户指定的词典<br/>
        /// 传递到DAL层词典信息，用于linq查询定位词库<br/>
        /// 同时提取出背诵进度
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public void SelectDictionary(string word)
        {
            try
            {
                Enum.TryParse(word, out userDictionarySelect);
            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// 让程序记住现在是哪个用户<br/>
        /// 传递到DAL层用户名信息，用于linq查询定位用户数据<br/>
        /// 若输入null，则等于退出登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public void RememberUser(string? user)
        {
            try
            {
                NowUser = user;
            }
            catch
            {
                throw;
            }  
        }


        /// <summary>
        /// 使程序单词进度与对应用户的数据库里的进度同步<br/>
        /// 传递到DAL层更新指示<br/>
        /// 使用地点：选择表时触发一下；中断背诵触发。
        /// </summary>
        public void ProgressSync()
        {
            if (NowUser == null) return;
            Progress = UserDataMover.GetFormProgress(NowUser, userDictionarySelect);
        }
        /// <summary>
        /// 更新用户的进度<br/>
        /// 参数为进度增加值，可以为负数
        /// </summary>
        /// <param name="upprogress"></param>
        public void UpdateProgress(int upprogress)
        {
            if (NowUser == null) return;
            UserDataMover.UpdateFormProgress(NowUser, userDictionarySelect, upprogress);
        }

    }
}
