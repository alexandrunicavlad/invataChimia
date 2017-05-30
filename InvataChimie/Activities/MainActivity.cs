using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Preferences;
using Java.Util;
using Android.Content.Res;

namespace InvataChimie
{
    [Activity(Label = "InvataChimie", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate {
                var intent = new Intent(this, typeof(StartActivity));
                StartActivity(intent);
            };

            var language = PreferenceManager.GetDefaultSharedPreferences(ApplicationContext).GetString("Language", "ro");
            var locale = new Locale(language);
            Locale.Default = locale;
            Configuration config = new Configuration();
            config.Locale = locale;
            this.BaseContext.Resources.UpdateConfiguration(config, this.BaseContext.Resources.DisplayMetrics);
        }
    }
}

