using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame.MenuObjects
{
    public class ScreenResY : MenuObject
    {
        private int settingsIndex;

        public ScreenResY()
        {
            this.Title = "Screen Resolution Y (height)";
            settingsIndex = 17;
            quickscroll = true;
            UpdateValue();
        }

        public override void ScaleUp()
        {
            if (DodgeBlock.ScrResY < 10000)
                DodgeBlock.ScrResY += 1;
            DodgeBlock.write.ToThisTxt(settingsIndex, DodgeBlock.ScrResY.ToString());
            UpdateValue();
        }

        public override void ScaleDown()
        {
            if (DodgeBlock.ScrResY > 0)
                DodgeBlock.ScrResY -= 1;
            DodgeBlock.write.ToThisTxt(settingsIndex, DodgeBlock.ScrResY.ToString());
            UpdateValue();
        }

        private void UpdateValue()
        {
            Value = DodgeBlock.ScrResY.ToString();
        }
    }
}
