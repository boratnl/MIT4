using System;

using Xamarin.Forms;

namespace ZuydApp
{
	public class VakkenPage : ContentPage
	{
		public VakkenPage ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


