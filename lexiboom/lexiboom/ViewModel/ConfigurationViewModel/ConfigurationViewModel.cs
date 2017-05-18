using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using lexiboom.ViewModel.ListofWordsViewModel;
using Xamarin.Forms;

namespace lexiboom.ViewModel.ConfigurationViewModel
{
    public class ConfigurationViewModel : INotifyPropertyChanged
    {
        public ConfigurationViewModel()
        {
            //addNewLanguageTappedCommand = new Command(AddNewLanguageTapped);
            saveEditLanguageChangesCommand = new Command(saveEditLanguageChanges);
            removeLanguageCommand = new Command(removeLangauge);
        }

        public List<string> OptionsList = new List<string>
        {
            "Add new language", "Edit Language", "Move Words to other language"
        };

        public List<string> LanguagesNameList = new List<string>();

        public Command addNewLanguageTappedCommand { get; }
        public Command saveEditLanguageChangesCommand { get; }
        public Command removeLanguageCommand { get; }

        async void AddNewLanguageTapped()
        {
            await Application.Current.MainPage.DisplayAlert("Tapped!", "Succesfully recognized your tapping spirit!", "Ok");
        }

        void saveEditLanguageChanges(object LanguageEditing)
        {
            App.Storage.Query(((EditLanguageViewModel)LanguageEditing).oldLanguageName);
            App.Storage.Query("QueryLanguages");

            for (int i = 0; i < App.Storage.listofWordsList.Count; i++)
            {

                MotherTongeWords EditedWord = (MotherTongeWords)App.Storage.listofWordsList[i];
                EditedWord.Type = ((EditLanguageViewModel)LanguageEditing).newLanguageName;
                App.Storage.UpdateSQLiteItem(App.Storage.listofWordsList[i], EditedWord);
            }
            for (int i = 0; i < App.Storage.LanguagesList.Count; i++)
            {
                MotherTongeBase EditedLanguageObject = (MotherTongeBase)App.Storage.LanguagesList[i];
                EditedLanguageObject.Type = ((EditLanguageViewModel)LanguageEditing).newLanguageName;
                App.Storage.UpdateSQLiteItem(App.Storage.LanguagesList[i], EditedLanguageObject);
            }

            App.Storage.LanguagesList.Clear(); App.Storage.listofWordsList.Clear(); App.Configuration.LanguagesNameList.Clear();
            App.Storage.Query(((EditLanguageViewModel)LanguageEditing).oldLanguageName);
            App.Storage.Query("QueryLanguages");
        }

        void removeLangauge()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class SelectedIndexToElementName : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int index = Int16.Parse(value.ToString());
            if (index == -1)
            {
                return "";
            }
            else
                return App.Configuration.LanguagesNameList[index];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return false;
        }
    }
}