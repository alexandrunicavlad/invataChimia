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
using InvataChimie.Activities;
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
            var quiz = (TextView)FindViewById<TextView>(Resource.Id.quiz);

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

            quiz.Click += delegate
            {

                var intent = new Intent(this, typeof(QuizActivity));
                StartActivity(intent);
            };

        }
    }
}