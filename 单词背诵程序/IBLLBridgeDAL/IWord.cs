namespace IBLLBridgeDAL;

public interface IWord
{
    public string Word { get; set; }
    public string Pos { get; set; }
    public string Translation { get; set; }
    public string Phrase { get; set; }
    public string PhraseTranslation { get; set; }
}