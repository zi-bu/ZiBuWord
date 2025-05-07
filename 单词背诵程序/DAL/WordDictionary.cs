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
    public  class WordDictionary
    {
        [Key] // 主键
        public int number { get; set; } // 单词编号
        [Required] // 必填字段
        public string? word { get; set; } // 单词
        public string? translations { get; set; } // 释义
        public string? phrases { get; set; } // 短语
    }

    public class CET4 : WordDictionary { }
    public class CET6 : WordDictionary { }
    public class 初中 : WordDictionary { }
    public class 高中 : WordDictionary { }
    public class 考研 : WordDictionary { }
    public class 托福 : WordDictionary { }
}
