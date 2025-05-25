using System.Collections.Generic;
using IBLLBridgeDAL;


namespace DAL
    {
        public class WordQueryDAL : IWordQuery
        {
        public List<IWord> FindWordsByEnglish(string input)
        {
            foreach (Formid formid in Enum.GetValues(typeof(Formid)))
            {
                var results = WordMover.FindWordsByEnglish(input, formid);
                // 如果当前表有精确匹配（即只返回一个且等于输入），直接返回
                if (results.Count == 1 && results[0].Equals(input, StringComparison.OrdinalIgnoreCase))
                {
                    return new List<IWord> { new Word(results[0], formid) };
                }
            }
            // 没有精确匹配，合并所有表的模糊结果
            var list = new List<IWord>();
            foreach (Formid formid in Enum.GetValues(typeof(Formid)))
            {
                var results = WordMover.FindWordsByEnglish(input, formid);
                foreach (var word in results)
                {
                    list.Add(new Word(word, formid));
                }
            }
            // 去重
            return list.GroupBy(w => w.word).Select(g => g.First()).ToList();
        }

        public List<IWord> FindWordsByChinese(string input)
        {
            foreach (Formid formid in Enum.GetValues(typeof(Formid)))
            {
                var results = WordMover.FindWordsByChinese(input, formid);
                // 如果当前表有精确匹配（即只返回一个且等于输入），直接返回
                if (results.Count == 1 && results[0].Equals(input, StringComparison.OrdinalIgnoreCase))
                {
                    return new List<IWord> { new Word(results[0], formid) };
                }
            }
            // 没有精确匹配，合并所有表的模糊结果
            var list = new List<IWord>();
            foreach (Formid formid in Enum.GetValues(typeof(Formid)))
            {
                var results = WordMover.FindWordsByChinese(input, formid);
                foreach (var word in results)
                {
                    list.Add(new Word(word, formid));
                }
            }
            // 去重
            return list.GroupBy(w => w.word).Select(g => g.First()).ToList();
        }
    }
    }