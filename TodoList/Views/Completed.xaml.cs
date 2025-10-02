using TodoList.ViewModels;

namespace TodoList.Views;

public partial class Completed : ContentPage
{
	public Completed(CompletedViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
}