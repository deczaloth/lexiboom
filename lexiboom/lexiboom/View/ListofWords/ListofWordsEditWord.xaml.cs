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
	public partial class ListofWordsEditWord : ContentPage
	{
        object OldItem;
		public ListofWordsEditWord (object oldItem)
		{
            OldItem = oldItem;
            BindingContext = (MotherTongeWords)oldItem;
			InitializeComponent ();
		}

        void OnSaveClicked(object sender, EventArgs args)
        {
            MotherTongeWords newItem = (MotherTongeWords)OldItem;
            newItem.Word = WordEntry.Text;
            newItem.WordTranslation = WordTranslationEntry.Text;
            newItem.Context = ContextEntry.Text;
            newItem.ContextTranslation = ContextTranslationEntry.Text;

            App.Storage.UpdateSQLiteItem(OldItem, newItem);
        }
	}
}
