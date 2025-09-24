using TodoList.Repositry;

namespace TodoList
{
    public partial class App : Application
    {
        private readonly TodoRepository _todoRepository;
        public App(TodoRepository todoRepository)
        {
            InitializeComponent();
            _todoRepository = todoRepository;
            MainPage =new MainPage(_todoRepository);
        }
    }
}