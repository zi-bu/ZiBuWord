namespace IBLLBridgeDAL;

public interface IWord
{
    public string word { get;}
    public List<string> pos { get;}
    public List<string> translations { get;}
    public List<string>? phrases { get;}
    public List<string>? phraseTranslations { get;}
}