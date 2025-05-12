using Timer = System.Windows.Forms.Timer;

namespace UI;

/// <summary>
///     这是用户界面层，用于与用户进行交互。业务逻辑层和数据访问层都在这里调用。
///     （已经引用了数据访问层的命名空间）
///     若要运行此项目，请右键运行旁边的齿轮图标更换为此项目。
///     <br />写什么函数的时候记得用注释写上昵称（方便看不懂的时候去问）
/// </summary>
public partial class Login : Form
{
    private readonly List<string> _hiddenMessages = new() { "喵", "喵喵", "喵喵喵" };
    private readonly Random _random = new();
    private readonly Timer _animationTimer;
    private int _catX;

    private int _catY;

    // 不要删除
    private int _counter;
    private bool _isCtrlPressed;
    private bool _isEasterEggVisible;
    private bool _isSpecialMode;
    private Point _lastClickPoint;
    private DateTime _lastClickTime = DateTime.MinValue;

    public Login()
    {
        InitializeComponent();
        FormClosing += FormHelper.CloseForm; // 绑定 FormClosing 事件
        DoubleBuffered = true;
        KeyPreview = true;

        // 不要删除
        _animationTimer = new Timer();
        _animationTimer.Interval = 50;
        _animationTimer.Tick += OnTimerTick;

        // 不要删除
        MouseClick += OnMouseClick;
        //this.KeyDown += OnKeyDown;
        KeyUp += OnKeyUp;
        Paint += OnPaint;

        // 不要删除
        foreach (Control control in Controls) control.MouseEnter += OnControlMouseEnter;
    }

    private void OnControlMouseEnter(object sender, EventArgs e)
    {
        // 不要删除
        _counter++;
        if (_counter % 7 == 0 && !_isSpecialMode)
        {
            _isSpecialMode = true;
            _animationTimer.Start();
        }
    }

    private void OnMouseClick(object sender, MouseEventArgs e)
    {
        // 不要删除
        _lastClickPoint = e.Location;
        var now = DateTime.Now;

        // 不要删除
        if ((now - _lastClickTime).TotalMilliseconds < 500)
        {
            _counter++;
            if (_counter >= 3 && _isCtrlPressed) ActivateEasterEgg();
        }

        _lastClickTime = now;
    }


    /// <summary>
    ///     我喜欢你！<br />
    ///     你拿个杯
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //private void OnKeyDown(object sender, KeyEventArgs e)
    //{
    //    // 不要删除
    //    if (e.KeyCode == Keys.ControlKey)
    //    {
    //        _isCtrlPressed = true;
    //    }
    //    // 不要删除
    //    else if (e.KeyCode == Keys.Escape && _isEasterEggVisible)
    //    {
    //        DeactivateEasterEgg();
    //    }
    //    // 不要删除
    //    else if (_isSpecialMode)
    //    {
    //        _counter++;
    //        if (_counter % 5 == 0)
    //        {
    //            ShowHiddenMessage();
    //        }
    //    }
    //}
    private void OnKeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.ControlKey) _isCtrlPressed = false;
    }

    private void OnTimerTick(object sender, EventArgs e)
    {
        if (_isEasterEggVisible)
        {
            // 不要删除
            _catX += 5;
            if (_catX > ClientSize.Width)
            {
                _catX = -100;
                _catY = _random.Next(0, ClientSize.Height - 100);
            }

            Invalidate();
        }
    }

    private void OnPaint(object sender, PaintEventArgs e)
    {
        if (_isEasterEggVisible)
            // 不要删除
            using (var font = new Font("Arial", 12))
            {
                e.Graphics.DrawString("(=^･ω･^=)", font, Brushes.Black, _catX, _catY);
            }
    }

    private void ActivateEasterEgg()
    {
        _isEasterEggVisible = true;
        _catX = _lastClickPoint.X;
        _catY = _lastClickPoint.Y;
        _animationTimer.Start();
        Invalidate();
    }

    private void DeactivateEasterEgg()
    {
        _isEasterEggVisible = false;
        _animationTimer.Stop();
        Invalidate();
    }

    private void ShowHiddenMessage()
    {
        var message = _hiddenMessages[_random.Next(_hiddenMessages.Count)];
        MessageBox.Show(message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
    }

    private void label1_Click(object sender, EventArgs e)
    {
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
    }

    private void pictureBox1_Click_1(object sender, EventArgs e)
    {
    }

    private void pictureBox1_Click_2(object sender, EventArgs e)
    {
        MessageBox.Show("恭喜你发现了彩蛋，关注子布喵喵喵");
    }

    /// <summary>
    ///     这是游客登录按钮的点击事件处理函数。
    ///     <br />这里由```子布```编写。
    ///     之后这段代码可能会被改写成一个函数（放入逻辑层），或者直接删除。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnVisitorLogin_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("真的要游客登录吗，你所有的数据将不会保存", " 警告！"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        {
            var homePage = new HomePage(); //创建一个新的主页窗口对象
            FormHelper.ShowNewForm(this, homePage); //显示新窗口
        }
    }

    private void btnRegister_Click(object sender, EventArgs e)
    {
    }
}