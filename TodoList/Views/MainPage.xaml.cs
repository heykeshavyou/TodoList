using TodoList.ViewModels;

namespace TodoList
{
    public partial class MainPage : ContentPage
    {
        private readonly HomeViewModel _viewModel;
        public MainPage(HomeViewModel vm)
        {
            InitializeComponent();
            BindingContext = _viewModel = vm; 
        }

        protected override async void OnAppearing()
        {
            await _viewModel.OnAppearing();
        }
    }
}
