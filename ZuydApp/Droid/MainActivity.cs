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
		private EditText _etEmail;
		private EditText _etPassword;
		private CheckBox _cbRemember;
		private Button _btnLogIn;
		private Button _btnRegister;
		private ProgressBar _progressBar;

		protected override void OnCreate(Bundle bundle)
		{
			LoginRepository lr = new LoginRepository ();
			//Login loginFromSQLite = lr.GetAllUsers ();
			if (!lr.ExistDatabase()) {
				StartActivity(typeof(MenuScreen));				
			}
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Login);

			_btnLogIn = FindViewById<Button>(Resource.Id.BtnLoginLogin);
			_btnRegister = FindViewById<Button>(Resource.Id.BtnRegisterLogin);
			_progressBar = FindViewById<ProgressBar>(Resource.Id.PgbLogin);
			_etEmail = FindViewById<EditText> (Resource.Id.TxtEmailLogin);
			_etPassword = FindViewById<EditText> (Resource.Id.TxtPasswordLogin);
			_cbRemember = FindViewById<CheckBox> (Resource.Id.CbxRemberLogin);

			_btnRegister.Click += _btnRegister_Click;
			_btnLogIn.Click += _btnLogIn_Click;
			//_btdnSignIn.Click += _btnSignIn_Click;
		}

		async void _btnLogIn_Click (object sender, EventArgs e)
		{
			//SqlServer sqlserver = new SqlServer ();
                                			//sqlserver.getConnection ();
			Login login = new Login (_etEmail.Text, _etPassword.Text, _cbRemember.Checked);
			LoginRepository lr = new LoginRepository (login);
			string loginCheck = await login.Fetch ();

			//Login x = lr.GetPassword ();
			//Thread.Sleep(1000);

			if (loginCheck == "true") {
				if (login.propRemember) {
					bool HeeftDatabase = lr.ExistDatabase ();
					if (HeeftDatabase) {

					} else {
						lr.GetConnection ();
					}
				}
				var activityMenuScreen = new Intent (this, typeof(MenuScreen));
				activityMenuScreen.PutExtra ("LoginData", new string[]{ login.propUsername, login.propPassword });
				StartActivity (activityMenuScreen);

			} else if (loginCheck == "Account niet geactiveerd")
			{
				var builder = new AlertDialog.Builder (this);
				builder.SetTitle ("Login Error").SetMessage ("Het account is niet geactiveerd");
				builder.Create ().Show ();
			}else {
				var builder = new AlertDialog.Builder (this);
				builder.SetTitle ("Login Error").SetMessage ("Het inlog scherm is niet correct");
				builder.Create ().Show ();
			}
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
			StartActivity(typeof(MainActivity));
		}
	}
}