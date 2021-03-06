﻿using System;
using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace lexiboom.Droid
{
    [Activity (Label = "lexiboom", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            UserDialogs.Init(this);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			LoadApplication (new lexiboom.App ());
		}

        public override void OnBackPressed()
        {
            App.Configuration.isPresented = !App.Configuration.isPresented;
        }
    }
}

