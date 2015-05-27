using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading;

namespace ZuydApp.Droid
{
	[Activity (Label = "ZuydApp.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : Activity
	{
		
		private Button _btnLogIn;
		private Button _btnRegister;
		private ProgressBar _progressBar;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Login);

			_btnLogIn = FindViewById<Button>(Resource.Id.BtnLoginLogin);
			_btnRegister = FindViewById<Button>(Resource.Id.BtnRegisterLogin);
			_progressBar = FindViewById<ProgressBar>(Resource.Id.PgbLogin);

			_btnRegister.Click += _btnRegister_Click;
			_btnLogIn.Click += _btnLogIn_Click;
			//_btnSignIn.Click += _btnSignIn_Click;
		}

		void _btnLogIn_Click (object sender, EventArgs e)
		{
			Thread.Sleep(3000);
			StartActivity(typeof(MenuScreen));
		}

		void _btnRegister_Click (object sender, EventArgs e)
		{
			FragmentTransaction transaction = FragmentManager.BeginTransaction();
			RegisterDialog signUpDiaglog = new RegisterDialog();
			signUpDiaglog.Show(transaction, "dialog fragment");

			signUpDiaglog._onSignUpComplete += SignUpDiaglog__onSignUpComplete;
		}

		void SignUpDiaglog__onSignUpComplete (object sender, ZuydApp.Register e)
		{
			_progressBar.Visibility = ViewStates.Visible;
			Thread thread = new Thread(ActLikeARequestSignUp);
			thread.Start();
		}

		private void ActLikeARequestSignUp()
		{
			Thread.Sleep(3000);
			RunOnUiThread(() => { _progressBar.Visibility = ViewStates.Invisible; });
			StartActivity(typeof(MenuScreen));
		}
	}
}