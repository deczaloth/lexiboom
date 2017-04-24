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
        static MotherTongeWords MotherTonge;

        public ListofWordsAddWord ()
		{
            MotherTonge = new MotherTongeWords();
			InitializeComponent ();
		}
	}
}
