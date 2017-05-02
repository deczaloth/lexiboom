using System;
using System.Collections.Generic;
using System.Text;

using SQLite;
using lexiboom.ViewModel.ListofWordsViewModel;

namespace lexiboom.Model.Storage
{
    public partial class Storage
    {
        public void Query(string KeyToQuery)
        {
            if (KeyToQuery == "QueryLanguages")
            {
                var query = connection.Table<MotherTongeBase>();
                try
                {
                    query.ToListAsync().ContinueWith(t =>
                    {
                        foreach (var word in t.Result)
                            App.Configuration.LanguageList.Add(word.Type);
                        foreach (var word in App.Storage.listofWordsList)
                            Console.WriteLine("palabra: {0}", word.ToString());
                    });
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine("Error de nulidad: ", e);
                }
            }
            else
            {
                var query = connection.Table<MotherTongeWords>().Where(v => v.Type == KeyToQuery);
                try
                {
                    query.ToListAsync().ContinueWith(t =>
                    {
                        foreach (var word in t.Result)
                            App.Storage.listofWordsList.Add(word);
                        foreach (var word in App.Storage.listofWordsList)
                            Console.WriteLine("palabra: {0}", word.ToString());
                    });
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine("Error de nulidad: ", e);
                }
            }            
        }
    }
}
