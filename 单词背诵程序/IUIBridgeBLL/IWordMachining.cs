namespace IUIBridgeBLL;

public interface IWordGetter
{
    string AccurateTrans { get; }
    List<string> BlurSelection { get; }
}

public interface IWordOrder
{
    List<IWord>
}