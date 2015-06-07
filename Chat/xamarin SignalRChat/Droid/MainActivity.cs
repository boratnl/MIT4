using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Views.InputMethods;
using Android.Widget;
using SignalRChat;
using Android.Content.PM;
using Microsoft.AspNet.SignalR.Client;

namespace SignalRChat.Droid
{
	[Activity (Label = "SignalRChat.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : Activity
	{
		protected override async void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.Main);

			var messageListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, new List<string>());
			var messageList = FindViewById<ListView>(Resource.Id.Messages);
			messageList.Adapter = messageListAdapter;

			var hubConnection = new HubConnection ("http://192.168.1.42:8080");
			var hubProxy = hubConnection.CreateHubProxy ("MyHub");
			hubProxy.On<string>("UpdateChatMessage", message2 => 
				messageList.Text += string.Format("Received Msg: {0}\r\n", message2));
			//var client = new Client("Android");

			var sendMessage = FindViewById<Button>(Resource.Id.SendMessage);
			var message = FindViewById<EditText>(Resource.Id.Input);

			sendMessage.Click += delegate
			{
				if (!string.IsNullOrWhiteSpace(message.Text))
				{
					hubConnection.Send("Android: " + message.Text);

					RunOnUiThread(() => message.Text = "");
				}
			};
				
			await hubConnection.Start ().ContinueWith (task => hubConnection.Send ("Android: connected"));;
		}
	}
}

