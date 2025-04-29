using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 枚举类型，用于表示单词表的编号。<br/>
    /// 例如：考研 表示四级单词表，CET6 表示六级单词表。
    /// </summary>
    public enum formid
    {
        CET4 = 1,
        CET6 = 2,
        初中 = 3,
        高中 = 4,
        考研 = 5,
        托福 = 6,
    }
    /// <summary>
    /// 本类施工人员：mouse。<br/>
    /// mouse:单词搬运工类，计划封装查询单词和获取单词的方法（目前未完全实现）。<br/>
    /// mouse:新增了一个GetWords方法，用于随机获取一个单词。
    /// </summary>
    public static class Wordmover
    {
        static Random rd = new Random();// 随机数生成器实例。
        /// <summary>
        /// 参数：一个formid枚举值，用于指定单词来源表。<br/>
        /// 返回值：一个随机单词的字符串。<br/>
        /// 功能：随机获取一个单词，来源于指定单词来源表。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetWords(formid id)//随机获取一个单词
        {

            var db = new SqlDataContext();
            switch (id)
            {
                case formid.CET4:
                    {
                        int count = rd.Next(0, db.CET4.Count() - 1);
                        var word = db.CET4.ElementAt(count);
                        return word.word;
                    }
                case formid.CET6:
                    {
                        int count = rd.Next(0, db.CET6.Count() - 1);
                        var word = db.CET6.ElementAt(count);
                        return word.word;
                    }
                case formid.初中:
                    {
                        int count = rd.Next(0, db.初中.Count() - 1);
                        var word = db.初中.ElementAt(count);
                        return word.word;
                    }

                case formid.高中:
                    {
                        int count = rd.Next(0, db.高中.Count() - 1);
                        var word = db.高中.ElementAt(count);
                        return word.word;
                    }
                case formid.考研:
                    {
                        int count = rd.Next(0, db.考研.Count() - 1);
                        var word = db.考研.ElementAt(count);
                        return word.word;
                    }
                case formid.托福:
                    {
                        int count = rd.Next(0, db.托福.Count() - 1);
                        var word = db.托福.ElementAt(count);
                        return word.word;
                    }
                default:
                    return null;
            }
        }
    }
}
