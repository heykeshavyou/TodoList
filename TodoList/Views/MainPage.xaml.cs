using TodoList.Repositry;
using TodoList.ViewModels;

namespace TodoList
{
    public partial class MainPage : ContentPage
    {

        public MainPage(TodoRepository todoRepository)
        {
            InitializeComponent();
            BindingContext = new HomeViewModel(todoRepository); 
        }


    }
}
