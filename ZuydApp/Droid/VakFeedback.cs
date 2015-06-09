
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

namespace ZuydApp.Droid
{
	[Activity (Label = "VakFeedback")]			
	public class VakFeedback : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.ListViewRowVakken);

			FindViewById<TextView> (Resource.Id.tv_TitelMijnVakken).Text = "ClassName";
			FindViewById<TextView> (Resource.Id.tv_DocentMijnVakken).Text = "Docent";

			Title = "VakName";

			// Create your application here
		}
	}
}

