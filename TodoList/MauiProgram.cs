using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;
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
                .UseMauiCommunityToolkit()
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
            builder.Services.AddTransient<EditViewModel>();
            builder.Services.AddTransient<CompletedViewModel>();
            builder.Services.AddTransient<UpcomingViewModel>();

            // Pages
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<Create>();
            builder.Services.AddTransient<Edit>();
            builder.Services.AddTransient<Completed>();
            builder.Services.AddTransient<Upcoming>();
            PickerHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
            {
                #if ANDROID
                handler.PlatformView.Background = null; // removes underline
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#endif
            });
            TimePickerHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
            {
#if ANDROID
                handler.PlatformView.Background = null; // removes underline
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#endif
            });
            DatePickerHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
            {
#if ANDROID
                handler.PlatformView.Background = null; // removes underline
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#endif
            });
            EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
            {
#if ANDROID
                handler.PlatformView.Background = null; // removes underline
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
                handler.PlatformView.TextCursorDrawable?.SetTint(Android.Graphics.Color.ParseColor("#24A19C"));
#endif
            });
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
