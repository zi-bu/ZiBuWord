using NetDimension.NanUI;
using NetDimension.NanUI.WebResource;

class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        var builder = NanUIApp.CreateBuilder();

        builder.UseNanUIApp<MyApp>();

        var app = builder.UseEmbeddedFileResource(new EmbeddedFileResourceOptions
        {
            Scheme = "http",
            DomainName = "embedded.app.local",
            ResourceAssembly = typeof(Program).Assembly,
            EmbeddedResourceDirectoryName = "build",
        })
        .Build();

        app.Run();
    }
}