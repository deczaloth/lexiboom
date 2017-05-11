using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using lexiboom.ViewModel.ListofWordsViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace lexiboom.View.ListofWords
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CardPage : CarouselPage
	{
        CardsViewModel CardsViewModel = new CardsViewModel();
        public CardPage (MotherTongeWords word)
		{
            CardsViewModel.isTranslationVisible = false;
            InitializeComponent();
            BindingContext = CardsViewModel;
            ItemsSource = App.Storage.listofWordsList;
        }

        void ShowOrHideWordsTanslations(object sender, EventArgs args)
        {
            //App.CardViewModel.isTranslationVisible = !App.CardViewModel.isTranslationVisible;
        }
    }
}
