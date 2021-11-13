using System;
using othello7Library;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame.MenuObjects
{
    public class Music : MenuObject
    {
        public Music()
        {
            this.Title = "Music";

            if(DodgeBlock.MuteMusic)
                this.Value = "Muted";
            else
                this.Value = "UnMuted";
        }
        

        public override void ScaleUp()
        {
            bool Bool = Toggle(DodgeBlock.MuteMusic, "UnMuted", "Muted");
            DodgeBlock.MuteMusic = Bool;  
            DodgeBlock.write.ToThisTxt(5, DodgeBlock.Boolconvert(Bool));
        }
        public override void ScaleDown()
        {
            bool Bool = Toggle(DodgeBlock.MuteMusic, "UnMuted", "Muted");
            DodgeBlock.MuteMusic = Bool;
            DodgeBlock.write.ToThisTxt(5, DodgeBlock.Boolconvert(Bool));
        }
    }
}
