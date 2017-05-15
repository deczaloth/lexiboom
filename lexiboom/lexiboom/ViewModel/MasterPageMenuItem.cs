using System;
using System.Collections.Generic;
using lexiboom.View.ListofWords;

namespace lexiboom.ViewModel
{
    public class MasterPageMenuItem : List<MasterPageItem>
    {
        public static List<MasterPageMenuItem> groups;

        private MasterPageMenuItem(string groupName)
        {
            this.GroupName = groupName;
        }

        public string GroupName { private set; get; }

        static MasterPageMenuItem()
        {
            groups = new List<MasterPageMenuItem>
            {
                new MasterPageMenuItem("Lists of Words"),
                new MasterPageMenuItem("Configuration")

            };

            groups[0].Add(new MasterPageItem("Word Cards", () => new ListofWords()));
            groups[0].Add(new MasterPageItem("Word Quiz!", () => new WordQuizPage()));
            groups[1].Add(new MasterPageItem("Languages Configuration", () => new View.Configuration.Configuration()));
            

            All = groups;
        }

        public static IList<MasterPageMenuItem> All { private set; get; }


    }
}
