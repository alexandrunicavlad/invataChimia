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

namespace InvataChimie
{
    [Activity(Label = "StartActivity")]
    public class StartActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.start_layout);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);          
            ActionBar.Title = "Invata Chimia";
            var startButton = (Button)FindViewById<Button>(Resource.Id.startButton);
            startButton.Click += delegate
             {
                 var intent = new Intent(this, typeof(LearnOrPlayActivity));
                 StartActivity(intent);
             };

            var databaseServices = new DatabaseServices(this);
            databaseServices.DeleteQuestions();
            var question1 = new Question()
            {
                Id = 1,
                Name = "Care este ?",
                AnswerGood = "1",
                Answer1 = "nimic",
                Answer2 = "nunu",
                Answer3 = "dada",
                ImageKey = "nu este",
                Resolved = 0
            };
            var question2 = new Question()
            {
                Id = 2,
                Name = "Care este acela?",
                AnswerGood = "2",
                Answer1 = "nimic",
                Answer2 = "nunu",
                Answer3 = "dada",
                ImageKey = "nu este",
                Resolved = 0
            };
            var question3 = new Question()
            {
                Id = 3,
                Name = "Care este 3?",
                AnswerGood = "2",
                Answer1 = "nimic",
                Answer2 = "nunu",
                Answer3 = "dada",
                ImageKey = "nu este",
                Resolved = 0
            };
            var question4 = new Question()
            {
                Id = 4,
                Name = "Care este 4?",
                AnswerGood = "2",
                Answer1 = "nimic",
                Answer2 = "nunu",
                Answer3 = "dada",
                ImageKey = "nu este",
                Resolved = 0
            };
            databaseServices.InsertQuestion(question1);
            databaseServices.InsertQuestion(question2);
            databaseServices.InsertQuestion(question3);
            databaseServices.InsertQuestion(question4);
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
                builder.Cancel();
            };

            englishLayout.Click += delegate
            {
                editor.PutString("language", "en");
                editor.Apply();
                builder.Cancel();
            };

            builder.Show();
            return base.OnOptionsItemSelected(item);
        }
    }
}