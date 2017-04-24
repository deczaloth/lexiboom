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

namespace lexiboom.ViewModel.ListofWordsViewModel
{
    public class MotherTongeWords : INotifyPropertyChanged
    {
        public MotherTongeWords()
        {
            SaveWordCommand = new Command(async ()=> await SaveWord());
            OnAddClickedCommand = new Command(OnAddClicked);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public static ObservableCollection<MotherTongeWords> listofWordsList = new ObservableCollection<MotherTongeWords>();
        public string GUID { get; set; }
        public string Type { get; set; }
        public string Word { get; set; }
        public string Context { get; set; }
        public string Synonyms { get; set; }
        public int Points { get; set; }
        
        public override string ToString()
        {
            return Word;
        }

        public Command SaveWordCommand { get; }
        public Command OnAddClickedCommand { get; set; }

        async void OnAddClicked()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ListofWordsAddWord());
        }

        async Task SaveWord()
        {            
            MotherTongeWords word = new MotherTongeWords();
            word.Word = Word;
            word.Context = Context;
            listofWordsList.Add(word);
            await Application.Current.MainPage.DisplayAlert("Save Word", "Your new word has been added", "Ok");
        }

    }
}
