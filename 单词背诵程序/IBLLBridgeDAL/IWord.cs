namespace IBLLBridgeDAL;

public interface IWord
{
    public string word { get;}
    public List<string> pos { get;}
    public List<string> translation { get;}
    public List<string>? phrase { get;}
    public List<string>? phraseTranslation { get;}
}