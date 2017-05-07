using System;
using System.Collections.Generic;
using System.Text;

namespace lexiboom.ViewModel.ListofWordsViewModel
{
    public class TranslatorWebSiteViewModel : MotherTongeBase
    {
        private string _TranslationRequest;
        public string TranslationRequest
        {
            get { return _TranslationRequest; }
            set
            {
                _TranslationRequest = value;

                OnPropertyChanged();
            }
        }
    }
}
