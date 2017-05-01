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

        public ListofWordsAddWord (int Type)
		{
            
            MotherTongue = new MotherTongeWords();
			InitializeComponent ();
            MotherTongue.Type = Type;
		}
	}
}
