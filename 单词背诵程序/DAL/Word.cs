using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 单词对象的接口定义，规范单词对象的字段和访问方式。
    /// </summary>
    public interface IWord
    {
        string word { get; } // 单词
        string pos { get; } // 词性 (Part of Speech)
        string translation { get; } // 释义
        string phrase { get; } // 短语

        // 索引器：通过下标访问单词的不同属性。
        string this[int index] { get; }
    }


    /// <summary>
    /// 属性：word、pos、translation、phrase,tableid(单词表编号);<br/>
    /// 索引器：0-3 返回 word、pos、translation、phrase;<br/>
    /// 构造函数：输入formid枚举对应int值,即可获得指定单词表的随机单词;<br/>
    /// 实现 IWord 接口的类，用于封装单词对象;<br/>
    /// 施工人员：mouse;
    /// </summary>
    public class Word : IWord
    {
        public string word { get; set; } // 单词
        public string pos { get; set; } // 词性
        public string translation { get; set; } // 释义
        public string phrase { get; set; } // 短语

        private formid tableid; // 单词来源的枚举编号。

        /// <summary>
        /// 构造函数：通过枚举编号指定单词来源;
        /// </summary>
        public Word(int id)
        {
            tableid = (formid)id;
        }

        public Word()//空构造函数 用于BLL层测试
        {
            
        }

        /// <summary>
        /// 索引器：通过下标访问单词的不同属性;<br/>
        /// 例如：0 返回 word，1 返回 pos，依此类推;
        /// </summary>
        public string this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return word;
                    case 1:
                        return pos;
                    case 2:
                        return translation;
                    case 3:
                        return phrase;
                    default:
                        return null; // 如果下标无效，返回 null;
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        word = value;
                        break;
                    case 1:
                        pos = value;
                        break;
                    case 2:
                        translation = value;
                        break;
                    case 3:
                        phrase = value;
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
