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
            TodoItems =  _todoRepository.GetItemsAsync().Result;

        }
        public ICommand GotoCreate;

        private List<TodoItem> TodoItems
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
           
            App.Current.MainPage.Navigation.PushAsync(new Create(_todoRepository));
        }
    }
}
