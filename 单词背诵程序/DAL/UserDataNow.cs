using IBLLBridgeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDataNow : IUserInputDeliver
    {
        internal static Formid userDictionarySelect = Formid.CET4;

        internal static string? NowUser;
        /// <summary>
        /// 让程序定位到指定的词典<br/>
        /// 传递到DAL层词典信息，用于linq查询定位词库
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
    }
}
