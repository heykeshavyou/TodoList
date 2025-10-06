using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TodoList.Models;
using TodoList.Repositry;
using TodoList.Service;

namespace TodoList.ViewModels
{
    public class EditViewModel:BindableObject
    {
        private readonly TodoRepository _todoRepository;
        private readonly ISnackBarService _snackBarService;

        public List<string> PriorityData { get; set; } = new List<string>() { "Normal", "High", "Low" };
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
        private bool _isLoading=true;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                if (_isLoading != value)
                {
                    _isLoading = value;
                    OnPropertyChanged(nameof(IsLoading));
                }
            }
        }
        private bool isShow=false;
        public bool IsShow
        {
            get => isShow;
            set
            {
                if (isShow != value)
                {
                    isShow = value;
                    OnPropertyChanged(nameof(IsShow));
                }
            }
        }
        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }
        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged(nameof(Title));
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
                    OnPropertyChanged(nameof(Description));
                }
            }
        }
        private DateTime _dueDate;
        public DateTime DueDate
        {
            get => _dueDate;
            set
            {
                if (_dueDate != value)
                {
                    _dueDate = value;
                    OnPropertyChanged(nameof(DueDate));
                }
            }
        }
        private TimeSpan _duetime;
        public TimeSpan DueTime
        {
            get => _duetime;
            set
            {
                if (_duetime != value)
                {
                    _duetime = value;
                    OnPropertyChanged(nameof(DueTime));
                }
            }
        }
        public EditViewModel(TodoRepository todoRepository,ISnackBarService snackBarService)
        {
            _todoRepository = todoRepository;
            UpdateCommand = new Command(async () => await Update());
            Cancel= new Command(async () => await App.Current.Windows[0].Page.Navigation.PopAsync());
            _snackBarService = snackBarService;
        }
        public ICommand UpdateCommand { get; }
        public ICommand Cancel{ get; }
        public async Task LoadItem(int id)
        {
            var item = await _todoRepository.GetItemAsync(id);
            if (item != null)
            {
                Id = item.Id;
                Title = item.Title;
                Description = item.Description;
                DueDate = item.DueDate ?? DateTime.Today;
                DueTime = item.DueTime.Value.TimeOfDay;
                PriorityText = item.Priority.ToString();
            }
            await Task.Delay(500);
            IsShow = true;
            IsLoading = false;
        }
        public async Task Update()
        {
            var item = new TodoItem()
            {
                Id = this.Id,
                Title = this.Title,
                Description = this.Description,
                DueDate = this.DueDate,
                DueTime = DateTime.Today.Add(this.DueTime),
                Priority = (Priority)Enum.Parse(typeof(Priority), this.PriorityText)
            };
            await _todoRepository.SaveItemAsync(item);
            _snackBarService.TaskUpdated();
            await App.Current.Windows[0].Page.Navigation.PopAsync();
        }
    }
}
