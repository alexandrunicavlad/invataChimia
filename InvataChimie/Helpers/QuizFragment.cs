using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using InvataChimie.Activities;
using Java.IO;

namespace InvataChimie.Helpers
{
    class QuizFragment : Android.Support.V4.App.Fragment
    {
        public const string TAG = "QuizFragment";        
        const string ARG_PAGE = "ARG_PAGE";
        private int mPage;
        private Question question;

        internal static QuizFragment newInstance(int page, Question item)
        {
            var args = new Bundle();
            args.PutInt(ARG_PAGE, page);
            var fragment = new QuizFragment();
            fragment.Arguments = args;
            fragment.question = item;
            return fragment;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            mPage = Arguments.GetInt(ARG_PAGE);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var rootView = inflater.Inflate(Resource.Layout.quiz_layout_element, container, false);            
            
            var questionName = rootView.FindViewById<TextView>(Resource.Id.questionName);
            var answer1 = rootView.FindViewById<Button>(Resource.Id.answer1_quiz);
            var answer2 = rootView.FindViewById<Button>(Resource.Id.answer2_quiz);
            var answer3 = rootView.FindViewById<Button>(Resource.Id.answer3_quiz);
            var overlay = rootView.FindViewById<LinearLayout>(Resource.Id.overlay_game);
            var questionImage = rootView.FindViewById<ImageView>(Resource.Id.questionImage);
            if (question != null)
            {
                if (question.Resolved == 0)
                {
                    overlay.Visibility = ViewStates.Gone;
                }
                else
                {
                    overlay.Visibility = ViewStates.Visible;
                }
                questionName.Text = question.Name;
                answer1.Text = question.Answer1;
                answer2.Text = question.Answer2;
                answer3.Text = question.Answer3;
                try
                {
                    int resourceId = Resources.GetIdentifier(question.ImageKey.ToString(), "drawable", this.Activity.PackageName);
                    questionImage.SetImageResource(resourceId);
                }
                catch (Java.IO.IOException ex)
                {
                    
                }
            }

            answer1.Click += delegate {
                if (question.AnswerGood.Equals("1"))
                {
                    validate();
                }
            };

            answer2.Click += delegate
            {
                if (question.AnswerGood.Equals("2"))
                {
                    validate();
                }
            };

            answer3.Click += delegate 
            {
                if (question.AnswerGood.Equals("3"))
                {
                    validate();
                }
            };


            return rootView;
        }

        private void validate()
        {
            var inflater = LayoutInflater.From(this.Context);

            var inputView = inflater.Inflate(Resource.Layout.trophy_layout, null);
            AlertDialog.Builder alert = new AlertDialog.Builder(this.Context);
            alert.SetTitle(this.Context.Resources.GetString(Resource.String.felicitari));
            alert.SetView(inputView);
            alert.SetPositiveButton(this.Context.Resources.GetString(Resource.String.dreapta), (senderAlert, args) => {                
                     question.Resolved = 1;
                     this.FragmentManager.BeginTransaction().Detach(this).Attach(this).Commit();
                     ((QuizActivity)Activity).swipeRight(mPage);                
            });
            Dialog dialog = alert.Create();
            dialog.SetCancelable(false);
            dialog.Show();
        }     
    }
}