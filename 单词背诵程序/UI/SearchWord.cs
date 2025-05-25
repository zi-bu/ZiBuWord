using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class SearchWord : Form
    {
        public SearchWord()
        {
            
            //给listView1添加列标题
            InitializeComponent();
            listView1.View = View.Details;
            listView1.Columns.Clear();
            listView1.Columns.Add("单词", 120);
            listView1.Columns.Add("词性", 80);
            listView1.Columns.Add("释义", 500);
            listView1.FullRowSelect = true;
            //让 ListView 控件在“详细信息”视图（View.Details）下，点击某一行的任意列时，整行都被选中并高亮显示。
            listView1.GridLines = true;
            //让 ListView 控件在显示内容时，显示网格线。
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage(); //创建一个新的主页窗口对象
            homePage.Show(); //显示新窗口
            Hide(); //隐藏当前窗口
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {

            var searcher = new SearchWordEnglish(new WordQueryDAL());
            //创建一个 SearchWordEnglish 对象，并把 WordQueryDAL 作为参数传进去
            var result = searcher.SearchEnglish(textBox1.Text.Trim());
            listView1.Items.Clear();
            foreach (var w in result)
            {
                var item = new ListViewItem(w.word); 
                // 创建一行，第一列是单词
                item.SubItems.Add(string.Join("/", w.pos)); 
                // 第二列是词性，多个词性用“/”分隔
                item.SubItems.Add(string.Join("；", w.translations)); 
                // 第三列是释义，多个释义用“；”分隔
                listView1.Items.Add(item); 
                // 把这一行加到 ListView 控件中
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var searcher = new SearchWordChinese(new WordQueryDAL());
            var result = searcher.SearchChinese(textBox2.Text.Trim());
            listView1.Items.Clear();
            foreach (var w in result)
            {
                var item = new ListViewItem(w.word);
                item.SubItems.Add(string.Join("/", w.pos));
                item.SubItems.Add(string.Join("；", w.translations));
                listView1.Items.Add(item);
            }
        }

        private void SearchWord_Load(object sender, EventArgs e)
        {

        }

        private void 中文搜索_Click(object sender, EventArgs e)
        {

        }
    }
}
