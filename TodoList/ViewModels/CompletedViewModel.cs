using System.Windows.Input;
using TodoList.Models;
using TodoList.Repositry;
using TodoList.Service;

namespace TodoList.ViewModels
{
    public class CompletedViewModel: BindableObject
    {
        private readonly TodoRepository _todoRepository;
        private readonly ISnackBarService _snackBarService;
        public CompletedViewModel(TodoRepository todoRepository, ISnackBarService snackBarService)
        {
            _todoRepository = todoRepository;
            Delete = new Command<int>(DeleteTodo);
            _snackBarService = snackBarService;
        }
        private List<TodoItem> _todoItems;
        private bool _showLoading = true;

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
        public async Task OnAppearing()
        {
            var res = await _todoRepository.GetItemsAsync();
            TodoItems = res.Where(x => x.IsCompleted).ToList();
            ShowLoading = false;
        }
        public ICommand Delete { get; }
        private async void DeleteTodo(int id)
        {
            var item = await _todoRepository.GetItemAsync(id);
            if (item != null)
            {
                var result = await App.Current.Windows[0].Page.DisplayAlertAsync("Delete", $"Are you sure you want to delete {item.Title.Trim()} ?", "Yes", "No");
                if (result)
                {
                    await _todoRepository.DeleteItemAsync(item);
                    var res = await _todoRepository.GetItemsAsync();
                    TodoItems = res.Where(x => x.IsCompleted).ToList();
                    _snackBarService.TaskDeleted();
                }
            }
        }
    }
}
