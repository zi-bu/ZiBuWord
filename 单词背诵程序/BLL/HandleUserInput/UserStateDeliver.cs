using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLLBridgeDAL;
using DAL;
namespace BLL.HandleUserInput
{
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
            if(wordform == null || wordform == "") 
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
        public static bool RememberUser (string? user)
        {
            Deliverymen.RememberUser(user);
            return true;
        }
        /// <summary>
        /// 使程序单词进度与对应用户的数据库里的进度同步<br/>
        /// 使用地点：选择表时触发一下；中断背诵触发。
        /// </summary>
        public static bool ProgressSync() 
        {
            Deliverymen.ProgressSync();
            return true;
        }
    }
}
