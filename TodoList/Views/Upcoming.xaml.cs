using TodoList.ViewModels;

namespace TodoList.Views;

public partial class Upcoming : ContentPage
{
	public Upcoming(UpcomingViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
}