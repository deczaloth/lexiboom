using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace lexiboom.View.Configuration
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditLanguagePage : ContentPage
	{
		public EditLanguagePage ()
		{
			InitializeComponent ();
            BindingContext = App.Configuration;

            for (int i = 0; i < App.Configuration.LanguagesNameList.Count; i++)
            {
                LanguagePicker.Items.Add(App.Configuration.LanguagesNameList[i]);
            }
        }
	}
}
