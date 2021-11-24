using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleGame.MenuObjects;
using ConsoleGame;

namespace DodgeBlockFormsPort.MenuObjects
{
    public class MusicSelector : IntMenuObject
    {
        public MusicSelector()
        {
            this.Title = "Music Selector";
            this.looped = false;
            this.minValue = 0;
            this.maxValue = GameMusic.SongList.Length - 1;
            SettingsIndex = 37;
            this.ProgramValue = DodgeBlock.MusicSelector;
            Initialize();
            UpdateValue();
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

        public override void Update()
        {
            DodgeBlock.music.SwitchMusic(DodgeBlock.MusicSelector, ProgramValue);
            DodgeBlock.MusicSelector = ProgramValue;
        }

        private void UpdateValue()
        {
                 if (ProgramValue == 0)
                Value = "(Default) Mario2 - Guest_ub3rphr34k_* - rohitab.com";
            else if (ProgramValue == 1)
                Value = "Mario Theme - davewilson - gist.github.com";
            else if (ProgramValue == 2)
                Value = "Tetris Theme - HelgeSverre - gist.github.com";
            else if (ProgramValue == 3)
                Value = "Imperial March - lesaboteur in the comments of jeffwouters.nl";
            else if (ProgramValue == 4)
                Value = "Happy Birthday - Mrok glasius - youtube.com";
            else if (ProgramValue == 5)
                Value = "Better Mario Theme - I don't remember where I got this one. Sorry.";
            else if (ProgramValue == 6)
                Value = "Mission Impossible - Unknown author - jeffwouters.nl";
            else if (ProgramValue == 7)
                Value = "Vader Theme - I don't remember where I got this one. Sorry.";
            else if (ProgramValue == 8)
                Value = "DrMario - othello7 - dodgeblock.cf";
            else if (ProgramValue == 9)
                Value = "Garble - Computer Generated - Your Computer!";

        }

    }
}
