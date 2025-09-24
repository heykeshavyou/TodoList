using TodoList.Repositry;
using TodoList.ViewModels;

namespace TodoList.Views;

public partial class Create : ContentPage
{
	public Create(TodoRepository todoRepository)
	{
		InitializeComponent();
				BindingContext = new CreateViewModel(todoRepository);
    }
}