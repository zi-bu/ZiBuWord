using BLL;

namespace UI
{
    /// <summary>
    /// 这是用户界面层，用于与用户进行交互。业务逻辑层和数据访问层都在这里调用。
    /// （已经引用了数据访问层的命名空间）
    /// 若要运行此项目，请右键运行旁边的齿轮图标更换为此项目。
    /// <br/>写什么函数的时候记得用注释写上昵称（方便看不懂的时候去问）
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
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
        /// 这是游客登录按钮的点击事件处理函数。
        /// <br/>这里由```子布```编写。
        /// 之后这段代码可能会被改写成一个函数（放入逻辑层），或者直接删除。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VisitorLogin(object sender, EventArgs e)
        {
            if(MessageBox.Show("真的要游客登录吗，你所有的数据将不会保存", " 警告！"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Form2 f2 = new Form2();//创建一个新的Form2对象
                f2.Show();//显示Form2窗口
                this.Hide();//隐藏当前窗口
            }
        }
    }
}
