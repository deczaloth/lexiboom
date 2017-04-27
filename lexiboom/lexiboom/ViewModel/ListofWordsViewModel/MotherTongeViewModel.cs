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

namespace lexiboom.ViewModel.ListofWordsViewModel
{
    public class MotherTongeWords : INotifyPropertyChanged
    {
        public MotherTongeWords()
        {
            SaveWordCommand = new Command(async ()=> await SaveWord());
            OnAddClickedCommand = new Command((sender)=> OnAddClicked(sender));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public static ObservableCollection<MotherTongeWords> listofWordsList = new ObservableCollection<MotherTongeWords>();
        public string GUID { get; set; }
        public string Type { get; set; }

        public string _Word;
        [PrimaryKey, AutoIncrement]
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

        public string Synonyms { get; set; }
        public int Points { get; set; }
        
        public override string ToString()
        {
            return Word;
        }

        public Command SaveWordCommand { get; }
        public Command OnAddClickedCommand { get; set; }

        async void OnAddClicked(object sender)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ListofWordsAddWord());
        }

        async Task SaveWord()
        {            
            MotherTongeWords word = new MotherTongeWords();
            word.Word = Word;
            word.Context = Context;
            App.Storage.listofWordsList.Add(word);
            try
            {
                App.Storage.connection.InsertAsync(word).ContinueWith(t => { Console.WriteLine("New word: {0}", word.Word); });
            }
            catch
            {
                Console.WriteLine("Error mio");
            }
            await Application.Current.MainPage.DisplayAlert("Save Word", "Your new word has been added", "Ok");
            Word = ""; Context = "";
        }

    }
}
