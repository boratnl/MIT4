
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
		private EditText _txtEmail;
		private EditText _txtPassword1;
		private EditText _txtPassword2;
		private Button _btnSignUp;
		public event EventHandler<ZuydApp.Register> _onSignUpComplete;


		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView(inflater, container, savedInstanceState);

			var view = inflater.Inflate(Resource.Layout.Register, container, false);

			_txtEmail = view.FindViewById<EditText>(Resource.Id.txtEmailRegister);
			_txtPassword1 = view.FindViewById<EditText>(Resource.Id.txtPassword1Register);
			_txtPassword2 = view.FindViewById<EditText>(Resource.Id.txtPassword2Register);
			_btnSignUp = view.FindViewById<Button>(Resource.Id.btnCreateRegister);

			_btnSignUp.Click += BtnSignUp_Click;

			return view;
		}

		void BtnSignUp_Click(object sender, EventArgs e)
		{
			if (_txtPassword1.Text == _txtPassword2.Text) {
				_onSignUpComplete.Invoke (this, new ZuydApp.Register (_txtEmail.Text, _txtPassword1.Text));
				this.Dismiss ();
			} else {
				/*var builder = new AlertDialog.Builder (this);
				builder.SetTitle ("Hello Dialog")
					.SetMessage ("Is this material design?")
					.SetPositiveButton ("Yes", delegate { Console.WriteLine("Yes"); })
					.SetNegativeButton ("No", delegate { Console.WriteLine("No"); });
				builder.Create().Show ();*/
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