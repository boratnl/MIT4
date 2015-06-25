
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
	[Activity (Label = "MijnChatroomsActivity", ScreenOrientation=Android.Content.PM.ScreenOrientation.Portrait)]			
	public class MijnChatroomsActivity : Activity
	{
		Button btn_MIT3;
		Button btn_MIT4;
		Button btn_PIT4;
		TextView tv_username;
		LinearLayout layout;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView(Resource.Layout.Chatrooms);
			//deze is fout
			layout = FindViewById<LinearLayout> (Resource.Id.LayoutChatrooms);
			btn_MIT3 = FindViewById<Button> (Resource.Id.btnVak2MijnChatroom);
			btn_MIT4 = FindViewById<Button> (Resource.Id.btnVak1MijnChatroom);
			btn_PIT4 = FindViewById<Button> (Resource.Id.btnVak3MijnChatroom);
			tv_username = FindViewById<TextView> (Resource.Id.txtUsernameChatrooms);
			tv_username.Text = UserSingleton.Instance.username;
			btn_MIT3.Click += (object sender, EventArgs e) => {
				var uri = Android.Net.Uri.Parse("http://mit4signalr.azurewebsites.net/home/room1?name="+UserSingleton.Instance.username);
				var intent = new Intent (Intent.ActionView, uri);
				StartActivity(intent);
			};
			btn_MIT4.Click += (object sender, EventArgs e) => {
				var uri = Android.Net.Uri.Parse("http://mit4signalr.azurewebsites.net/home/room2?name="+UserSingleton.Instance.username);
				var intent = new Intent (Intent.ActionView, uri);
				StartActivity(intent);
			};
			btn_PIT4.Click += (object sender, EventArgs e) => {
				var uri = Android.Net.Uri.Parse("http://mit4signalr.azurewebsites.net/home/room3?name="+UserSingleton.Instance.username);
				var intent = new Intent (Intent.ActionView, uri);
				StartActivity(intent);
			};

			// Create your application here
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

 