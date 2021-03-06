﻿using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace lexiboom.ViewModel.ListofWordsViewModel
{
    public class CardsViewModel : MotherTongeBase
    {
        public CardsViewModel()
        {
            ShoworHideTranslationCommand = new Command(ShowOrHideTranslation);
            OnAppearingCommand = new Command(OnAppearingMethod);
        }

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

        [Ignore]
        public Command OnAppearingCommand { get; }
        [Ignore]
        public Command ShoworHideTranslationCommand { get; }

        public void OnAppearingMethod()
        {
            App.CardViewModel.isTranslationVisible = false;
        }

        void ShowOrHideTranslation()
        {
            App.CardViewModel.isTranslationVisible = !App.CardViewModel.isTranslationVisible;
        }
    }
}
