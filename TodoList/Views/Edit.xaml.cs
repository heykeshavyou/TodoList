using TodoList.ViewModels;

namespace TodoList.Views;

public partial class Edit : ContentPage
{
	private EditViewModel _viewModel;
	public int Id;
    public Edit(EditViewModel editViewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = editViewModel;
    }
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await _viewModel.LoadItem(Id);
    }
}