using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame.MenuObjects.CMSMobj
{
    public class BoardWidth : IntMenuObject
    {
        public BoardWidth()
        {
            this.Title = "Board Width";
            this.looped = false;
            this.quickscroll = true;
            this.minValue = 3;
            this.maxValue = 16;
            this.SettingsIndex = 15;
            this.ProgramValue = DodgeBlock.customModeC.BoardX;
            this.Initialize();
        }

        public override void Update()
        {
            DodgeBlock.customModeC.BoardX = this.ProgramValue;
        }
    }
}
