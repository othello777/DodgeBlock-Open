using System;
using othello7Library;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ConsoleGame.MenuObjects
{
    public class Sfx : MenuObject
    {
        public Sfx()
        {
            this.Title = "Sound Effects";

            if (DodgeBlock.MuteSfx)
                this.Value = "Muted";
            else
                this.Value = "UnMuted";
        }


        public override void ScaleUp()
        {
            bool Bool = Toggle(DodgeBlock.MuteSfx, "UnMuted", "Muted");
            DodgeBlock.MuteSfx = Bool;
            DodgeBlock.write.ToThisTxt(7, DodgeBlock.Boolconvert(Bool));
        }
        public override void ScaleDown()
        {
            bool Bool = Toggle(DodgeBlock.MuteSfx, "UnMuted", "Muted");
            DodgeBlock.MuteSfx = Bool;
            DodgeBlock.write.ToThisTxt(7, DodgeBlock.Boolconvert(Bool));
        }
    }
}
