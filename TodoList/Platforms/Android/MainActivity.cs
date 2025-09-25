using Android.App;
using Android.Content.PM;
using Android.OS;

namespace TodoList
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            var statusBarColor = Android.Graphics.Color.ParseColor("#ffffff");
            Window.SetStatusBarColor(statusBarColor);
            
            base.OnCreate(savedInstanceState);
        }
    }
}
