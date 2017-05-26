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
using InvataChimie.Services;

namespace InvataChimie
{
    [Activity(Label = "LearnOrPlayActivity")]
    public class LearnOrPlayActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.learn_or_play_layout);

            // Create your application here
            var invata = (TextView) FindViewById<TextView>(Resource.Id.invata);
            var joaca = (TextView) FindViewById<TextView>(Resource.Id.joaca);

            invata.Click += delegate
            {
                var intent = new Intent(this, typeof(LearnActivity));
                StartActivity(intent);
            };

            joaca.Click += delegate
            {
                
                var intent = new Intent(this, typeof(GameActivity));
                StartActivity(intent);
            };

            var databaseServices = new DatabaseServices(this);
            var question1 = new Question()
            {
                Id = 1,
                Name = "Care este ?",
                AnswerGood = "answer1",
                Answer1 = "nimic",
                Answer2 = "nunu",
                Answer3 = "dada",
                ImageKey = "nu este"                 
            };
            var question2 = new Question()
            {
                Id = 1,
                Name = "Care este acela?",
                AnswerGood = "answer2",
                Answer1 = "nimic",
                Answer2 = "nunu",
                Answer3 = "dada",
                ImageKey = "nu este"
            };
            databaseServices.InsertQuestion(question1);
            databaseServices.InsertQuestion(question2);

        }
    }
}