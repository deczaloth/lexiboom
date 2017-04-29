using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using lexiboom.ViewModel.ListofWordsViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace lexiboom.View.ListofWords
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CardPage : ContentPage
	{
        int index;
		public CardPage (MotherTongeWords word)
		{
            index = App.Storage.listofWordsList.IndexOf(word);

            BindingContext = App.Storage.listofWordsList;
			InitializeComponent ();

            cardText.Text = App.Storage.listofWordsList[index].Word;
            cardContext.Text = App.Storage.listofWordsList[index].Context;
		}

        void OnButtonNextClicked(object sender, EventArgs args)
        {
            if (index == App.Storage.listofWordsList.Count - 1)
                index = 0;
            else
                index++;
            cardText.Text = App.Storage.listofWordsList[index].Word;
            cardContext.Text = App.Storage.listofWordsList[index].Context;
        }

    }
}
