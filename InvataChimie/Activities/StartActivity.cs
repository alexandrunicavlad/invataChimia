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

            for (var i = 100; i <= 130; i++)
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
                    Resolved = 0,
                    Type = "play"
                };
                databaseServices.InsertQuestion(questionNew);
            }

            populateQuizTable(databaseServices);




        }

        private void populateQuizTable(DatabaseServices databaseServices)
        {
            var question1 = new Question
            {
                Id = 1,
                Name = "Care sunt tipurile de carbon de mai jos?",
                AnswerGood = "1",
                Answer1 = "1 primar, 2 secundari, 1 tertiar, 3 cuaternari",
                Answer2 = "2 primari, 2 secundari, 2 tertiari, 1 cuaternar",
                Answer3 = "1 primar, 3 secundari,  1 tertiar, 2 cuaternari",
                ImageKey = "an1",
                Resolved = 0,
                Type = "quiz"
            };

            var question2 = new Question
            {
                Id = 2,
                Name = "Ce element este representat mai jos?",
                AnswerGood = "1",
                Answer1 = "Butan",
                Answer2 = "Pentan",
                Answer3 = "Propan",
                ImageKey = "an2",
                Resolved = 0,
                Type = "quiz"
            };

            var question3 = new Question
            {
                Id = 3,
                Name = "Carei tip de hidrocarbura apartine urmatoarea strucutra?",
                AnswerGood = "1",
                Answer1 = "Alchinelor",
                Answer2 = "Alcanilor",
                Answer3 = "Alchenelor",
                ImageKey = "an3",
                Resolved = 0,
                Type = "quiz"
            };

            var question4 = new Question
            {
                Id = 4,
                Name = "Ce fel de izomerie prezinta structurile de mai jos?",
                AnswerGood = "1",
                Answer1 = "De catena",
                Answer2 = "De pozitie",
                Answer3 = "Geometrica",
                ImageKey = "an4",
                Resolved = 0,
                Type = "quiz"
            };

            var question5 = new Question
            {
                Id = 5,
                Name = "Care dintre urmatoarele siruri contin numai alcani?",
                AnswerGood = "1",
                Answer1 = "Metil, propan, butena",
                Answer2 = "Etan, metan, propan",
                Answer3 = "Etena, propena, butena",
                ImageKey = "",
                Resolved = 0,
                Type = "quiz"
            };

            var question6 = new Question
            {
                Id = 6,
                Name = "Care sunt, in ordine, izomerii de mai jos?",
                AnswerGood = "1",
                Answer1 = "Meta, orto, para",
                Answer2 = "Orto, meta, para",
                Answer3 = "Para, orto, meta",
                ImageKey = "an6",
                Resolved = 0,
                Type = "quiz"
            };

            var question7 = new Question
            {
                Id = 7,
                Name = "Ce tip de reactie a alchelor are loc in imagine?",
                AnswerGood = "1",
                Answer1 = "Oxidare",
                Answer2 = "Polimerizare",
                Answer3 = "Aditia hidracizilor",
                ImageKey = "an7",
                Resolved = 0,
                Type = "quiz"
            };

            var question8 = new Question
            {
                Id = 8,
                Name = "Ce rezulta in urma reactiei?",
                AnswerGood = "1",
                Answer1 = "Acetilena",
                Answer2 = "Etena",
                Answer3 = "Acetone",
                ImageKey = "an8",
                Resolved = 0,
                Type = "quiz"
            };

            databaseServices.InsertQuestion(question1);
            databaseServices.InsertQuestion(question2);
            databaseServices.InsertQuestion(question3);
            databaseServices.InsertQuestion(question4);
            databaseServices.InsertQuestion(question5);
            databaseServices.InsertQuestion(question6);
            databaseServices.InsertQuestion(question7);
            databaseServices.InsertQuestion(question8);


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