﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Android.Support.V4.App;
using InvataChimie.Helpers;

namespace InvataChimie
{
    public class CustomPagerAdapterQuiz : FragmentPagerAdapter
    {
        const int PAGE_COUNT = 2;
        private List<Question> listOfQuestions;
        private string[] tabTitles = { "Tab1", "Tab2" };
        readonly Context context;

        public CustomPagerAdapterQuiz(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        internal CustomPagerAdapterQuiz(Context context, Android.Support.V4.App.FragmentManager fm, List<Question> listOfQuestions) : base(fm)
        {
            this.context = context;
            this.listOfQuestions = listOfQuestions;
        }

        public override int Count
        {
            get { return listOfQuestions.Count; }
        }

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            return QuizFragment.newInstance(position + 1, listOfQuestions[position]);
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            // Generate title based on item position
            return CharSequence.ArrayFromStringArray(tabTitles)[position];
        }


    }
}