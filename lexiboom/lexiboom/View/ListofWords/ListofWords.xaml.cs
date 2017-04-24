using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using lexiboom.ViewModel.ListofWordsViewModel;

using Xamarin.Forms;

namespace lexiboom.View.ListofWords
{
	public partial class ListofWords : ContentPage
	{
		public ListofWords ()
		{
            BindingContext = App.MotherTonge;
			InitializeComponent ();
		}

        async void OnAddClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListofWordsAddWord());
        }
	}
}
