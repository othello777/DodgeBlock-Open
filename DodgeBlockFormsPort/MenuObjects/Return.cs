using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame.MenuObjects
{
    public class Return : MenuObject
    {
        public Return()
        {
            this.Title = "Return to Game";
            this.Value = "Select";
        }

        public override void OnActivate()
        {
            NewSettingsMenu.NotReturned = false;
        }

    }
}
