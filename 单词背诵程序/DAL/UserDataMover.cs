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
    }
}
