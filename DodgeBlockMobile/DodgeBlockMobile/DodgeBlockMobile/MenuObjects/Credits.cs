using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleGame;

namespace ConsoleGame.MenuObjects
{
    public class Credits : MenuObject
    {
        public Credits()
        {
            this.Title = "Credits";
            this.Value = "Select";
        }

        public override void OnActivate()
        {
            bool NotStarted = true;

            Program.form.TextBoxReplaceRtf(@"\cf1\fs" + (int)(DodgeBlock.BoardSize / 1.5) +
@"--Press Left to Exit-- 
 
Development, Website, & Marketing: othello7 
Icon, Start Animation, & PR: TheKingOfDucks 
 
Update Ideas: 
TheKingOfDucks 
Cataclysm 
TheWalrus72 
TacoMuncherDude 
Fraylak
 
Playtesters: 
PENGUINO270 
TheWalrus72
Fraylak
 
Investors:
Cataclysm - $3
TheKingOfDucks - $1
Fraylak");

            while (NotStarted)
            {
                if (NativeKeyboard.IsKeyDown(KeyCode.Left))
                {
                    NotStarted = false;
                }
                System.Threading.Thread.Sleep(150);
            }
        }
    }
}
