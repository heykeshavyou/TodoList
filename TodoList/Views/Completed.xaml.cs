using TodoList.ViewModels;

namespace TodoList.Views;

public partial class Completed : ContentPage
{
    private readonly CompletedViewModel _viewModel;
    public Completed(CompletedViewModel vm)
    {
        InitializeComponent();
        BindingContext = _viewModel = vm;
    }
    protected override async void OnAppearing()
    {
        await _viewModel.OnAppearing();
    }
}