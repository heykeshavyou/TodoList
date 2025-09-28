using System.Threading.Tasks;
using System.Windows.Input;
using TodoList.Models;
using TodoList.Repositry;
using TodoList.Views;

namespace TodoList.ViewModels
{
    public class HomeViewModel : BindableObject
    {
        private readonly TodoRepository _todoRepository;
        private bool _showLoading = true;
        private bool _showList = false;
        public HomeViewModel(TodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
            GotoCreate = new Command(Goto);
            Delete = new Command<int>(DeleteTodo);
        }
        public bool ShowLoading
        {
            get => _showLoading;
            set
            {
                if (_showLoading != value)
                {
                    _showLoading = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool ShowList
        {
            get => _showList;
            set
            {
                if (_showList != value)
                {
                    _showList = value;
                    OnPropertyChanged();
                }
            }
        }
        public async Task OnAppearing()
        {
            TodoItems = await _todoRepository.GetItemsAsync();
            ShowList = true;
            ShowLoading = false;
        }
        public ICommand GotoCreate { get; }

        public List<TodoItem> TodoItems
        {
            get => _todoItems;
            set
            {
                if (_todoItems != value)
                {
                    _todoItems = value;
                    OnPropertyChanged();
                }
            }
        }
        public ICommand Delete { get; }
        private async void DeleteTodo(int id)
        {
            var item = await _todoRepository.GetItemAsync(id);
            if (item != null)
            {
                var result = await App.Current.MainPage.DisplayAlertAsync("Delete", $"Are you sure you want to delete {item.Title.Trim()} ?", "Yes", "No");
                if (result)
                {
                    await _todoRepository.DeleteItemAsync(item);
                    TodoItems = await _todoRepository.GetItemsAsync();
                }
            }
        }

        private List<TodoItem> _todoItems;
        private void Goto()
        {
            var create = IPlatformApplication.Current.Services.GetService<Create>();

            App.Current.MainPage.Navigation.PushAsync(create);
        }
    }
}
