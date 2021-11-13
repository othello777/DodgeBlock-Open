using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame.GameObjects
{
    public class Snowflake : FallingObject
    {
        public Snowflake()
        {
            this.Character = '/';
            this.Color = ConsoleColor.White;
            this.BackColor = ConsoleColor.Red;
        }
    }
}
