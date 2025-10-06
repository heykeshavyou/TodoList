using System.Threading.Tasks;
using System.Windows.Input;
using TodoList.Models;
using TodoList.Repositry;
using TodoList.Service;
using TodoList.Views;

namespace TodoList.ViewModels
{
    public class HomeViewModel : BindableObject
    {
        private readonly TodoRepository _todoRepository;
        private readonly ISnackBarService _snackBarService;
        private bool _showLoading = true;
        public HomeViewModel(TodoRepository todoRepository , ISnackBarService snackBarService)
        {
            _todoRepository = todoRepository;
            Delete = new Command<int>(DeleteTodo);
            GotoEdit = new Command<int>(Goto);
            Mark = new Command<int>(MarkTodo);
            GotoPage = new Command<string>(async (string a) => await Goto(a));
            _snackBarService = snackBarService;
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
            TodoItems= res.Where(x=>x.DueDate.Value.Date==DateTime.Today.Date).ToList();
            ShowLoading = false;
        }
        private List<TodoItem> _todoItems;

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

        public ICommand GotoEdit { get; }
        public ICommand Delete { get; }
        public ICommand Mark { get; }
        public ICommand GotoPage { get; }
        private async void MarkTodo(int id)
        {
            var item = await _todoRepository.GetItemAsync(id);
            if (item != null)
            {
                item.IsCompleted = !item.IsCompleted;
                await _todoRepository.SaveItemAsync(item);
                var res = await _todoRepository.GetItemsAsync();
                TodoItems = res.Where(x => x.DueDate.Value.Date == DateTime.Today.Date).ToList();
                _snackBarService.TaskCompleted();
            }
        }
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
                    TodoItems = res.Where(x => x.DueDate.Value.Date == DateTime.Today.Date).ToList();
                    _snackBarService.TaskDeleted();
                }
            }
        }
        private void Goto(int id)
        {
            var edit = IPlatformApplication.Current.Services.GetService<Edit>();
            edit?.Id = id;
            App.Current.Windows[0].Page.Navigation.PushAsync(edit, true);
        }
        private async Task Goto(string page)
        {
            switch (page)
            {
                case "upcoming":
                    var upcoming = IPlatformApplication.Current.Services.GetService<Upcoming>();
                    //await App.Current.MainPage.Navigation.PushAsync(upcoming);
                    await App.Current.Windows[0].Page.Navigation.PushAsync(upcoming,true);
                    break;
                case "completed":
                    var completed = IPlatformApplication.Current.Services.GetService<Completed>();
                    //await App.Current.MainPage.Navigation.PushAsync(completed);
                    await App.Current.Windows[0].Page.Navigation.PushAsync(completed,true);

                    break;
                case "create":
                    var create = IPlatformApplication.Current.Services.GetService<Create>();
                    // await App.Current.MainPage.Navigation.PushAsync(create);
                    await App.Current.Windows[0].Page.Navigation.PushAsync(create,true);
                    break;
                default:
                    break;
            }
        }
    }
}
