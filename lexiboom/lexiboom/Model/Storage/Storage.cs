using System;
using System.Collections.Generic;
using System.Text;

using lexiboom.ViewModel.ListofWordsViewModel;
using SQLite;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

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

            Type[] types = new Type[] { typeof(MotherTongeBase), typeof(MotherTongeWords) };

            connection.CreateTablesAsync(types);

            //connection.CreateTableAsync<MotherTongeBase>();
            //connection.CreateTableAsync<MotherTongeWords>();
            
            Task.Run(async () => await Query("QueryLanguages"));
        }
         
    }
}
