﻿using System;
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
			InitializeComponent ();
            BindingContext = App.Storage.listofWordsList;
            languageSelectorPicker.BindingContext = App.MotherTonge;

            if (App.Configuration.LanguagesNameList.Count>=1)
            {
                for (int i = 0; i < App.Configuration.LanguagesNameList.Count; i++)
                    languageSelectorPicker.Items.Add(App.Configuration.LanguagesNameList[i]);
                languageSelectorPicker.IsVisible = true;
                languageSelectorPicker.SelectedIndex = 0;
            }            
		}

        void OnRefresh(object sender, EventArgs args)
        {
            listView.ItemsSource = null;
            Task.Delay(1000);
            listView.ItemsSource = App.Storage.listofWordsList;
            listView.IsRefreshing = false;
        }

        async void OnCardsClicked(object sender, EventArgs args)
        {
            App.CardViewModel.isTranslationVisible = false;
            if (listView.SelectedItem != null)  
                await Navigation.PushAsync(new CardPage((MotherTongeWords)listView.SelectedItem));
            else
                await DisplayAlert("Error", "It seems that no word was selected. Select a one and try again!", "Ok");
        }

        async void OnEditClicked(object sender, EventArgs e)
        {
            if (listView.SelectedItem == null)
            {
                await DisplayAlert("Edit Error", "It seems that no word was selected. Select a one and try again!", "Ok");
            }
            else
            {
                await Navigation.PushAsync(new ListofWordsEditWord(listView.SelectedItem));
            }            
        }

        async void OnAddClicked(object sender, EventArgs e)
        {
            if (App.Configuration.LanguagesNameList.Count >= 1)
            {
                if (languageSelectorPicker.SelectedItem != null)
                    await Navigation.PushAsync(new ListofWordsAddWord(languageSelectorPicker.SelectedIndex));
                else await DisplayAlert("Error", "Please select a language to improve", "Ok");
            }
            else
                await DisplayAlert("No language selected", "It seems that you have not added a language to improve yet. Please go to the \"Configuration\" menu and add at least one Language.", "Ok");            
        }

        async void OnRemoveClicked(object sender, EventArgs e)
        {
            if (listView.SelectedItem == null)
            {
                await DisplayAlert("Error", "No row was selected to be removed, did you miss something?", "Ok");
            }
            else
            {
                bool answer = await DisplayAlert("Remove word?", "Are you sure you want to get rid of this word?", "Yes", "No");
                if (answer)
                {
                    await App.Storage.connection.DeleteAsync(listView.SelectedItem);
                    App.Storage.listofWordsList.Remove((MotherTongeWords)listView.SelectedItem);
                }
            }                        
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
                await Navigation.PushAsync(new ListofWordsEditWord(listView.SelectedItem));
            }
        }

        private void languageSelectorPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView.SelectedItem = null;
            App.Storage.listofWordsList.Clear();
            //if(languageSelectorPicker.SelectedItem!= null)
            Task.Run(async () => await App.Storage.Query(languageSelectorPicker.SelectedItem.ToString()));
        }
    }
}
