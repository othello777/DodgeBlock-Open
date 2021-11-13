using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame.MenuObjects.CMSMobj
{
    public class CustomReturn : MenuObject
    {
        public CustomReturn()
        {
            this.Title = "<<Back";
            this.Value = "Select";
        }

        public override void OnActivate()
        {
            CustomModeSettings.NotReturned = false;
        }
    }
}
