
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
	[Activity (Label = "Schoolfeedback")]			
	public class Schoolfeedback : Activity
	{
		private Button _btnVerzenden;
		private EditText _edtMessage;
		private string[] _arLogin;

		protected override void OnCreate (Bundle bundle)
		{
			if(Intent.GetStringArrayExtra("LoginData") != null)
				_arLogin = Intent.GetStringArrayExtra ("LoginData");
			else
				_arLogin = new string[]{"MaikelUsername","MaikelPassword"};

			base.OnCreate (bundle);

			SetContentView(Resource.Layout.Schoolfeedback);
			_btnVerzenden = FindViewById<Button> (Resource.Id.btnVerzendenSchoolfeedback);
			_edtMessage = FindViewById<EditText> (Resource.Id.edtMessageSchoolfeedback);
			// Create your application here
			_btnVerzenden.Click += (object sender, EventArgs e) => {
				ZuydApp.Schoolfeedback sf = new ZuydApp.Schoolfeedback(_arLogin[0], _edtMessage.Text);
				sf.SendEmail();
				var activityMenuScreen = new Intent (this, typeof(MenuScreen));
				activityMenuScreen.PutExtra ("LoginData", new string[]{ _arLogin[0], _arLogin[1] });
				StartActivity (activityMenuScreen);
			};
		}
	}
}

