using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using lexiboom.ViewModel.ListofWordsViewModel;

using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;

namespace lexiboom.View.ListofWords
{    
	public partial class ListofWords : ContentPage
	{
        bool flag = false;
        int counter = 0;
        public ListofWords ()
		{
            BindingContext = App.MotherTonge;
			InitializeComponent ();
		}

        async void OnAddClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListofWordsAddWord());
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = e.SelectedItem;
        }

        public async void TextCell_Tapped(object sender, EventArgs e)
        {
            counter++;
            await Task.Run(async () =>
            {
                await Task.Delay(500);
                if (counter > 1)
                {
                    counter = 0;
                    flag = true;
                }
                counter = 0;
                });
            if (flag==true)
            {
                flag = false;
                await Navigation.PushAsync(new ListofWordsEditWord());
            }
        }
    }
}
