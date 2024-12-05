using Android.App;
using Android.Content.PM;
using Android.OS;

namespace HypertrophyApp
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set status bar color
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#FF4444")); // Rdeča barva
            }
        }

    }


}
