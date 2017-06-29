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
using System.Threading;

namespace InvataChimie
{
    [Activity(Label = "Chainmistry", MainLauncher = true, Icon = "@drawable/ic_launcher")]
    public class MainActivity : Activity
    {
        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);            
            SetContentView(Resource.Layout.Main);
            var language = PreferenceManager.GetDefaultSharedPreferences(ApplicationContext).GetString("Language", "ro");
            var locale = new Locale(language);
            Locale.Default = locale;
            Configuration config = new Configuration();
            config.Locale = locale;
            this.BaseContext.Resources.UpdateConfiguration(config, this.BaseContext.Resources.DisplayMetrics);

            ThreadPool.QueueUserWorkItem(o => StartMainActivity());
        }

        private void StartMainActivity()
        {
            Java.Lang.Thread.Sleep(3000);
            StartActivity(typeof(StartActivity));
            Finish();
        }
    }
}

