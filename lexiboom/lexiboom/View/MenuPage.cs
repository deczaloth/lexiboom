using System;
using lexiboom.ViewModel;
using Xamarin.Forms;

namespace lexiboom.View
{
    public class MenuPage : ContentPage
    {
        public Action<Page> OnMenuSelect { get; set; }

        public MenuPage()
        {
            Title = "Menu";
            Icon = "menu.png";
            BackgroundColor = Color.FromHex("#00454f");

            Padding = new Thickness(10, 20);

            var dataTemplate = new DataTemplate(typeof(TextCell));
            dataTemplate.SetBinding(TextCell.TextProperty, "Name");

            var listView = new ListView()
            {
                ItemsSource = MasterPageMenuItem.All,
                IsGroupingEnabled = true,
                GroupDisplayBinding = new Binding("GroupName"),
                ItemTemplate = dataTemplate
            };

            listView.ItemSelected += (object sender, SelectedItemChangedEventArgs e) =>
            {
                if (OnMenuSelect != null)
                {
                    var masterPageItem = (MasterPageItem)e.SelectedItem;
                    var masterPageItemPage = masterPageItem.PageFn();
                    OnMenuSelect(masterPageItemPage);
                }
            };
            
                Content = listView;
        }
    }
}
