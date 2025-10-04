using TodoList.ViewModels;

namespace TodoList.Views;

public partial class Upcoming : ContentPage
{
	private readonly UpcomingViewModel _viewModel;
    public Upcoming(UpcomingViewModel vm)
	{
		InitializeComponent();
		BindingContext = _viewModel= vm;
    }
	protected override async void OnAppearing()
	{
		await _viewModel.OnAppearing();
    }

}