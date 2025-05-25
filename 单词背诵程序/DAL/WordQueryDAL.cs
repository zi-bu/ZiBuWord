using System.Collections.Generic;
using IBLLBridgeDAL;

namespace DAL
{
    public class WordQueryDAL : IWordQuery
    {
        //实现查询接口
        //根据英文查找单词
        public IWord? FindExactWordByEnglish(string input)
        {
            foreach (Formid formid in Enum.GetValues(typeof(Formid)))   //遍历所有的单词表
            {
                var result = WordMover.FindExactWordByEnglish(input, formid); //查找精确匹配的单词
                if (!string.IsNullOrEmpty(result)) //如果找到，返回该单词
                {
                    return new Word(result, formid); 
                }
            }
            return null;
        }

        public List<IWord> FindFuzzyWordsByEnglish(string input)
        {
            var list = new List<IWord>();
            foreach (Formid formid in Enum.GetValues(typeof(Formid)))
            {
                var results = WordMover.FindFuzzyWordsByEnglish(input, formid);
                foreach (var word in results)
                {
                    list.Add(new Word(word, formid)); 
                }
            }
            
            return list.GroupBy(w => w.word).Select(g => g.First()).ToList();
            //由于不同单词表可能有相同的单词，这里用 GroupBy 按单词内容分组，只取每组的第一个，实现去重
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