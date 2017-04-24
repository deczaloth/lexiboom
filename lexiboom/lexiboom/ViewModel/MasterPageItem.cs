using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace lexiboom.ViewModel
{
    public class MasterPageItem
    {
        public string Name { get; set; }

        public Func<Page> PageFn { get; set; }

        public MasterPageItem(string name, Func<Page> pageFn)
        {
            Name = name;
            PageFn = pageFn;
        }
    }
}
