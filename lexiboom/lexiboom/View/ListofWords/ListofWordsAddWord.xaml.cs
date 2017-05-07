using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lexiboom.ViewModel.ListofWordsViewModel;
using Xamarin.Forms;

namespace lexiboom.View.ListofWords
{
	public partial class ListofWordsAddWord : ContentPage
	{
        public static MotherTongeWords MotherTongue;

        public ListofWordsAddWord (int indexOfThisLanguageInListOfLanguages)
		{
            
            MotherTongue = new MotherTongeWords();
			InitializeComponent ();
            MotherTongue.Type = App.Configuration.LanguageList[indexOfThisLanguageInListOfLanguages];
		}

        async void SearchWordTranslation(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new TranslatorWebSite(WordEntry.Text));
        }
        async void SearchContextTranslation(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new TranslatorWebSite(ContextEntry.Text));
        }

}
}
