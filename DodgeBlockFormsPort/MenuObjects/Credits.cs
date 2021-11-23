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
@"--Press Left to Exit--\line 
\line 
Development, Website, & Marketing: othello7\line 
Icon, Start Animation, & PR: TheKingOfDucks\line 
\line 
Update Ideas:\line 
TheKingOfDucks\line 
Cataclysm\line 
TheWalrus72\line 
TacoMuncherDude\line 
Fraylak\line
\line 
Playtesters:\line 
PENGUINO270\line 
TheWalrus72\line
\line 
Investors:\line
Cataclysm - $3\line
TheKingOfDucks - $1\line
\line
");

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
