
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
	[Activity (Label = "RatingDialog")]			
	public class RatingDialog : DialogFragment
	{
		public int _selecteditem;
		public TextView _tvTitel;
		public RatingBar _rbRating;
		public Button _btUitgebreid;
		public Button _btOpslaan;
		public event EventHandler<ZuydApp.Register> _onSignUpComplete;
		private List<ZuydApp.VakJSON> _alleVakken;
		public Context context;

		public RatingDialog(int position,List<VakJSON> listvakken)
		{
			this._selecteditem = position;
			_alleVakken = listvakken;
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView(inflater, container, savedInstanceState);

			var view = inflater.Inflate(Resource.Layout.RatingDialog, container, false);

			_tvTitel = view.FindViewById<TextView> (Resource.Id.tv_TitelRatingDialog);
			_rbRating = view.FindViewById<RatingBar> (Resource.Id.rb_RatingDialog);
			_btUitgebreid = view.FindViewById<Button> (Resource.Id.btn_VakBeoordelenRatingDialog);
			_btOpslaan = view.FindViewById<Button> (Resource.Id.btnOpslaanRatingDialog);

			_btOpslaan.Click += (object sender, EventArgs e) => {
				RatingAPI();
				Intent intent = new Intent(context, typeof(EigenVakken));
				StartActivity(intent);
			};
			_btUitgebreid.Click += (object sender, EventArgs e) => {
				Intent intent = new Intent(context, typeof(UitgebreidActivity));
				StartActivity(intent);
			};

			_tvTitel.Text = _alleVakken [_selecteditem].Titel;
			_rbRating.Rating = _alleVakken [_selecteditem].Rating;

			return view;
		}

		async void RatingAPI()
		{
			bool x = await Beoordeling.RatingBeoordelen(_alleVakken[_selecteditem].Id,(int)_rbRating.Rating);
		}

		public override void OnActivityCreated(Bundle savedInstanceState)
		{
			Dialog.Window.RequestFeature(WindowFeatures.NoTitle); //Sets the title bar to invisible
			base.OnActivityCreated(savedInstanceState);
			Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation; //set the animation
		}
	}
}

