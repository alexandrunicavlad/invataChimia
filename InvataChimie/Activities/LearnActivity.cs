using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace InvataChimie
{
    [Activity(Label = "LearnActivity")]
    public class LearnActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.learn_layout);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            toolbar.SetBackgroundColor(Color.ParseColor("#7FB800"));
            SetActionBar(toolbar);
            ActionBar.Title = Resources.GetString(Resource.String.capitole);
            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            var listView = (ListView)FindViewById<ListView>(Resource.Id.listView);
            var listOfCap = new List<Capitol>();
            string[] arrayCap = Resources.GetStringArray(Resource.Array.capTitle);
            for(var i = 0; i < arrayCap.Length; i++)
            {
                var capInit = new Capitol();
                capInit.DisplayName = arrayCap[i];
                capInit.Id = i + 1;                
                capInit.PhotoId = Resources.GetIdentifier("ic_cap" + capInit.Id, "drawable", PackageName);                             
                listOfCap.Add(capInit);
            }
            var adapter = new LearnListAdapter(this, listOfCap);
            listView.Adapter  =  adapter;
            listView.ItemClick += (sender, e) =>
            {
                var cap = listOfCap[e.Position];
                var capIntent = new Intent(this, typeof(LearnPageActivity));
                capIntent.PutExtra("capName", cap.DisplayName);
                capIntent.PutExtra("capId", cap.Id);
                StartActivity(capIntent);
            };
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }

}