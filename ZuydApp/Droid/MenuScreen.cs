﻿
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
using Android.Support.V7;
using SupportToolbar = Android.Support.V7.Widget.Toolbar; 

namespace ZuydApp.Droid
{
	[Activity (Label = "MenuScreen")]			
	public class MenuScreen : Activity
	{
		//string[0] = username
		//string[1] = password
		public string[] _arLogin;
		private TextView _tvUsername;
		private Button _btnSchoolFeedback;
		//private SupportToolbar mToolbar;
		
		protected override void OnCreate(Bundle bundle)
		{
		  	if(Intent.GetStringArrayExtra("LoginData") != null)
				_arLogin = Intent.GetStringArrayExtra ("LoginData");
			else
				_arLogin = new string[]{"MaikelUsername","MaikelPassword"};
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.Menu);
			//mToolbar = FindViewById<SupportToolbar> (Resource.Id.toolbar);
			//mToolbar.InflateMenu (Resource.Menu.toolbar_menu);
			_btnSchoolFeedback = (Button)FindViewById(Resource.Id.btnSchoolFeedbackMenu);
			_tvUsername = (TextView)FindViewById (Resource.Id.txtUsernameMenu);
			//_tvUsername.Text = _arLogin[0];
			_tvUsername.Text = "ddd";
			_btnSchoolFeedback.Click += (object sender, EventArgs e) => {
				var activitySchoolFeedback = new Intent (this, typeof(Schoolfeedback));
				activitySchoolFeedback.PutExtra ("LoginData", new string[]{ _arLogin[0], _arLogin[1] });
				StartActivity (activitySchoolFeedback);
			};
		}


		 
		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			return base.OnCreateOptionsMenu (menu);
		}
	}
}