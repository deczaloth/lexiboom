using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace lexiboom.View
{
    public class MasterDetail : MasterDetailPage
    {
        public MasterDetail()
        {
            BindingContext = App.Configuration;
            MasterBehavior = MasterBehavior.Popover;
            this.SetBinding(IsPresentedProperty, "isPresented");
            App.Configuration.isPresented = true;

            var menuPage = new MenuPage();

            menuPage.OnMenuSelect = (masterPageItemPage) =>
            {
                Detail = new NavigationPage(masterPageItemPage);
                this.SetBinding(IsPresentedProperty, "isPresented");
                App.Configuration.isPresented = false;
            };
            
            Master = menuPage;
            Detail = new NavigationPage(new DetailPage());
        }
    }
}
