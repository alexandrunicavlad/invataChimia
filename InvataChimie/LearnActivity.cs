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
    [Activity(Label = "LearnActivity")]
    public class LearnActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.learn_layout);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "Capitole";
            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            var listView = (ListView)FindViewById<ListView>(Resource.Id.listView);
            var listOfCap = new List<Capitol>();
            for(var i = 0; i <= 20; i++)
            {
                var capInit = new Capitol();
                capInit.DisplayName = "Cap " + i.ToString();
                capInit.Id = i;
                capInit.PhotoId = "";
                listOfCap.Add(capInit);
            }
            var adapter = new LearnListAdapter(this, listOfCap);
            listView.SetAdapter(adapter);
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