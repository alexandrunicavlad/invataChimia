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
    class LearnListAdapter : BaseAdapter
    {
        Activity context;
        List<Capitol> _capList;

        public LearnListAdapter (Activity activity, List<Capitol> capList)
        {
            context = activity;
            _capList = capList;
        }

        public override int Count
        {
            get
            {
                return _capList.Count; 
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var elem = _capList[position];
            var view = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.cap_row, parent, false);
            var capName = (TextView)view.FindViewById<TextView>(Resource.Id.CapName);
            var capImage = (ImageView)view.FindViewById<ImageView>(Resource.Id.CapImage);
            capName.Text = elem.DisplayName;
            capImage.SetImageResource(elem.PhotoId);
            return view;
        }
    }
    
}