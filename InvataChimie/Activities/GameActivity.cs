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
        private ViewPager viewPager;
        private int count;
        private CustomPagerAdapter adapter;
        private List<Question> questions;
        private DatabaseServices databaseServices;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.game_layout);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);

            ActionBar.Title = Resources.GetString(Resource.String.joc);
            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
            viewPager.OffscreenPageLimit = 1;
            databaseServices = new DatabaseServices(this);
            count = databaseServices.getQuestionsCount();
            questions = databaseServices.getAllQuestions();
            adapter = new CustomPagerAdapter(this,  SupportFragmentManager, questions);
            viewPager.Adapter = adapter;           
           
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    return true;
                case Resource.Id.menu_refresh:
                    ResetResolved();
                    return true;                  

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        public void ResetResolved()
        {
            if (questions != null && questions.Count != 0)
            {
                foreach (var question in questions)
                {
                    if (question.Resolved == 1)
                    {
                        question.Resolved = 0;
                        databaseServices.UpdateQuestion(question);
                    }

                }
                Finish();
            }
        
        }

        public void swipeRight(int x)
        {
            if (x < questions.Count)
            {
                questions[x-1].Resolved = 1;
                databaseServices.UpdateQuestion(questions[x - 1]);
                viewPager.SetCurrentItem(x, true);    
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.refresh, menu);
            return base.OnCreateOptionsMenu(menu);
        }       
    }
}