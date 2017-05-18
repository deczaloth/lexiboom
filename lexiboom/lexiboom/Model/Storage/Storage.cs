using System;
using System.Collections.Generic;
using System.Text;

using lexiboom.ViewModel.ListofWordsViewModel;
using SQLite;
using System.Collections.ObjectModel;

namespace lexiboom.Model.Storage
{
    public partial class Storage
    {
        public ObservableCollection<MotherTongeWords> listofWordsList { get; set; }
        public ObservableCollection<MotherTongeBase> LanguagesList { get; set; }
        public SQLiteAsyncConnection connection;
        public Storage()
        {
            listofWordsList = new ObservableCollection<MotherTongeWords>();
            LanguagesList = new ObservableCollection<MotherTongeBase>();

            string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            connection = new SQLiteAsyncConnection(System.IO.Path.Combine(folder,"words.db"));

            connection.CreateTableAsync<MotherTongeBase>();
            connection.CreateTableAsync<MotherTongeWords>();
            

            Query("QueryLanguages");
        }
         
    }
}
