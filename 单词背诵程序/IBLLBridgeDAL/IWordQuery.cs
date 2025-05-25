using System.Collections.Generic;

namespace IBLLBridgeDAL
{
    //ר�����ڵ��ʲ�ѯ�Ľӿ�
    public interface IWordQuery
    {
        List<IWord> FindWordsByEnglish(string input);
        List<IWord> FindWordsByChinese(string chinese);
    }
}