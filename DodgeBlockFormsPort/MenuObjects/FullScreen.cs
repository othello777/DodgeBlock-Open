using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame.MenuObjects
{
    public class FullScreen : BoolMenuObject
    {
        public FullScreen()
        {
            this.Title = "FullScreen mode";
            this.TrueValue = "On";
            this.FalseValue = "Off";
            this.SettingsIndex = 11;
            this.ProgramValue = DodgeBlock.FullScreen;
            Initialize();
        }

        public override void ScaleUp()
        {            
            base.ScaleUp();
            DodgeBlock.FullScreen = ProgramValue;
            if (DodgeBlock.FullScreen)
            {
                Program.form.Fullscreen(true);
            }
            else
            {
                Program.form.Fullscreen(false);
            }
        }

        public override void ScaleDown()
        {            
            base.ScaleDown();
            DodgeBlock.FullScreen = ProgramValue;
            if (DodgeBlock.FullScreen)
            {
                Program.form.Fullscreen(true);
            }
            else
            {
                Program.form.Fullscreen(false);
            }
        }

        public override void Update()
        {/*
            DodgeBlock.FullScreen = ProgramValue;
            if (DodgeBlock.FullScreen)
            {
                Program.form.Fullscreen(true);
            }
            else
            {
                Program.form.Fullscreen(false);
            }*/
        }
    }
}
