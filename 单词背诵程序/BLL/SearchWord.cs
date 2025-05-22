using IBLLBridgeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    using DAL;
    using IBLLBridgeDAL;
    using IBLLBridgeDAL.WordOperation;


    public class SearchWordEnglish
    {
        /// <summary>
        /// 查询指定表，先精确查找，找不到再模糊查找
        /// </summary>
        /// <summary>
        /// 在所有表中查找，优先精确匹配，否则合并所有表的模糊匹配
        /// </summary>
            private readonly IWordQuery _wordQuery;

            public SearchWordEnglish(IWordQuery wordQuery)
            {
                _wordQuery = wordQuery;
            }
        /// <summary>
        //调用_wordQuery接口的FindExactWord方法查找单词
        //如果找到，返回该单词的列表，否则调用FindFuzzyWords方法查找模糊匹配的单词列表
        //如果输入为空，返回空列表
        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns> 

        public List<IWord> SearchEnglish(string input)
            {
                if (string.IsNullOrWhiteSpace(input))
                    return new List<IWord>();
        //检查输入字符串 input 是否为空或仅包含空白字符如果是，则返回一个空的 IWord 列表

                var exact = _wordQuery.FindExactWordByEnglish(input);
                if (exact != null)
                    return new List<IWord> { exact };

                return _wordQuery.FindFuzzyWordsByEnglish(input);
            }
            
        }
    public class SearchWordChinese
    {
        private readonly IWordQuery _wordQuery;
        public SearchWordChinese(IWordQuery wordQuery)
        {
            _wordQuery = wordQuery;
        }
        public List<IWord> SearchChinese(string chinese)
        {
            if (string.IsNullOrWhiteSpace(chinese))
                return new List<IWord>();

            var exact = _wordQuery.FindExactWordByChinese(chinese);
            if (exact != null)
                return new List<IWord> { exact };

            return _wordQuery.FindFuzzyWordsByChinese(chinese);
        }
    }
    }
    
