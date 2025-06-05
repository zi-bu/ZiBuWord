namespace UI;

internal static class Program
{
    public static HomePage homePage = new HomePage();
    /// <summary>
    ///     The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
       //创建一个新的主页窗口对象
        // To customize appl    ication configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new Login());
    }
}