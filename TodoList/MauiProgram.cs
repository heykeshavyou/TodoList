using Microsoft.Extensions.Logging;
using TodoList.Repositry;
using TodoList.ViewModels;
using TodoList.Views;

namespace TodoList
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "todos.db3");
            builder.Services.AddSingleton(new TodoRepository(dbPath));
            // ViewModels
            builder.Services.AddTransient<HomeViewModel>();
            builder.Services.AddTransient<CreateViewModel>();

            // Pages
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<Create>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
