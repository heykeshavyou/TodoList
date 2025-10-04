using TodoList.Repositry;

namespace TodoList.ViewModels
{
    public class BaseTaskViewModel:BindableObject
    {
        public readonly TodoRepository _todoRepository;
        public BaseTaskViewModel(TodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }
    }
}
