using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TodoList.Models;
using TodoList.Repositry;
using TodoList.Views;

namespace TodoList.ViewModels
{
    public class HomeViewModel : BindableObject
    {
        private readonly TodoRepository _todoRepository;
        public HomeViewModel(TodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
            GotoCreate = new Command(Goto);
        }

        public async Task OnAppearing()
        {
            TodoItems = await _todoRepository.GetItemsAsync();

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
                    _todoItems = value;
                    OnPropertyChanged();
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
