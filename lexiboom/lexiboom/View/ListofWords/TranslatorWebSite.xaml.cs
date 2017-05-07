﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace lexiboom.View.ListofWords
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TranslatorWebSite : ContentPage
	{
		public TranslatorWebSite (string ContentToTranslate)
		{
			InitializeComponent ();

            translatorWebSite.Source = "https://translate.google.com/#auto/en/" + ContentToTranslate;
		}
	}
}
