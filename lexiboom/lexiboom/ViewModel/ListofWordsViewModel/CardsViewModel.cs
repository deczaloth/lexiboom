using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace lexiboom.ViewModel.ListofWordsViewModel
{
    public class CardsViewModel : MotherTongeBase
    {
        public CardsViewModel()
        { }

        private bool _isTranslationVisible;
        public bool isTranslationVisible
        {
            get { return _isTranslationVisible; }
            set
            {
                _isTranslationVisible = value;

                OnPropertyChanged();
            }
        }

    }
}
