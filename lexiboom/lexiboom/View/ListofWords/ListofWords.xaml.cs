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
        string palabra="";

        public ListofWords ()
		{
            BindingContext = App.Storage.listofWordsList;
			InitializeComponent ();
		}

        async void OnAddClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListofWordsAddWord());
        }

        public async void TextCell_Tapped(object sender, EventArgs e)
        {
            // My handicraft tapped twice recognizer:
            // Every incoming tap event increces counter by one.
            counter++;
            // Once increced by one, the event enters a different thread to check if 
            // is a second tap on the same TextCell
            await Task.Run(async () =>
            {
                // Here we check if the the cell was tapped more than once and in case it was, if the same TextCell 
                // was tapped more than once. palabra stores the value of the previous tap event.
                if (counter > 1 && palabra == ((TextCell)sender).Text)
                {
                    // If the conditions are sufficed, the variables are reseted, and the navigation flag is turned to true.
                    counter = 0;
                    palabra = "";
                    flag = true;
                }
                // The text tapped in this event is stored.
                palabra = ((TextCell)sender).Text;
                // We await for further tappings before we reset the counter.
                await Task.Delay(300);
                counter = 0;
                palabra = "";
            });
            // If the flag was reached (twice tapped on same textcell)
            if (flag == true)
            {
                // flag reseted.
                flag = false;
                // Push the edition page.
                await Navigation.PushAsync(new ListofWordsEditWord());
            }
        }
    }
}
