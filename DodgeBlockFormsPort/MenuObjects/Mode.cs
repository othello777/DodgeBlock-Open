using System;
using System.IO;
using System.Text;
using DodgeBlockFormsPort.MenuObjects;

namespace ConsoleGame.MenuObjects
{
    public class Mode : IntMenuObject
    {

        public Mode()
        {
            this.Title = "Game Mode";
            this.looped = true;
            this.minValue = 0;
            this.maxValue = DodgeBlock.MaxMode;
            SettingsIndex = 23;
            this.ProgramValue = DodgeBlock.Mode;
            Initialize();
            UpdateValue();
        }

        public override void Update()
        {
            if (DodgeBlock.Mode != ProgramValue)
            {
                DodgeBlock.Mode = ProgramValue;
                DodgeBlock.ConvertTwoPlayerMode();
                DodgeBlock.ResetGame();
                DodgeBlock.ImportHighScore();
            }
        }

        public override void OnActivate()
        {
            this.Title = "This will erase the current score";
        }

        public override void OnDeactivate()
        {
            this.Title = "Game Mode";
        }

        public override void ScaleUp()
        {
            base.ScaleUp();
            UpdateValue();
        }

        public override void ScaleDown()
        {
            base.ScaleDown();
            UpdateValue();
        }

        private void UpdateValue()
        {
            if (ProgramValue == 0)
                Value = "Classic Mode";
            else if (ProgramValue == 1)
                Value = "Normal Mode";
            else if (ProgramValue == 2)
                Value = "Expert Mode";
            else if (ProgramValue == 3)
                Value = "Two Player Mode (No LeaderBoard)";
            else if (ProgramValue == 4 && DodgeBlock.IsHolloween)
                Value = "Halloween Event";
            else if (ProgramValue == 4 && DodgeBlock.IsChristmas)
                Value = "Winter Event";
            else if (ProgramValue == 4)
                Value = "Custom Mode (No LeaderBoard)";
            else
                Value = "raaaad mode";
        }
    }
}
