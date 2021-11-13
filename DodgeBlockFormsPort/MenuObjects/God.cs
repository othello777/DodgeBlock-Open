using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame.MenuObjects
{
    public class God : BoolMenuObject
    {
        public God()
        {
            this.Title = "God Mode";
            this.TrueValue = "On";
            this.FalseValue = "Off";
            this.SettingsIndex = 9;
            this.ProgramValue = DodgeBlock.GodMode;
            Initialize();
        }
        public override void Update()
        {
            DodgeBlock.GodMode = ProgramValue;
        }
    }
}
