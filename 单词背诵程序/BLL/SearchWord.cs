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
        //单词集合 依赖注入
        public SearchWordEnglish(IWordQuery wordQuery)
        {
            _wordQuery = wordQuery;
        }

        //模糊查找 输入单词的部分
        public List<IWord> FuzzySearch(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return new List<IWord>();

            var exact = _wordQuery.FindExactWord(input);
            if (exact != null)
                return new List<IWord> { exact };

            return _wordQuery.FindFuzzyWords(input);
        }//返回一个模糊查找搜索的列表（可是这个列表并不是动态的）
        //原则上是每当搜索栏的内容更新了一次就会调用一次这个方法

    }
    //单词查找中文意思？
    public class SearchWordChinese
    {
        private readonly IWordQuery _wordQuery;
        public SearchWordChinese(IWordQuery wordQuery)
        {
            _wordQuery = wordQuery;
        }
        public List<IWord> FuzzySearchChinese(string chinese)
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

