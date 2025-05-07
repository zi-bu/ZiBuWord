namespace IBLLBridgeDAL;

public interface IWord
{
    public string? word { get; set; }
    public string? pos { get; set; }
    public string? translation { get; set; }
    public string? phrase { get; set; }
    public string? phraseTranslation { get; set; }
}