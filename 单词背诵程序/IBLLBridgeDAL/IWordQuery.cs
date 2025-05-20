using System.Collections.Generic;

namespace IBLLBridgeDAL
{
    //ר�����ڵ��ʲ�ѯ�Ľӿ�
    public interface IWordQuery
    {
        IWord? FindExactWord(string input);
        List<IWord> FindFuzzyWords(string input);
    }
}