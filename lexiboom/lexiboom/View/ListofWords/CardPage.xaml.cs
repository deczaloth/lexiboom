using lexiboom.ViewModel.ListofWordsViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace lexiboom.View.ListofWords
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CardPage : CarouselPage
	{
        public CardPage (MotherTongeWords word)
		{
            InitializeComponent();

            ItemsSource = App.Storage.listofWordsList;
            SelectedItem = word;
        }
    }
}
