using System;

namespace ConsoleGame.GameObjects
{
    public abstract class GameObject
    {
        public GameObject()
        {
            Character = '~';
            Color = ConsoleColor.Magenta;
            BackColor = ConsoleColor.Black;
        }
        public GameObject(char character, ConsoleColor color, ConsoleColor backColor)
        {
            Character = character;
            Color = color;
            BackColor = backColor;
        }

        public char Character;
        public ConsoleColor Color;
        public ConsoleColor BackColor;
    }
}
