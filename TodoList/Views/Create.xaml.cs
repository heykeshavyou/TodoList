using TodoList.Repositry;
using TodoList.ViewModels;

namespace TodoList.Views;

public partial class Create : ContentPage
{
	public Create(CreateViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }

    private void TimePicker_TimeSelected(object sender, TimeChangedEventArgs e)
    {

    }
}