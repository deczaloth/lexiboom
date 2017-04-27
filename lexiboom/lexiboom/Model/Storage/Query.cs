using System;
using System.Collections.Generic;
using System.Text;

using SQLite;
using lexiboom.ViewModel.ListofWordsViewModel;

namespace lexiboom.Model.Storage
{
    public partial class Storage
    {
        void Query()
        {
            var query = connection.Table<MotherTongeWords>().Where( word => word.Word != null);

            query.ToListAsync().ContinueWith(t =>
            {
                foreach (var word in t.Result)
                    App.Storage.listofWordsList.Add(word);
                foreach (var word in App.Storage.listofWordsList)
                    Console.WriteLine("palabra: {0}", word.Word);
            });
        }
    }
}
