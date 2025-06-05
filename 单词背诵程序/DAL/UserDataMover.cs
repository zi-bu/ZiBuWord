using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 封装了对用户数据的获取方法和更新方法
    /// </summary>
    public static class UserDataMover
    {
        /// <summary>
        /// 获取某用户对应某表的背诵进度<br/>
        /// </summary>
        /// <param name="user"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int GetFormProgress(string user,Formid id)
        {
            using (var db = new UserContext())
            {
                var userData = db.UserData.Include(f => f.UserWord)
                               .Where(f => f.UserName == user)
                               .Select(f => EF.Property<int>(f.UserWord!, id.ToString()))
                               .First();
                return userData;
            }
        }
        /// <summary>
        /// 更新某用户对应某表的背诵进度<br/>
        /// 第三个参数为增量，可以为负数<br/>
        /// </summary>
        /// <param name="user"></param>
        /// <param name="id"></param>
        /// <param name="upprogress"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void UpdateFormProgress(string user, Formid id, int upprogress)
        {
            using (var db = new UserContext())
            {
                var userData = db.UserData.Include(f => f.UserWord)
                               .Where(f => f.UserName == user)
                               .Select(f => f.UserWord)
                               .First();
                if (userData == null) { throw new ArgumentException("用户不存在"); }
                switch (id)
                {
                    case Formid.CET4:
                        userData.CET4 += upprogress;
                        break;
                    case Formid.CET6:
                        userData.CET6 += upprogress;
                        break;
                    case Formid.HighSchool:
                        userData.HighSchool += upprogress;
                        break;
                    case Formid.MiddleSchool:
                        userData.MiddleSchool += upprogress;
                        break;
                    case Formid.KY:
                        userData.KY += upprogress;
                        
                        break;
                    case Formid.TF:
                        userData.TF += upprogress;
                        break;
                }
                db.SaveChanges();
            }
        }
        /// <summary>
        /// 获取某用户的ID<br/>
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int GetUserId(string user)
        {
            using (var db = new UserContext())
            {
                var userId = db.UserData.First(f => f.UserName == user).UserID;
                return userId;
            }
        }

    }
}
