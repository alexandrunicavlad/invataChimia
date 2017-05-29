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
using Android.Support.V4.View;
using Android.Support.V4.App;
using InvataChimie.Services;

namespace InvataChimie
{
    [Activity(Label = "GameActivity")]
    public class GameActivity : FragmentActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.game_layout);
            ViewPager viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
            var databaseServices = new DatabaseServices(this);
            int count = databaseServices.getQuestionsCount();
            var questions = databaseServices.getAllQuestions();
            var adapter = new CustomPagerAdapter(this,  SupportFragmentManager, questions);
            viewPager.Adapter = adapter;
            
            if (savedInstanceState == null)
            {
               //var transaction = FragmentManager.BeginTransaction();
               
               //transaction.Replace(Resource.Id.sample_content_fragment, fragment);
               //transaction.Commit();
            }
        }
    }
}