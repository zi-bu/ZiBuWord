using BLL;

namespace UI
{
    /// <summary>
    /// �����û�����㣬�������û����н�����ҵ���߼�������ݷ��ʲ㶼��������á�
    /// ���Ѿ����������ݷ��ʲ�������ռ䣩
    /// ��Ҫ���д���Ŀ�����Ҽ������Աߵĳ���ͼ�����Ϊ����Ŀ��
    /// <br/>дʲô������ʱ��ǵ���ע��д���ǳƣ����㿴������ʱ��ȥ�ʣ�
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
            MessageBox.Show("��ϲ�㷢���˲ʵ�����ע�Ӳ�������");
        }

        /// <summary>
        /// �����ο͵�¼��ť�ĵ���¼���������
        /// <br/>������```�Ӳ�```��д��
        /// ֮����δ�����ܻᱻ��д��һ�������������߼��㣩������ֱ��ɾ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VisitorLogin(object sender, EventArgs e)
        {
            if(MessageBox.Show("���Ҫ�ο͵�¼�������е����ݽ����ᱣ��", " ���棡"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Form2 f2 = new Form2();//����һ���µ�Form2����
                f2.Show();//��ʾForm2����
                this.Hide();//���ص�ǰ����
            }
        }
    }
}
