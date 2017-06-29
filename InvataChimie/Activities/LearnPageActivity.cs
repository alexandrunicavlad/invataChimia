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
using Android.Webkit;
using Android.Graphics;

namespace InvataChimie
{
    [Activity(Label = "LearnPageActivity")]
    public class LearnPageActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.cap_details_layout);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            toolbar.SetBackgroundColor(Color.ParseColor("#7FB800"));
            SetActionBar(toolbar);
            string text = Intent.GetStringExtra("capName") ?? "Data not available";
            int id = Intent.GetIntExtra("capId", 0) ;
            ActionBar.Title = text;
            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            var webView = (WebView)FindViewById<WebView>(Resource.Id.webView);

            string capId = "cap" + id ;
            //string html = Resources.GetString(Resources.GetIdentifier(capId, "string", PackageName));
            //String mime = "text/html";
            //String encoding = "utf-8";
            webView.Settings.JavaScriptEnabled = true;
            webView.LoadUrl("file:///android_asset/" + capId.ToUpper() + ".html");
            //webView.LoadDataWithBaseURL(null, mime, encoding, null);
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