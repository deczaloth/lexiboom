using System;
using System.Collections.Generic;
using lexiboom.View.ListofWords;

namespace lexiboom.ViewModel
{
    public class MasterPageMenuItem : List<MasterPageItem>
    {
        private MasterPageMenuItem(string groupName)
        {
            this.GroupName = groupName;
        }

        public string GroupName { private set; get; }

        static MasterPageMenuItem()
        {
            List<MasterPageMenuItem> groups = new List<MasterPageMenuItem>
            {
                new MasterPageMenuItem("List of Words"),
                
            };

            groups[0].Add(new MasterPageItem("Words", () => new ListofWords()));
            

            All = groups;
        }

        public static IList<MasterPageMenuItem> All { private set; get; }


    }
}
