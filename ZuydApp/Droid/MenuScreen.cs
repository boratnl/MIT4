
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
	[Activity (Label = "MenuScreen", ScreenOrientation=Android.Content.PM.ScreenOrientation.Portrait)]			
	public class MenuScreen : Activity
	{
		//string[0] = username
		//string[1] = password
		public string[] _arLogin;
		private TextView _tvUsername;
		private Button _btnSchoolFeedback;
		private Button _btnMijnSchoolvakken;
		private Button _btnMijnChatrooms;
		//private SupportToolbar mToolbar;
		
		protected override void OnCreate(Bundle bundle)
		{
		  	if(Intent.GetStringArrayExtra("LoginData") != null)
				_arLogin = Intent.GetStringArrayExtra ("LoginData");
			else
				_arLogin = new string[]{"MaikelUsername","MaikelPassword"};
			base.OnCreate(bundle);
			string x = UserSingleton.Instance.username;
			SetContentView(Resource.Layout.Menu);
			//mToolbar = FindViewById<SupportToolbar> (Resource.Id.toolbar);
			//mToolbar.InflateMenu (Resource.Menu.toolbar_menu);
			_btnSchoolFeedback = (Button)FindViewById(Resource.Id.btnSchoolFeedbackMenu);
			_btnMijnSchoolvakken = (Button)FindViewById (Resource.Id.btnMijnVakken);
			_btnMijnChatrooms = (Button)FindViewById (Resource.Id.btnMijnChatrooms);
			_tvUsername = (TextView)FindViewById (Resource.Id.txtUsernameMenu);
			//_tvUsername.Text = _arLogin[0];
			_tvUsername.Text = UserSingleton.Instance.username;
			_btnSchoolFeedback.Click += (object sender, EventArgs e) => {
				var activityMijnVakken = new Intent (this, typeof(Schoolfeedback));
				activityMijnVakken.PutExtra ("LoginData", new string[]{ _arLogin[0], _arLogin[1] });
				StartActivity (activityMijnVakken);
			};
			_btnMijnSchoolvakken.Click += (object sender, EventArgs e) => {
				var activitySchoolFeedback = new Intent (this, typeof(EigenVakken));
				activitySchoolFeedback.PutExtra ("LoginData", new string[]{ _arLogin[0], _arLogin[1] });
				StartActivity (activitySchoolFeedback);
			};
			_btnMijnChatrooms.Click += (object sender, EventArgs e) => {
				var activityMijnChatroom = new Intent (this, typeof(MijnChatroomsActivity));				
				StartActivity(activityMijnChatroom);
			};
		}
			
		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			MenuInflater.Inflate (Resource.Menu.menuActionBar, menu);
			return base.OnCreateOptionsMenu (menu);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			base.OnOptionsItemSelected (item);
			switch(item.ItemId){
			case Resource.Id.abLogOut:
				new LogOut().LogoutDatabase();
				StartActivity (typeof(MainActivity));
				break;
			}
			return true;
		}
	}
}