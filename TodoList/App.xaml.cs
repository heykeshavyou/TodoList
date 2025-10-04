using TodoList.Repositry;

namespace TodoList
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }
        protected override Window CreateWindow(IActivationState activationState)
        {
            var mainPage = IPlatformApplication.Current.Services.GetService<MainPage>();
            return new Window(new NavigationPage(mainPage));
        }
    }
}