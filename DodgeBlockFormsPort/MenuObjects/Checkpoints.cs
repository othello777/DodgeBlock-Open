using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame.MenuObjects
{
    class Checkpoints : BoolMenuObject
    {
        public Checkpoints()
        {
            this.Title = "Enable Checkpoints";
            this.TrueValue = "On (Only for Classsic & Expert)";
            this.FalseValue = "Off";
            this.SettingsIndex = 39;
            this.ProgramValue = DodgeBlock.UseCheckpoints;
            Initialize();
        }
        public override void Update()
        {
            DodgeBlock.UseCheckpoints = ProgramValue;
        }
        public override void OnActivate()
        {
            this.Title = "Enable Checkpoints (Classic & Expert)";
        }

        public override void OnDeactivate()
        {
            this.Title = "Enable Checkpoints";
        }
    }
}
