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
            InitializeComponent();
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
            var result = searcher.FuzzySearch(textBox1.Text.Trim());
            listBox1.Items.Clear();
            listBox1.Items.AddRange(result.Select(w => w.word).ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text2 = textBox2.Text;//还没写完
        }

        private void SearchWord_Load(object sender, EventArgs e)
        {

        }
    }
}
