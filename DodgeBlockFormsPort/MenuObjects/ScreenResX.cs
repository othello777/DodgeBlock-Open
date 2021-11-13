using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame.MenuObjects
{
    public class ScreenResX : MenuObject
    {
        private int settingsIndex;

        public ScreenResX()
        {
            this.Title = "Screen Resolution X (width)";
            settingsIndex = 15;
            quickscroll = true;
            UpdateValue();
        }

        public override void ScaleUp()
        {
            if (DodgeBlock.ScrResX < 10000)
                DodgeBlock.ScrResX += 1;
            DodgeBlock.write.ToThisTxt(settingsIndex, DodgeBlock.ScrResX.ToString());
            UpdateValue();
        }

        public override void ScaleDown()
        {
            if (DodgeBlock.ScrResX > 0)
                DodgeBlock.ScrResX -= 1;
            DodgeBlock.write.ToThisTxt(settingsIndex, DodgeBlock.ScrResX.ToString());
            UpdateValue();
        }

        private void UpdateValue()
        {
            Value = DodgeBlock.ScrResX.ToString();
        }
    }
}
