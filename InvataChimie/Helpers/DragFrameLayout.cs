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
using Android.Util;
using Android.Support.V4.Widget;
using Android.Graphics;

namespace InvataChimie
{    
    class DragFrameLayout : FrameLayout
    {
        internal IList<View> mDragViews;

        public Button _answer1;
        public Button _answer2;
        public Button _answer3;
        public string goodAnswer;
        /**
	     * The {@link DragFrameLayoutController} that will be notify on drag.
	     */
        internal DragFrameLayoutController mDragFrameLayoutController;

        private ViewDragHelper mDragHelper;

        public DragFrameLayout(Context context) :
            base(context)
        {
            Initialize();
        }

        public DragFrameLayout(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
            Initialize();
        }

        public DragFrameLayout(Context context, IAttributeSet attrs, int defStyle) :
            base(context, attrs, defStyle)
        {
            Initialize();
        }

        void Initialize()
        {
            mDragViews = new List<View>();

            /**
	         * Create the {@link ViewDragHelper} and set its callback.
	         */
            mDragHelper = ViewDragHelper.Create(this, 1.0f, new Callbacks(this));
        }        

        public override bool OnInterceptTouchEvent(MotionEvent ev)
        {
            var action = ev.Action;
            if (action == MotionEventActions.Cancel || action == MotionEventActions.Up)
            {
                mDragHelper.Cancel();
                return false;
            }
            return mDragHelper.ShouldInterceptTouchEvent(ev);
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            mDragHelper.ProcessTouchEvent(e);
            return true;
        }

        public void AddDragView(View dragView)
        {
            mDragViews.Add(dragView);
        }

        internal void SetButton(Button answer1, Button answer2, Button answer3)
        {
            _answer1 = answer1;
            _answer2 = answer2;
            _answer3 = answer3;
        }

        internal void SetGoodAnswer(string good)
        {
            goodAnswer = good;
        }


    }

    internal class Callbacks : ViewDragHelper.Callback
    {
        private DragFrameLayout owner;
        private Boolean validate = false;

        public Callbacks(DragFrameLayout owner)
        {
            this.owner = owner;           
        }

        public override bool TryCaptureView(View child, int pointerId)
        {
            return owner.mDragViews.Contains(child);
        }

        public override void OnViewPositionChanged(View changedView, int left, int top, int dx, int dy)
        {
            View goodView;
            if (owner.goodAnswer.Equals("1")) {
                goodView = owner._answer1;
            } else if (owner.goodAnswer.Equals("2")) {
                goodView = owner._answer2;
            } else {
                goodView = owner._answer3;
            }

            Boolean a = IsViewOverLapping(goodView, changedView);
            if (a)
            {
                if (!validate)
                {                     
                AlertDialog.Builder alert = new AlertDialog.Builder(owner.Context);
                alert.SetTitle("Felicitari");
                alert.SetPositiveButton("Next", (senderAlert, args) => {
                    Toast.MakeText(owner.Context, "Next", ToastLength.Short).Show();
                });
                Dialog dialog = alert.Create();                
                dialog.Show();
                validate = true;
                }

            }
            else
            {
                base.OnViewPositionChanged(changedView, left, top, dx, dy);
                validate = false;
            }
        }

        private Boolean IsViewOverLapping(View firstView, View secondView)
        {
            int[] firstPosition = new int[2];
            int[] secondPosition = new int[2];
            firstView.GetLocationOnScreen(firstPosition);
            secondView.GetLocationOnScreen(secondPosition);
            Rect rectFirstView = new Rect(firstPosition[0], firstPosition[1], firstPosition[0] + firstView.MeasuredWidth, firstPosition[1] + firstView.MeasuredHeight);
            Rect rectSecondView = new Rect(secondPosition[0], secondPosition[1], secondPosition[0] + secondView.MeasuredWidth, secondPosition[1] + secondView.MeasuredHeight);
            return rectFirstView.Intersect(rectSecondView);
        }

        public override int ClampViewPositionHorizontal(View child, int left, int dx)
        {
            return left;
        }

        public override int ClampViewPositionVertical(View child, int top, int dy)
        {
            return top;
        }

        public override void OnViewCaptured(View capturedChild, int activePointerId)
        {
            base.OnViewCaptured(capturedChild, activePointerId);
            if (owner.mDragFrameLayoutController != null)
                owner.mDragFrameLayoutController.OnDragDrop(false);
        }
    }

    public class DragFrameLayoutController
    {
        private Action<bool> action;
        public DragFrameLayoutController(Action<bool> action)
        {
            this.action = action;
        }
        public virtual void OnDragDrop(bool captured)
        {
            action.Invoke(captured);
        }
    }

}