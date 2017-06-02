using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Preferences;
using InvataChimie.Services;
using Java.Util;
using Android.Content.Res;

namespace InvataChimie
{
    [Activity(Label = "StartActivity")]
    public class StartActivity : Activity
    {
        private Boolean recreate = false;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.start_layout);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);          
            ActionBar.Title = Resources.GetString(Resource.String.Hello);
            var startButton = (Button)FindViewById<Button>(Resource.Id.startButton);
            
            startButton.Click += delegate
             {
                 var intent = new Intent(this, typeof(LearnOrPlayActivity));
                 StartActivity(intent);
             };

            var databaseServices = new DatabaseServices(this);
            databaseServices.DeleteQuestions();

            for (var i = 1; i <= 30; i++)
            {
                var questionNew = new Question
                {
                    Id = i,
                    Name = "Care este " + i + "?",
                    AnswerGood = "1",
                    Answer1 = "Ras 1" + i,
                    Answer2 = "Ras 2" + i,
                    Answer3 = "Ras 3" + i,
                    ImageKey = "nu este",
                    Resolved = 0
                };
                databaseServices.InsertQuestion(questionNew);
            }
            
         }


        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            View view = LayoutInflater.Inflate(Resource.Layout.language_layout, null);
            AlertDialog builder = new AlertDialog.Builder(this).Create();
            builder.SetView(view);
            builder.SetCanceledOnTouchOutside(false); 
            var romanianLayout = (RelativeLayout)view.FindViewById<RelativeLayout>(Resource.Id.romanian_layout);
            var englishLayout = (RelativeLayout)view.FindViewById<RelativeLayout>(Resource.Id.english_layout);
            
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            ISharedPreferencesEditor editor = prefs.Edit();
                        
            romanianLayout.Click += delegate
            {
                editor.PutString("language", "ro");
                editor.Apply();
                SetupLanguage("ro");
                Recreate();
                builder.Cancel();

            };

            englishLayout.Click += delegate
            {
                editor.PutString("language", "en");
                editor.Apply();
                SetupLanguage("en");
                Recreate();
                builder.Cancel();
            };

            builder.Show();
            return base.OnOptionsItemSelected(item);
        }

        private void SetupLanguage(String lang)
        {
            var language = PreferenceManager.GetDefaultSharedPreferences(ApplicationContext).GetString("Language", lang);
            var locale = new Locale(language);
            Locale.Default = locale;
            Configuration config = new Configuration();
            config.Locale = locale;
            this.BaseContext.Resources.UpdateConfiguration(config, this.BaseContext.Resources.DisplayMetrics);
        }
    }
}