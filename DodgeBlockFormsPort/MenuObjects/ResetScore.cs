using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleGame;
using ConsoleGame.MenuObjects;
using DodgeBlockFormsPort;

namespace DodgeBlockFormsPort.MenuObjects
{
    public class ResetScore : MenuObject
    {
        string defaultvalue = "Select";
        string defaulttitle = "Reset High Score";
        public ResetScore()
        {
            this.Title = defaulttitle;
            this.Value = defaultvalue;
        }

        public override void OnActivate()
        {
            Title = "Are you sure you want to erase the current High Score?";
            Value = "Up/Down = Yes | Left = Cancel";
        }

        public override void OnDeactivate()
        {
            this.Title = defaulttitle;
            this.Value = defaultvalue;
        }

        public override void ScaleUp()
        {
            Reset();
        }

        public override void ScaleDown()
        {
            Reset();
        }

        private void Reset()
        {
            int resetto = 0;
            if (DodgeBlock.Mode == 0)
            {
                if (DodgeBlock.TwoPlayerMode)
                    DodgeBlock.write.ToThisTxt(3, resetto.ToString());
                else
                    DodgeBlock.write.ToThisTxt(1, resetto.ToString());
            }
            else if (DodgeBlock.Mode == 1)
            {
                if (DodgeBlock.TwoPlayerMode)
                    DodgeBlock.write.ToThisTxt(27, resetto.ToString());
                else
                    DodgeBlock.write.ToThisTxt(25, resetto.ToString());
            }
            else if (DodgeBlock.Mode == 2)
            {
                if (DodgeBlock.TwoPlayerMode)
                    DodgeBlock.write.ToThisTxt(35, resetto.ToString());
                else
                    DodgeBlock.write.ToThisTxt(33, resetto.ToString());
            }
            DodgeBlock.HighScore = resetto;

            Value = "High Score Reset!";
        }

    }
}
