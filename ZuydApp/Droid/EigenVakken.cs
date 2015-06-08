
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
using ZuydApp;

namespace ZuydApp.Droid
{
	[Activity (Label = "EigenVakken")]			
	public class EigenVakken : Activity
	{
		VakkenAdapter adapter;
		List<VakClass> _mijnvakkenadapter;
		private ListView _lvVakken;
		private string[] _arLogin;

		protected override void OnCreate (Bundle bundle)
		{
			if(Intent.GetStringArrayExtra("LoginData") != null)
				_arLogin = Intent.GetStringArrayExtra ("LoginData");
			else
				_arLogin = new string[]{"MaikelUsername","MaikelPassword"};

			base.OnCreate (bundle);

			SetContentView(Resource.Layout.MijnVakken);
			_lvVakken = FindViewById<ListView>(Resource.Id.lv_Vakken);
			var vakken = VakkenAPI.Fetch ();
			// Create your application here

			_mijnvakkenadapter = MijnVakkenAdapter.getMijnVakken ();
			adapter = new VakkenAdapter (this, _mijnvakkenadapter);
			_lvVakken.Adapter = adapter;

		}
	}
}

