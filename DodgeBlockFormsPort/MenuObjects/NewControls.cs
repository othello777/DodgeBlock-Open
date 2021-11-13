using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame.MenuObjects
{
    public class NewControls : BoolMenuObject
    {
        public NewControls()
        {
            this.Title = "New Controls";
            this.TrueValue = "On";
            this.FalseValue = "Off";
            this.SettingsIndex = 19;
            this.ProgramValue = DodgeBlock.UseNewControls;
            Initialize();
        }

        public override void Update()
        {
            DodgeBlock.UseNewControls = ProgramValue;
        }
    }
}
