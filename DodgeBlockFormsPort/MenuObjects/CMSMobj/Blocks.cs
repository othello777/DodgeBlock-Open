using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame.MenuObjects.CMSMobj
{
    public class Blocks : IntMenuObject
    {
        public Blocks()
        {
            this.Title = "Blocks Per Row";
            this.looped = false;
            this.minValue = 0;
            this.maxValue = 32;
            this.SettingsIndex = 35;
            this.ProgramValue = DodgeBlock.customModeC.Blocks;
            this.Initialize();
        }

        public override void Update()
        {
            DodgeBlock.customModeC.Blocks = this.ProgramValue;
        }
    }
}
