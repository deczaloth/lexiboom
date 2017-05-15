using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace lexiboom.ViewModel.ConfigurationViewModel
{
    public class ConfigurationViewModel : INotifyPropertyChanged
    {
        public ConfigurationViewModel()
        {
            //addNewLanguageTappedCommand = new Command(AddNewLanguageTapped);
        }

        public List<string> OptionsList = new List<string>
        {
            "Add new language", "Edit Language", "Move Words to other language"
        };

        public List<string> LanguageList = new List<string>();

        public Command addNewLanguageTappedCommand { get; }

        async void AddNewLanguageTapped()
        {
            await Application.Current.MainPage.DisplayAlert("Tapped!", "Succesfully recognized your tapping spirit!", "Ok");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}