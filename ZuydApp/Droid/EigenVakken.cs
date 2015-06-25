
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
using ZuydApp;
using System.Threading;
using System.Threading.Tasks;

namespace ZuydApp.Droid
{
	[Activity (Label = "EigenVakken", ScreenOrientation=Android.Content.PM.ScreenOrientation.Portrait)]			
	public class EigenVakken : Activity
	{
		VakkenAdapter adapter;
		List<VakJSON> listVakken;
		private ListView _lvVakken;
		private TextView _tvFooter;
	
		private string[] _arLogin;
		public Button _btnLaad;

		protected override void OnCreate (Bundle bundle)
		{
			//var vakken = VakkenAPI.Fetch ();

			if(Intent.GetStringArrayExtra("LoginData") != null)
				_arLogin = Intent.GetStringArrayExtra ("LoginData");
			else
				_arLogin = new string[]{"MaikelUsername","MaikelPassword"};

			base.OnCreate (bundle);

			callAPI ();
			//listVakken.Result [0].Afkorting;


			SetContentView(Resource.Layout.MijnVakken);
			_lvVakken = FindViewById<ListView>(Resource.Id.lv_Vakken);
			_tvFooter = FindViewById<TextView> (Resource.Id.tv_footerVakken);
			_tvFooter.Text = "5 sterren = Heel goed" +
				"\n4 sterren = Voldoende" +
				"\n3 sterren = Matig" +
				"\n2 sterren = Onvoldoende" +
				"\n1 ster       = Ruim onvoldoende";
			//_btnLaad = FindViewById<Button> (Resource.Id.btn_OpslaanMijnVakken);
			/*_btnLaad.Click += async (object sender, EventArgs e) => {
				List<VakJSON> listVakken = await VakkenAPI.Fetch ();
				VakkenAdapter va = new VakkenAdapter(this, listVakken);
				_lvVakken.Adapter = va;
			};*/
			_lvVakken.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
				var selectedVak = adapter.GetItem(e.Position);
				/*Intent showVak = new Intent(this, typeof(VakFeedback));
				StartActivity(showVak);*/
				//Get our item from the list adapter

				NewActivity(e.Position);

				//Toast.MakeText(this, e.Position.ToString(), ToastLength.Short).Show();
			};
			// Create your application here

			//_mijnvakkenadapter = MijnVakkenAdapter.getMijnVakken ();
			//adapter = new VakkenAdapter (this, _mijnvakkenadapter);

		}

		async void callAPI() {
			listVakken = await VakkenAPI.Fetch ();
			adapter = new VakkenAdapter(this, listVakken);
			_lvVakken.Adapter = adapter;
		}

		void NewActivity (int ePosition)
		{
			FragmentTransaction transaction = FragmentManager.BeginTransaction();
			RatingDialog signUpDiaglog = new RatingDialog(ePosition, listVakken);

			signUpDiaglog.context = this;

			signUpDiaglog.Show(transaction, "dialog fragment");

			signUpDiaglog._onSignUpComplete += SignUpDiaglog__onSignUpComplete;
		}

		void SignUpDiaglog__onSignUpComplete (object sender, ZuydApp.Register e)
		{
			Thread thread = new Thread(ActLikeARequestSignUp);
			thread.Start();
		}

		private void ActLikeARequestSignUp()
		{
			Thread.Sleep(3000);
			StartActivity(typeof(RatingDialog));
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