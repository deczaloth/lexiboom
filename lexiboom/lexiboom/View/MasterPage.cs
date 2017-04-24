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
            MasterBehavior = MasterBehavior.Popover;
            IsPresented = true;
            //BindingContext = App.TablePageViewModel;
            //this.SetBinding(IsPresentedProperty, "NotPulling");

            var menuPage = new MenuPage();

            menuPage.OnMenuSelect = (masterPageItemPage) =>
            {
                Detail = new NavigationPage(masterPageItemPage);
                IsPresented = false;
            };

            Master = menuPage;
            Detail = new NavigationPage(new DetailPage());
        }
    }
}
