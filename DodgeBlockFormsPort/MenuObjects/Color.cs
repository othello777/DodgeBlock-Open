using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame.MenuObjects
{
    public class ColorSwitch : BoolMenuObject
    {
        public ColorSwitch()
        {
            this.Title = "Use Color on Board";
            this.TrueValue = "On";
            this.FalseValue = "Off";
            this.SettingsIndex = 19;
            this.ProgramValue = DodgeBlock.ColorMode;
            Initialize();
        }

        public override void Update()
        {
            DodgeBlock.ColorMode = ProgramValue;
        }

    }
}
