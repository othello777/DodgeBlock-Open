using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame.MenuObjects
{
    public class CustomModeSettingsMenuObject : MenuObject
    {
        public CustomModeSettingsMenuObject()
        {
            this.Title = "Custom Mode Settings";
            this.Value = "Select";
        }

        public override void OnActivate()
        {
            CustomModeSettings.CMSMenu();
        }
    }
}
