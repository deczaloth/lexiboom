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
        public CardPage (MotherTongeWords word)
		{
            InitializeComponent();

            ItemsSource = App.Storage.listofWordsList;
        }        
    }
}
