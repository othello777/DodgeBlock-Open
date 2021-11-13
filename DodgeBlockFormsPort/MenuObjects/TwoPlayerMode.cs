using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame.MenuObjects
{
    public class TwoPlayerMode : BoolMenuObject
    {
        public TwoPlayerMode()
        {
            this.Title = "Two Player Mode";
            this.TrueValue = "On";
            this.FalseValue = "Off";
            this.SettingsIndex = 13;
            this.ProgramValue = DodgeBlock.TwoPlayerMode;
            Initialize();
        }

        public override void OnActivate()
        {
            this.Title = "This will erase the current score";
        }

        public override void OnDeactivate()
        {
            this.Title = "Two Player Mode";
        }

        public override void Update()
        {
            if (DodgeBlock.TwoPlayerMode != ProgramValue)
            {
                DodgeBlock.TwoPlayerMode = ProgramValue;
                DodgeBlock.ImportHighScore();
                DodgeBlock.ResetGame();
            }
        }

    }
}
