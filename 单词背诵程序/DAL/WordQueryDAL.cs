using System.Collections.Generic;
using IBLLBridgeDAL;

namespace DAL
{
    public class WordQueryDAL : IWordQuery
    {
        //实现查询接口
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
    }
}