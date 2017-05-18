using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace lexiboom.View.Configuration
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Configuration : ContentPage
	{
		public Configuration ()
		{
            InitializeComponent ();

            listView.BindingContext = App.Configuration.OptionsList;
        }

        async private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            #region "Add new language"
            if ((string)listView.SelectedItem == "Add new language")
            {
                var languageEntryUserDialog = new PromptConfig();
                languageEntryUserDialog.InputType = InputType.Name;
                languageEntryUserDialog.IsCancellable = true;
                languageEntryUserDialog.Message = "Write the language that you want to add:";
                var newLanguage = await UserDialogs.Instance.PromptAsync(languageEntryUserDialog);
                if (newLanguage.Ok)
                {
                    ViewModel.ListofWordsViewModel.MotherTongeBase language = new ViewModel.ListofWordsViewModel.MotherTongeBase();
                    language.Type = newLanguage.Text;
                    try
                    {
                        await App.Storage.connection.InsertAsync(language);
                    }
                    catch
                    {
                        Console.WriteLine("Error mio");
                    }
                    App.Configuration.LanguagesNameList.Add(newLanguage.Text);
                    await DisplayAlert("Language added!", "Your new language has been successfuly added. You can now go to \"Words\" section and select it to start adding words. Boom!", "Ok");
                }
                listView.SelectedItem = null;
            }
            #endregion
            else if((string)listView.SelectedItem == "Edit Language")
            {
                if (App.Configuration.LanguagesNameList.Count == 0)
                    await DisplayAlert("Error!", "It seems that you have not added any language. Tap on \"Add new language\" to start your lexiboom adventure!", "Ok");
                else
                    await Navigation.PushAsync(new EditLanguagePage());
            }
        }

        private void newLanguageEntry_Completed(object sender, EventArgs e)
        {
            string language = ((Entry)sender).Text;
            ViewModel.MasterPageMenuItem.groups[0].
                Add(new ViewModel.MasterPageItem(language, () => new ListofWords.ListofWords()));
        }
    }
}
