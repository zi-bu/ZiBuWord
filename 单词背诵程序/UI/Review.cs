using System;
using System.Windows.Forms;
using UI.Services;

namespace UI
{
    public partial class Review : Form
    {
        public Review()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            NavigationService.NavigateTo(this, homePage);
        }
    }
}
