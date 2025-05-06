namespace IUIBridgeBLL;

public interface IReciterTf : IReciter
{
    public static int Index { set; get; }

    //背诵循环列表的索引
    string GetWord();
    string GetWordTranslation();
    string GetWordPos();
    string GetWordPhrase();

    string GetWordPhraseTranslation();

    //请你使用这个方法 针对一个单词设计一个页面 
    //函数名即为函数的功能
    //它会自动调用对应情况下的内容
    void IndexPlus(bool isKnow);

    //请你在认识和不认识的按钮上绑定这个函数 认识默认输入True 不认识输入False
}