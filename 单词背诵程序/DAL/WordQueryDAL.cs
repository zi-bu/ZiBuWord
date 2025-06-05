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
                // �����ǰ���о�ȷƥ�䣬WordMover��ֱ�ӷ��ص������������ֱ��break����
                
            }
            // ȥ��
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
                // �����ǰ���о�ȷƥ�䣬WordMover��ֱ�ӷ��ص������������ֱ��break����
                
            }
            // ȥ��
            return list.GroupBy(w => w.word).Select(g => g.First()).ToList();
        }
    }
}