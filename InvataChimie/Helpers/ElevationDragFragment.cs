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
using Android.Graphics;


using InvataChimie;
using InvataChimie.Services;

namespace InvataChimie
{
    public class ElevationDragFragment : Android.Support.V4.App.Fragment, AdapterView.IOnItemSelectedListener
    {
        public const string TAG = "ElevationFragment";
        private static int ELEVATION_STEP = 40;
        internal Outline mOutline;
        CircleOutlineProvider circleProvider;
        RectOutlineProvider rectProvider;
        View floatingShape;
        private float mElevation = 0;
        const string ARG_PAGE = "ARG_PAGE";
        private int mPage;
        private Question question;

        internal static ElevationDragFragment newInstance(int page, Question item)
        {
            var args = new Bundle();
            args.PutInt(ARG_PAGE, page);
            var fragment = new ElevationDragFragment();
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
            var rootView = inflater.Inflate(Resource.Layout.ztranslation, container, false);

            floatingShape = rootView.FindViewById(Resource.Id.circle);
            ImageView questionImage = rootView.FindViewById<ImageView>(Resource.Id.questionImage);


            mOutline = new Outline();

            circleProvider = new CircleOutlineProvider();
            circleProvider.GetOutline(floatingShape, mOutline);

            try
            {
                int resourceId = Resources.GetIdentifier(question.ImageKey.ToString(), "drawable", this.Activity.PackageName);                
                questionImage.SetImageResource(resourceId);
            }
            catch (Java.IO.IOException ex)
            {

            }

            floatingShape.ClipToOutline = true;
            rectProvider = new RectOutlineProvider();
            rectProvider.GetOutline(floatingShape, mOutline);
            floatingShape.OutlineProvider = circleProvider;
            floatingShape.ClipToOutline = true;
            var questionName = rootView.FindViewById<TextView>(Resource.Id.questionName);
            var answer1 = rootView.FindViewById<Button>(Resource.Id.raise_bt);
            var answer2 = rootView.FindViewById<Button>(Resource.Id.lower_bt);
            var overlay = rootView.FindViewById<LinearLayout>(Resource.Id.overlay_game);
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
            }
             
            var dragLayout = rootView.FindViewById<DragFrameLayout>(Resource.Id.main_layout);
            dragLayout.SetGoodAnswer(question.AnswerGood);
            dragLayout.SetButton(answer1, answer2, answer1);
            dragLayout.mDragFrameLayoutController = new DragFrameLayoutController((bool captured) => {
                if (captured)
                {
                    question.Resolved = 1;
                    this.FragmentManager.BeginTransaction().Detach(this).Attach(this).Commit();
                    ((GameActivity) Activity).swipeRight(mPage);

                }
                else
                {
                    floatingShape.Animate()
                    .TranslationZ(captured ? 50 : 0)
                    .SetDuration(100);
                }
                
               
            });

            dragLayout.AddDragView(floatingShape);

            rootView.FindViewById(Resource.Id.raise_bt).Click += delegate {
                mElevation += ELEVATION_STEP;
               
                floatingShape.Elevation = mElevation;
            };

            rootView.FindViewById(Resource.Id.lower_bt).Click += delegate {
                mElevation = Math.Max(mElevation - ELEVATION_STEP, 0);
                
                floatingShape.Elevation = mElevation;
            };

            return rootView;
        }

        public void OnItemSelected(AdapterView parent, View view, int position, long id)
        {
            /* Set the corresponding Outline to the shape. */

            switch (position)
            {
                case 0:
                    floatingShape.OutlineProvider = circleProvider;
                    floatingShape.ClipToOutline = true;
                    break;
                case 1:
                    floatingShape.OutlineProvider = rectProvider;
                    floatingShape.Invalidate();
                    floatingShape.ClipToOutline = true;
                    break;
                default:
                    floatingShape.OutlineProvider = circleProvider;
                    /* Don't clip the view to the outline in the last case. */
                    floatingShape.ClipToOutline = false;
                    break;
            }
        }

        public void OnNothingSelected(AdapterView parent)
        {
            floatingShape.OutlineProvider = circleProvider;
        }

        private class RectOutlineProvider : ViewOutlineProvider
        {
            public override void GetOutline(View view, Outline outline)
            {
                int shapeSize = view.Resources.GetDimensionPixelSize(Resource.Dimension.shape_size);
                outline.SetRoundRect(0, 0, shapeSize, shapeSize, shapeSize / 10);
            }
        }

        private class CircleOutlineProvider : ViewOutlineProvider
        {
            public override void GetOutline(View view, Outline outline)
            {
                int shapeSize = view.Resources.GetDimensionPixelSize(Resource.Dimension.shape_size);
                outline.SetRoundRect(0, 0, shapeSize, shapeSize, shapeSize / 2);
            }
        }


    }

}