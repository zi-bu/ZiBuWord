using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using UI.Services;

namespace UI
{
    public partial class Review : Form
    {
        public Review()
        {
            InitializeComponent();
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            // 性能优化设置
            PerformanceService.OptimizeFormPerformance(this);

            // 异步加载数据
            await PerformanceService.LoadFormAsync(this, () =>
            {
                // 在这里添加需要异步加载的初始化代码
                // 例如：加载复习数据等
            });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PerformanceService.CleanupFormResources(this);
            HomePage homePage = new HomePage();
            NavigationService.NavigateTo(this, homePage);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            PerformanceService.CleanupFormResources(this);
        }
    }
}
