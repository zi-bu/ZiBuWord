using NetDimension.NanUI;
using NetDimension.NanUI.Forms;

class MyWindow : Formium
{
    public MyWindow()
    {
        Url = "https://www.bilibili.com/";
    }

    protected override FormStyle ConfigureWindowStyle(WindowStyleBuilder builder)
    {
        // 此处配置窗口的样式和属性，或留空以使用默认样式

        var style = builder.UseSystemForm();

        style.TitleBar = true;


        style.DefaultAppTitle = "My first WinFomrim app";

        return style;
    }
}