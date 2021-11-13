using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame.MenuObjects.CMSMobj
{
    public class BoardHeight : IntMenuObject
    {
        public BoardHeight()
        {
            this.Title = "Board Height";
            this.looped = false;
            this.quickscroll = true;
            this.minValue = 3;
            this.maxValue = 16;
            this.SettingsIndex = 17;
            this.ProgramValue = DodgeBlock.customModeC.BoardY;
            this.Initialize();
        }

        public override void Update()
        {
            DodgeBlock.customModeC.BoardY = this.ProgramValue;
        }
    }
}
