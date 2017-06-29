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

            populateQuizTable(databaseServices);
            populateGameTable(databaseServices);
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
                AnswerGood = "3",
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
                AnswerGood = "2",
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
                AnswerGood = "2",
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
                AnswerGood = "2",
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

        private void populateGameTable(DatabaseServices databaseServices)
        {
            var question1 = new Question
            {
                Id = 101,
                Name = "",
                AnswerGood = "1",
                Answer1 = "Acid benzoic",
                Answer2 = "Acid benzilic",
                Answer3 = "",
                ImageKey = "an101",
                Resolved = 0,
                Type = "play"
            };

            var question2 = new Question
            {
                Id = 102,
                Name = "",
                AnswerGood = "1",
                Answer1 = "Alchina",
                Answer2 = "Alchena",
                Answer3 = "",
                ImageKey = "an102",
                Resolved = 0,
                Type = "play"
            };

            var question3 = new Question
            {
                Id = 103,
                Name = "",
                AnswerGood = "1",
                Answer1 = "Alcool",
                Answer2 = "Fenol",
                Answer3 = "",
                ImageKey = "an103",
                Resolved = 0,
                Type = "play"
            };

            var question4 = new Question
            {
                Id = 104,
                Name = "",
                AnswerGood = "2",
                Answer1 = "-orto",
                Answer2 = "-meta",
                Answer3 = "",
                ImageKey = "an104",
                Resolved = 0,
                Type = "play"
            };

            var question5 = new Question
            {
                Id = 105,
                Name = "",
                AnswerGood = "2",
                Answer1 = "Alcool ",
                Answer2 = "Fenol",
                Answer3 = "",
                ImageKey = "an105",
                Resolved = 0,
                Type = "play"
            };

            var question6 = new Question
            {
                Id = 106,
                Name = "",
                AnswerGood = "1",
                Answer1 = "Alcan",
                Answer2 = "Alchina",
                Answer3 = "",
                ImageKey = "an106",
                Resolved = 0,
                Type = "play"
            };

            var question7 = new Question
            {
                Id = 107,
                Name = "",
                AnswerGood = "1",
                Answer1 = "Enol",
                Answer2 = "Alchena",
                Answer3 = "",
                ImageKey = "an107",
                Resolved = 0,
                Type = "play"
            };

            var question8 = new Question
            {
                Id = 108,
                Name = "",
                AnswerGood = "1",
                Answer1 = "1,3 – butandiena",
                Answer2 = "2,4 – butandiena",
                Answer3 = "",
                ImageKey = "an108",
                Resolved = 0,
                Type = "play"
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