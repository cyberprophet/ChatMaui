using ShareInvest.Views;

namespace ShareInvest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Home());
        }
    }
}