﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace lexiboom
{
	public class App : Application
	{
        public static ViewModel.ListofWordsViewModel.MotherTongeWords MotherTonge;
		public App ()
		{
            MotherTonge = new ViewModel.ListofWordsViewModel.MotherTongeWords();

            // The root page of your application
            MainPage = new View.MasterDetail();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}