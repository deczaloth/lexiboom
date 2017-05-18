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
                        {
                            if(!App.Configuration.LanguagesNameList.Contains(word.Type))
                                App.Configuration.LanguagesNameList.Add(word.Type);
                            if(!App.Storage.LanguagesList.Contains(word))
                                App.Storage.LanguagesList.Add(word);
                        }
                            
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
                            if(!App.Storage.listofWordsList.Contains(word))
                                App.Storage.listofWordsList.Add(word);
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
