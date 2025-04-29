using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 数据库表的模型类。(一个模版)
    /// 这个类对应数据库中的表的结构，包含单词、释义和短语等字段。<br/>
    /// 这个类是由```子布```书写完成的，不要感谢他的贡献。
    /// mouse:干得漂亮。
    /// </summary>
    public class dictionary
    {
        [Key] // 主键
        public int number { get; set; } // 单词编号
        [Required] // 必填字段
        public string? word { get; set; } // 单词
        public string? translations { get; set; } // 释义
        public string? phrases { get; set; } // 短语
    }
}
