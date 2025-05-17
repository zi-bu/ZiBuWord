using IBLLBridgeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    using IBLLBridgeDAL;
    using IBLLBridgeDAL.WordOperation;

    
        public class SearchWordEnglish
        {
        private readonly IWordManagement _wordManagement;

        public SearchWordEnglish(IWordManagement wordManagement)
        {
            _wordManagement = wordManagement;
        }

        /// <summary>
        /// 粗查找：返回所有包含输入字符串的单词
        /// </summary>
        public List<IWord> FuzzySearch(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return new List<IWord>();
            //防止无效输入

            var allWords = _wordManagement.GetAllWords();
            return allWords
                .Where(w => w.word.Contains(input, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

    }
    
}
