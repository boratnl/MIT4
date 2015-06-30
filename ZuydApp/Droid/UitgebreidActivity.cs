
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
	[Activity (Label = "Uitgebreide beoordeling", ScreenOrientation=Android.Content.PM.ScreenOrientation.Portrait)]			
	public class UitgebreidActivity : Activity
	{
		EditText et_Docent;
		EditText et_Lokaal;
		EditText et_InhoudelijkNiveau;
		EditText et_Totaletijd;
		EditText et_Voorkennis;
		Button bt_Opslaan;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Uitgebreid);

			et_Docent = (EditText)FindViewById (Resource.Id.edtDocentUitgebreid);
			et_Lokaal = (EditText)FindViewById (Resource.Id.edtLokalenUitgebreid);
			et_InhoudelijkNiveau = (EditText)FindViewById (Resource.Id.edtNiveauUitgebreid);
			et_Totaletijd = (EditText)FindViewById (Resource.Id.edtTijdUitgebreid);
			et_Voorkennis = (EditText)FindViewById (Resource.Id.edtVoorkennisUitgebreid);
			bt_Opslaan = (Button)FindViewById (Resource.Id.btn_OpslaanUitgebreid);

			GetUitgebreideBeoordeling ();

			bt_Opslaan.Click += async (object sender, EventArgs e) => {
				BeoordelenAPI();
				Intent intent = new Intent(this, typeof(MenuScreen));
				StartActivity(intent);
			};

			// Create your application here
		}


		async void BeoordelenAPI()
		{
			bool x = await Beoordeling.UitgebreidBeoordelen(VakSingleton.Instance.vakid, et_Docent.Text, et_Lokaal.Text, et_Voorkennis.Text, et_Totaletijd.Text,et_InhoudelijkNiveau.Text);
		}

		async void GetUitgebreideBeoordeling()
		{
			string[] x = await Beoordeling.getUitgebreideBeoordeling (VakSingleton.Instance.vakid);
			et_Docent.Text = x [1];
			et_Lokaal.Text = x [0];
			et_Totaletijd.Text = x [3];
			et_Voorkennis.Text = x [2];
			et_InhoudelijkNiveau.Text = x [4];
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

