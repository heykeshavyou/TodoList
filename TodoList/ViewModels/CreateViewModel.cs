using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TodoList.Models;
using TodoList.Repositry;

namespace TodoList.ViewModels
{
    public class CreateViewModel: BindableObject
    {
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
        private Priority _priority;
        public Priority Priority
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
            SaveCommand = new Command(OnSave);
        }
        private void OnSave()
        {
            var newItem = new TodoItem
            {
                Title = _title,
                Description = _description,
                Priority = _priority,
                DueDate = _dueDate,
                IsCompleted = _isCompleted,
                CreatedAt = DateTime.Now
            };
            _todoRepository.SaveItemAsync(newItem);
            App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
