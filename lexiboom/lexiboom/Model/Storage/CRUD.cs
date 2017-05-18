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
            string TypeOfOldItem = oldItem.GetType().Name;
            switch(TypeOfOldItem)
            {
                case nameof(MotherTongeBase):
                    connection.UpdateAsync((MotherTongeBase)oldItem).ContinueWith(t =>
                    {
                        oldItem = (MotherTongeBase)newItem;
                    });
                    break;
                case nameof(MotherTongeWords):
                    connection.UpdateAsync((MotherTongeWords)oldItem).ContinueWith(t =>
                    {
                        oldItem = (MotherTongeWords)newItem;
                    });
                    break;
            }
                
            
        }
    }
}
