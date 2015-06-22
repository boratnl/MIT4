using System;
using Android.Widget;
using System.Collections.Generic;
using Android.Content;
using Android.Views;

namespace ZuydApp.Droid
{
	public class VakkenAdapter : BaseAdapter<VakJSON>
	{
		LayoutInflater inflater;
		List<VakJSON> classes;

		public VakkenAdapter (Context context, List<VakJSON> vakken)
		{
			this.inflater = LayoutInflater.From (context);
			this.classes = vakken;			
		}

		public override int Count {
			get {
				return classes.Count;
			}
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override VakJSON this[int index] {
			get {
				return classes [index];
			}
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			var classItem = classes [position];
			if (convertView == null) {
				convertView = inflater.Inflate (Resource.Layout.ListViewRowVakken, null);
			}
			convertView.FindViewById<TextView> (Resource.Id.tv_TitelMijnVakken).Text = classItem.Titel ;
			convertView.FindViewById<TextView> (Resource.Id.tv_DocentMijnVakken).Text = classItem.Docent;
			if (classItem.Rating == -1) {
				classItem.Rating = 0;
			}
			convertView.FindViewById<RatingBar> (Resource.Id.ratingBar1).Rating = classItem.Rating;
			convertView.FindViewById<RatingBar> (Resource.Id.ratingBar1).IsIndicator = true;

			return convertView;
		}
	}
}