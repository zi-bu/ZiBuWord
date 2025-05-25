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
                // �����ǰ���о�ȷƥ�䣨��ֻ����һ���ҵ������룩��ֱ�ӷ���
                if (results.Count == 1 && results[0].Equals(input, StringComparison.OrdinalIgnoreCase))
                {
                    return new List<IWord> { new Word(results[0], formid) };
                }
            }
            // û�о�ȷƥ�䣬�ϲ����б��ģ�����
            var list = new List<IWord>();
            foreach (Formid formid in Enum.GetValues(typeof(Formid)))
            {
                var results = WordMover.FindWordsByEnglish(input, formid);
                foreach (var word in results)
                {
                    list.Add(new Word(word, formid));
                }
            }
            // ȥ��
            return list.GroupBy(w => w.word).Select(g => g.First()).ToList();
        }

        public List<IWord> FindWordsByChinese(string input)
        {
            foreach (Formid formid in Enum.GetValues(typeof(Formid)))
            {
                var results = WordMover.FindWordsByChinese(input, formid);
                // �����ǰ���о�ȷƥ�䣨��ֻ����һ���ҵ������룩��ֱ�ӷ���
                if (results.Count == 1 && results[0].Equals(input, StringComparison.OrdinalIgnoreCase))
                {
                    return new List<IWord> { new Word(results[0], formid) };
                }
            }
            // û�о�ȷƥ�䣬�ϲ����б��ģ�����
            var list = new List<IWord>();
            foreach (Formid formid in Enum.GetValues(typeof(Formid)))
            {
                var results = WordMover.FindWordsByChinese(input, formid);
                foreach (var word in results)
                {
                    list.Add(new Word(word, formid));
                }
            }
            // ȥ��
            return list.GroupBy(w => w.word).Select(g => g.First()).ToList();
        }
    }
    }