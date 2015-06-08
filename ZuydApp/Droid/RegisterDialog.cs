
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
	[Activity (Label = "Register")]			
	public class RegisterDialog : DialogFragment
	{
		private TextView _txtError;
		private EditText _txtUsername;
		private EditText _txtEmail;
		private EditText _txtPassword1;
		private EditText _txtPassword2;
		private Button _btnSignUp;
		public event EventHandler<ZuydApp.Register> _onSignUpComplete;


		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView(inflater, container, savedInstanceState);

			var view = inflater.Inflate(Resource.Layout.Register, container, false);

			_txtError = view.FindViewById<TextView> (Resource.Id.txtErrorRegister);
			_txtUsername = view.FindViewById<EditText> (Resource.Id.txtUsernameRegister);
			_txtEmail = view.FindViewById<EditText>(Resource.Id.txtEmailRegister);
			_txtPassword1 = view.FindViewById<EditText>(Resource.Id.txtPassword1Register);
			_txtPassword2 = view.FindViewById<EditText>(Resource.Id.txtPassword2Register);
			_btnSignUp = view.FindViewById<Button>(Resource.Id.btnCreateRegister);

			_btnSignUp.Click += BtnSignUp_Click;

			return view;
		}

		async void BtnSignUp_Click(object sender, EventArgs e)
		{
			Register register = new Register (_txtUsername.Text, _txtEmail.Text, _txtPassword1.Text);
			if (_txtPassword1.Text == _txtPassword2.Text) {
				if (_txtEmail.Text.EndsWith ("@zuyd.nl")) {
					_onSignUpComplete.Invoke (this, register);
					string registerError = await register.InsertUserInDatabase ();
					if (registerError.Length > 0 && registerError == "false") {
						_txtError.Text = registerError;
					} else {
						_txtError.Text = "succesvol";
						//Toast.MakeText (this,"Het account is geregistreerd activeer het via de mail",ToastLength.Long).Show();

						/*var activityMenuScreen = new Intent (this, typeof(MenuScreen));
					activityMenuScreen.PutExtra ("LoginData", new string[]{ register.propUsername, register.propPassword });
					StartActivity (activityMenuScreen);*/

					}
					this.Dismiss ();
				} else {
					_txtError.Text = "Het email adres moet een Zuyd email adres zijn.";
				}
			} else {
				_txtError.Text = "De wachtwoorden komen niet overeen.";
			}
		}

		public override void OnActivityCreated(Bundle savedInstanceState)
		{
			Dialog.Window.RequestFeature(WindowFeatures.NoTitle); //Sets the title bar to invisible
			base.OnActivityCreated(savedInstanceState);
			Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation; //set the animation
		}
	}
}