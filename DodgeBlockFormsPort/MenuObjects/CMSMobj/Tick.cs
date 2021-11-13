using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame.MenuObjects.CMSMobj
{
    public class Tick : IntMenuObject
    {
        public Tick()
        {
            this.Title = "Tick Delay (ms)";
            this.looped = false;
            this.quickscroll = true;
            this.minValue = 10;
            this.maxValue = 256;
            this.SettingsIndex = 29;
            this.ProgramValue = DodgeBlock.customModeC.Tick;
            this.Initialize();
        }

        public override void Update()
        {
           DodgeBlock.customModeC.Tick = this.ProgramValue;
        }
    }
}
