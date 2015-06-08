﻿using System;
using Android.Widget;
using System.Collections.Generic;
using Android.Content;
using Android.Views;

namespace ZuydApp.Droid
{
	public class VakkenAdapter : BaseAdapter<VakClass>
	{
		LayoutInflater inflater;
		List<VakClass> classes;


		public VakkenAdapter (Context context, List<VakClass> vakken)
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

		public override VakClass this[int index] {
			get {
				return classes [index];
			}
		}

		public void addItems(VakClass singleVak)
		{
			classes.Add (singleVak);
			NotifyDataSetChanged ();
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			var classItem = classes [position];
			if (convertView == null) {
				convertView = inflater.Inflate (Resource.Layout.ListViewRowVakken, null);
			}
			convertView.FindViewById<TextView> (Resource.Id.tv_TitelMijnVakken).Text = classItem.Naam ;
			convertView.FindViewById<TextView> (Resource.Id.tv_DocentMijnVakken).Text = classItem.Docent;

			return convertView;
		}
	}
}
