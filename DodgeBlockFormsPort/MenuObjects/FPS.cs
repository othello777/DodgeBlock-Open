using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame.MenuObjects
{
    public class FPS : BoolMenuObject
    {
        public FPS()
        {
            this.Title = "Display FPS";
            this.TrueValue = "On";
            this.FalseValue = "Off";
            this.SettingsIndex = 41;
            this.ProgramValue = DodgeBlock.DisplayFPS;
            Initialize();
        }
        public override void Update()
        {
            DodgeBlock.DisplayFPS = ProgramValue;
        }
    }
}
