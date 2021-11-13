using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame.MenuObjects
{
    public class Admin : BoolMenuObject
    {
        public Admin()
        {
            //if(DodgeBlock.Mode != 3)
            //    this.Disabled = true;

            this.Title = "Two Player Admin";
            this.TrueValue = "Player2 (WSAD)";
            this.FalseValue = "Player1 (Arrow Keys)";
            this.SettingsIndex = 21;
            this.ProgramValue = DodgeBlock.AdminPlayer2;
            Initialize();
        }
        public override void Update()
        {
            DodgeBlock.AdminPlayer2 = ProgramValue;
        }
    }
}
