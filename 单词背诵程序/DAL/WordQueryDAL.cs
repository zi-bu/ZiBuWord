using System.Collections.Generic;
using IBLLBridgeDAL;

namespace DAL
{
    public class WordQueryDAL : IWordQuery
    {
        //ʵ�ֲ�ѯ�ӿ�
        //����Ӣ�Ĳ��ҵ���
        public IWord? FindExactWordByEnglish(string input)
        {
            foreach (Formid formid in Enum.GetValues(typeof(Formid)))   //�������еĵ��ʱ�
            {
                var result = WordMover.FindExactWordByEnglish(input, formid); //���Ҿ�ȷƥ��ĵ���
                if (!string.IsNullOrEmpty(result)) //����ҵ������ظõ���
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
            //���ڲ�ͬ���ʱ��������ͬ�ĵ��ʣ������� GroupBy ���������ݷ��飬ֻȡÿ��ĵ�һ����ʵ��ȥ��
        }



        //�������Ĳ��ҵ���
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
                var results = WordMover.FindFuzzyWordsByChinese(chinese, formid); // �����е���
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