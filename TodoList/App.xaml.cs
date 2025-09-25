using TodoList.Repositry;

namespace TodoList
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var mainPage = IPlatformApplication.Current.Services.GetService<MainPage>();
            MainPage = new NavigationPage(mainPage);
        }
    }
}