using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using lexiboom.ViewModel.ListofWordsViewModel;

using Xamarin.Forms;

namespace lexiboom.View.ListofWords
{
	public partial class ListofWords : ContentPage
	{
        public static MotherTongeWords MotherTongeWords;
		public ListofWords ()
		{
            MotherTongeWords = new MotherTongeWords();

			InitializeComponent ();
		}

        async void OnAddClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListofWordsAddWord());
        }
	}
}
