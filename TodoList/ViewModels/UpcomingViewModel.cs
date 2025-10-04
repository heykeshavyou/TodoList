using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TodoList.Models;
using TodoList.Repositry;
using TodoList.Views;

namespace TodoList.ViewModels
{
    public class UpcomingViewModel:BindableObject
    {
        private readonly TodoRepository _todoRepository;
        private bool _showLoading = true;
        public UpcomingViewModel(TodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
            Delete = new Command<int>(DeleteTodo);
            GotoEdit = new Command<int>(Goto);
            Mark = new Command<int>(MarkTodo);
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
            TodoItems = res.Where(x => x.DueDate.Value.Date > DateTime.Today.Date).ToList();
            ShowLoading = false;
        }

        public ICommand GotoEdit { get; }
        public ICommand Delete { get; }
        public ICommand Mark { get; }
        private async void MarkTodo(int id)
        {
            var item = await _todoRepository.GetItemAsync(id);
            if (item != null)
            {
                item.IsCompleted = !item.IsCompleted;
                await _todoRepository.SaveItemAsync(item);
                TodoItems = await _todoRepository.GetItemsAsync();
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
                    TodoItems = await _todoRepository.GetItemsAsync();
                }
            }
        }
        private void Goto(int id)
        {
            var edit = IPlatformApplication.Current.Services.GetService<Edit>();
            edit?.Id = id;
            App.Current.Windows[0].Page.Navigation.PushAsync(edit);
        }
    }
}
