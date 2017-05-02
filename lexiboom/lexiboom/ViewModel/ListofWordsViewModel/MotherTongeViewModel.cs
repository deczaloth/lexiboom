using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using lexiboom.View;
using System.Threading.Tasks;
using Xamarin.Forms;
using lexiboom.View.ListofWords;
using SQLite;
using System.Globalization;

namespace lexiboom.ViewModel.ListofWordsViewModel
{
    public class MotherTongeWords : MotherTongeBase
    {
        public MotherTongeWords()
        {
            SaveWordCommand = new Command(async ()=> await SaveWord());
            OnAddClickedCommand = new Command((sender)=> OnAddClicked(sender));
        }

        //public static ObservableCollection<MotherTongeWords> listofWordsList = new ObservableCollection<MotherTongeWords>();
        public string _Word;
        public string Word
        {
            get { return _Word; }
            set
            {
                _Word = value;

                OnPropertyChanged();
            }
        }

        private string _Context;
        public string Context
        {
            get { return _Context; }
            set
            {
                _Context = value;

                OnPropertyChanged();
            }
        }
        public int Points { get; set; }
        
        public override string ToString()
        {
            return string.Format("{0}: {1}; Id: {2}; Type: {3}; Points: {4}", Word, Context, Id, Type, Points);
        }

        [Ignore]
        public Command SaveWordCommand { get; }
        [Ignore]
        public Command OnAddClickedCommand { get; set; }

        async void OnAddClicked(object sender)
        {
            
            //await Application.Current.MainPage.Navigation.PushAsync(new ListofWordsAddWord());
        }

        async Task SaveWord()
        {            
            MotherTongeWords word = new MotherTongeWords();
            word.Word = Word;
            word.Context = Context;
            word.Type = Type;
            word.Points = 0;
            App.Storage.listofWordsList.Add(word);
            try
            {
                await App.Storage.connection.InsertAsync(word);
            }
            catch
            {
                Console.WriteLine("Error mio");
            }
            await Application.Current.MainPage.DisplayAlert("Save Word", "Your new word has been added. " + string.Format("Details: {0}", word.ToString()), "Ok");
            Word = ""; Context = "";
        }

        
    }
    public class LanguageToPickerSelectedIndex : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (App.Configuration.LanguageList.Count >= 1)
                return App.Configuration.LanguageList.IndexOf((string)value);
            else return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (App.Configuration.LanguageList.Count >= 1)
                return App.Configuration.LanguageList[Int16.Parse(value.ToString())];
            else return false;
        }
    }
}
