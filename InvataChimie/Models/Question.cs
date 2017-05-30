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

namespace InvataChimie
{
    class Question
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AnswerGood { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string ImageKey { get; set; }

        public int Resolved { get; set; }

    }
}