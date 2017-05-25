using System;
using System.Collections.Generic;
using System.Text;
using lexiboom.ViewModel.ListofWordsViewModel;
using System.Threading.Tasks;

namespace lexiboom.Model.Storage
{
    public partial class Storage
    {
        public async Task UpdateSQLiteItem(object oldItem, object newItem)
        {
            string TypeOfOldItem = oldItem.GetType().Name;
            switch(TypeOfOldItem)
            {
                case nameof(MotherTongeBase):
                    await connection.UpdateAsync((MotherTongeBase)oldItem).ContinueWith(t =>
                    {
                        oldItem = (MotherTongeBase)newItem;
                    });
                    break;
                case nameof(MotherTongeWords):
                    await connection.UpdateAsync((MotherTongeWords)oldItem).ContinueWith(t =>
                    {
                        oldItem = (MotherTongeWords)newItem;
                    });
                    break;
            }
                
            
        }
    }
}
