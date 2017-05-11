using System;
using System.Collections.Generic;
using System.Text;
using lexiboom.ViewModel.ListofWordsViewModel;

namespace lexiboom.Model.Storage
{
    public partial class Storage
    {
        public void UpdateSQLiteItem(object oldItem, object newItem)
        {
            connection.UpdateAsync((MotherTongeWords)oldItem).ContinueWith(t =>
            {
                oldItem = (MotherTongeWords)newItem;
            });
        }
    }
}
