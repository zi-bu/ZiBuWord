using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 数据库表的模型类的接口。(一个模版的模板)
    /// 这个类对应数据库中的表的结构，包含单词、释义和短语等字段。<br/>
    /// 因为一个实体类只能映射一个数据库表
    /// </summary>
    public class WordDictionary
    {
        [Key] // 主键
        public int Number { get; set; } // 单词编号
        [Required] // 必填字段
        public string? Word { get; set; } // 单词
        public string? Translations { get; set; } // 释义
        public string? Phrases { get; set; } // 短语
    }

    public class CET4 : WordDictionary { }
    public class CET6 : WordDictionary { }
    public class 初中 : WordDictionary { }
    public class 高中 : WordDictionary { }
    public class 考研 : WordDictionary { }
    public class 托福 : WordDictionary { }

    /// <summary>
    /// 用户表的模型类。<br/>
    /// 这个类对应数据库中的用户表的结构，包含用户编号、用户名和密码等字段。<br/>
    /// 这个类用于存储用户的基本信息。<br/>
    /// 由***子布***创建。<br/>
    /// </summary>
    public class User
    {

        [Key] // 主键
        public int UserID { get; set; } // 用户编号
        [Required] // 必填字段
        public string? Username { get; set; } // 用户名
        public string? UserPassword { get; set; } // 密码
    }
}
