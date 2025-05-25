using System.Collections.Generic;

namespace IBLLBridgeDAL
{
    //ר�����ڵ��ʲ�ѯ�Ľӿ�
    public interface IWordQuery
    {
        IWord? FindExactWordByEnglish(string input);
        List<IWord> FindFuzzyWordsByEnglish(string input);

        IWord? FindExactWordByChinese(string chinese);
        List<IWord> FindFuzzyWordsByChinese(string chinese);
    }
}