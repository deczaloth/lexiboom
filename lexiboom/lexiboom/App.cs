using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace lexiboom
{
	public class App : Application
	{
        public static ViewModel.ListofWordsViewModel.CardsViewModel CardViewModel;
        public static ViewModel.ListofWordsViewModel.MotherTongeWords MotherTonge;
        public static ViewModel.ConfigurationViewModel.ConfigurationViewModel Configuration;
        public static ViewModel.ConfigurationViewModel.EditLanguageViewModel EditLanguage;
        
        public static Model.Storage.Storage Storage;
		public App ()
		{
            CardViewModel = new ViewModel.ListofWordsViewModel.CardsViewModel();
            MotherTonge = new ViewModel.ListofWordsViewModel.MotherTongeWords();
            Configuration = new ViewModel.ConfigurationViewModel.ConfigurationViewModel();
            EditLanguage = new ViewModel.ConfigurationViewModel.EditLanguageViewModel();
            Storage = new Model.Storage.Storage();

            // The root page of your application
            MainPage = new View.MasterDetail();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
