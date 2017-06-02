using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using InvataChimie.Services;

namespace InvataChimie.Activities
{
    [Activity(Label = "QuizActivity")]
    public class QuizActivity : FragmentActivity
    {
    private ViewPager viewPager;
    private int count;
    private int countResolved;
    private CustomPagerAdapterQuiz adapter;
    private List<Question> questions;
    private DatabaseServices databaseServices;
    private TextView middle;

    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.quiz_layout);
        var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
        SetActionBar(toolbar);

        ActionBar.Title = Resources.GetString(Resource.String.quiz);
        ActionBar.SetHomeButtonEnabled(true);
        ActionBar.SetDisplayHomeAsUpEnabled(true);
        viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
        TextView left = FindViewById<TextView>(Resource.Id.toolbarBottom_left);
        middle = FindViewById<TextView>(Resource.Id.toolbarBottom_middle);
        TextView right = FindViewById<TextView>(Resource.Id.toolbarBottom_right);
        viewPager.OffscreenPageLimit = 1;
        databaseServices = new DatabaseServices(this);
        count = databaseServices.getQuestionQuizCount();
        countResolved = databaseServices.getQuestionsQuizCountResolved();
        questions = databaseServices.getAllQuizQuestions();
        adapter = new CustomPagerAdapterQuiz(this, SupportFragmentManager, questions);
        viewPager.Adapter = adapter;
        left.Click += delegate
        {
            viewPager.SetCurrentItem(viewPager.CurrentItem - 1, true);
        };
        right.Click += delegate
        {
            viewPager.SetCurrentItem(viewPager.CurrentItem + 1, true);
        };
        SetScore();
    }

    private void SetScore()
    {
        middle.Text = countResolved.ToString() + " / " + count.ToString();
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
            viewPager.SetCurrentItem(x, true);
        }
        questions[x - 1].Resolved = 1;
        countResolved++;
        databaseServices.UpdateQuestion(questions[x - 1]);
        SetScore();
    }



    public override bool OnCreateOptionsMenu(IMenu menu)
    {
        MenuInflater.Inflate(Resource.Menu.refresh, menu);
        return base.OnCreateOptionsMenu(menu);
    }
}
}