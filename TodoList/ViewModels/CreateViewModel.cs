using System.Windows.Input;
using TodoList.Models;
using TodoList.Repositry;

namespace TodoList.ViewModels
{
    public class CreateViewModel: BindableObject
    {
        public List<string> PriorityData { get; set; } = new List<string>() { "Normal", "High", "Low" };
        public DateTime TodayDate { get; set; } =DateTime.Today;
        private readonly TodoRepository _todoRepository;
        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _priority;
        public string PriorityText
        {
            get => _priority;
            set
            {
                if (_priority != value)
                {
                    _priority = value;
                    OnPropertyChanged();
                }
            }
        }
        private DateTime? _dueDate;
        public DateTime? DueDate
        {
            get => _dueDate;
            set
            {
                if (_dueDate != value)
                {
                    _dueDate = value;
                    OnPropertyChanged();
                }
            }
        }
        private TimeSpan? _dueTime;
        public TimeSpan? DueTime
        {
            get => _dueTime;
            set
            {
                if (_dueTime != value)
                {
                    _dueTime = value;
                    OnPropertyChanged();
                }
            }
        }
        private bool _isCompleted;
        public bool IsCompleted
        {
            get => _isCompleted;
            set
            {
                if (_isCompleted != value)
                {
                    _isCompleted = value;
                    OnPropertyChanged();
                }
            }
        }
        public ICommand SaveCommand { get; }
        public CreateViewModel(TodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
            SaveCommand = new Command(()=> OnSave());
        }
        private async Task OnSave()
        {
            var newItem = new TodoItem
            {
                Title = _title,
                Description = _description,
                Priority = (Priority)Enum.Parse(typeof(Priority),_priority),
                DueDate = _dueDate,
                DueTime = DateTime.Now.Date.Add((TimeSpan)_dueTime),
                IsCompleted = _isCompleted,
                CreatedAt = DateTime.Now
            };
            await _todoRepository.SaveItemAsync(newItem);
            App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
