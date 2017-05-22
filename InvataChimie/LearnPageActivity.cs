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
            SetActionBar(toolbar);
            string text = Intent.GetStringExtra("capName") ?? "Data not available";
            int id = Intent.GetIntExtra("capId", 0);
            ActionBar.Title = text;
            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            var webView = (WebView)FindViewById<WebView>(Resource.Id.webView);
            
            String html = "<html><body>Hello, World!</body></html>";
            String mime = "text/html";
            String encoding = "utf-8";
            webView.Settings.JavaScriptEnabled = true;
            webView.LoadDataWithBaseURL(null, html, mime, encoding, null);
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