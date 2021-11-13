using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame.MenuObjects
{
    public class Quit : MenuObject
    {
        public Quit()
        {
            this.Title = "Save and Quit";
            this.Value = "Select";
        }

        public override void OnActivate()
        {
            NewSettingsMenu.NotReturned = false;
            DodgeBlock.Refresh = false;
            DodgeBlock.InitConsoleColors();
        }

    }
}
