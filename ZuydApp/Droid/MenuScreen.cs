
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
	[Activity (Label = "MenuScreen")]			
	public class MenuScreen : Activity
	{
		//string[0] = username
		//string[1] = password
		public string[] _arLogin;
		private TextView _tvUsername;
		
		protected override void OnCreate(Bundle bundle)
		{
			if(Intent.GetStringArrayExtra("LoginData") != null)
				_arLogin = Intent.GetStringArrayExtra ("LoginData");
			else
				_arLogin = new string[]{"MaikelUsername","MaikelPassword"};
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Menu);
			_tvUsername = (TextView)FindViewById (Resource.Id.txtUsernameMenu);
			_tvUsername.Text = _arLogin[0];
		}
	}
}

