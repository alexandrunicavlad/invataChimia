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
    [Activity(Label = "GameActivity")]
    public class GameActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.game_layout);
            if (savedInstanceState == null)
            {
               var transaction = FragmentManager.BeginTransaction();
               var fragment = new ElevationDragFragment();
               transaction.Replace(Resource.Id.sample_content_fragment, fragment);
               transaction.Commit();
            }
        }
    }
}