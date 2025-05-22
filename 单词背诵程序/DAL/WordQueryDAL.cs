using System.Collections.Generic;
using IBLLBridgeDAL;

namespace DAL
{
    public class WordQueryDAL : IWordQuery
    {
        //实现查询接口
        //根据英文查找单词
        public IWord? FindExactWord(string input)
        {
            foreach (Formid formid in Enum.GetValues(typeof(Formid)))
            {
                var result = WordMover.FindExactWord(input, formid);
                if (!string.IsNullOrEmpty(result))
                {
                    
                    return new Word(result, formid); 
                }
            }
            return null;
        }

        public List<IWord> FindFuzzyWords(string input)
        {
            var list = new List<IWord>();
            foreach (Formid formid in Enum.GetValues(typeof(Formid)))
            {
                var results = WordMover.FindFuzzyWords(input, formid);
                foreach (var word in results)
                {
                    list.Add(new Word(word, formid)); 
                }
            }
            
            return list.GroupBy(w => w.word).Select(g => g.First()).ToList();
        }



        //根据中文查找单词
        public IWord? FindExactWordByChinese(string chinese)
        {
            foreach (Formid formid in Enum.GetValues(typeof(Formid)))
            {
                var result = WordMover.FindExactWordByChinese(chinese, formid);
                if (!string.IsNullOrEmpty(result))
                {

                    return new Word(result, formid);
                }
            }
            return null;
        }

        public List<IWord> FindFuzzyWordsByChinese(string chinese)
        {
            var list = new List<IWord>();
            foreach (Formid formid in Enum.GetValues(typeof(Formid)))
            {
                var results = WordMover.FindFuzzyWordsByChinese(chinese, formid); // 查所有单词
                foreach (var word in results)
                {
                    var w = new Word(word, formid);
                    if (w.translations.Any(t => t.Contains(chinese)))
                        list.Add(w);
                }
            }
            return list.GroupBy(w => w.word).Select(g => g.First()).ToList();
        }
    }
}