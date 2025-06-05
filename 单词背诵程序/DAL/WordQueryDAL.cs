using System.Collections.Generic;
using IBLLBridgeDAL;

namespace DAL
{
    public class WordQueryDAL : IWordQuery
    {
        public List<IWord> FindWordsByEnglish(string input)
        {
            var list = new List<IWord>();
            foreach (Formid formid in Enum.GetValues(typeof(Formid)))
            {
                var results = WordMover.FindWordsByEnglish(input, formid);
                if (results.Count == 1 && results[0].Equals(input, StringComparison.OrdinalIgnoreCase))
                    break;
                foreach (var word in results)
                {
                    list.Add(new Word(word, formid));
                }
                // 如果当前表有精确匹配，WordMover会直接返回单个结果，这里直接break即可
                
            }
            // 去重
            return list.GroupBy(w => w.word).Select(g => g.First()).ToList();
        }

        public List<IWord> FindWordsByChinese(string input)
        {
            var list = new List<IWord>();
            foreach (Formid formid in Enum.GetValues(typeof(Formid)))
            {
                var results = WordMover.FindWordsByChinese(input, formid);
                if (results.Count == 1)
                    break;
                foreach (var word in results)
                {
                    list.Add(new Word(word, formid));
                }
                // 如果当前表有精确匹配，WordMover会直接返回单个结果，这里直接break即可
                
            }
            // 去重
            return list.GroupBy(w => w.word).Select(g => g.First()).ToList();
        }
    }
}