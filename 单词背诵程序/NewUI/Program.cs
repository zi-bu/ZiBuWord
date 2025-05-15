using NetDimension.NanUI;

class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        var builder = NanUIApp.CreateBuilder();

        builder.UseNanUIApp<MyApp>();

        var app = builder.Build();

        app.Run();
    }
}