using System;

namespace ConsoleGame
{
    /// <summary>
    /// Codes representing keyboard keys.
    /// </summary>
    /// <remarks>
    /// Key code documentation:
    /// http://msdn.microsoft.com/en-us/library/dd375731%28v=VS.85%29.aspx
    /// </remarks>
    internal enum KeyCode : int
    {
        None = 0,
        /// <summary>
        /// The left arrow key.
        /// </summary>
        Left = 0x25,

        /// <summary>
        /// The up arrow key.
        /// </summary>
        Up,

        /// <summary>
        /// The right arrow key.
        /// </summary>
        Right,

        /// <summary>
        /// The down arrow key.
        /// </summary>
        Down,

        W = 0x57,

        S = 0x53,

        A = 0x41,

        D = 0x44
        /*
        Left = ConsoleKey.LeftArrow,

        Up = ConsoleKey.LeftArrow,

        Right = ConsoleKey.LeftArrow,

        Down = ConsoleKey.LeftArrow,

        W = ConsoleKey.W,

        S = ConsoleKey.S,

        A = ConsoleKey.A,

        D = ConsoleKey.D
        */
    }


    

    /// <summary>
    /// Provides keyboard access.
    /// </summary>
    internal static class NativeKeyboard
    {
        static ConsoleKey presentkey;
        /// <summary>
        /// A positional bit flag indicating the part of a key state denoting
        /// key pressed.
        /// </summary>
        //private const int KeyPressed = 0x8000;

        /// <summary>
        /// Returns a value indicating if a given key is pressed.
        /// </summary>website!

        /// <param name="key">The key to check.</param>
        /// <returns>
        /// <c>true</c> if the key is pressed, otherwise <c>false</c>.
        /// </returns>
        public static bool IsKeyDown(KeyCode key)
        {
            return (GetKeyState((ConsoleKey)key));// & KeyPressed) != 0;
        }

        /// <summary>
        /// Gets the key state of a key.
        /// </summary>
        /// <param name="key">Virtuak-key code for key.</param>
        /// <returns>The state of the key.</returns>

        private static bool GetKeyState(ConsoleKey key)
        {
            if (Console.KeyAvailable)
                presentkey = Console.ReadKey(true).Key;
                
            if(presentkey == key)
                return true;
            /*switch(key)
            {
                case ConsoleKey.UpArrow:
                    if (Program.keys.Up) { return true; }
                    break;
                case ConsoleKey.LeftArrow:
                    if(Program.keys.Left) { return true; }
                    break;
                case ConsoleKey.DownArrow:
                    if (Program.keys.Down) { return true; }
                    break;
                case ConsoleKey.RightArrow:
                    if (Program.keys.Right) { return true; }
                    break;
            }*/
            return false;
        }

        public static void Update()
        {
            presentkey = ConsoleKey.P;
            if (Console.KeyAvailable)
            {
                presentkey = Console.ReadKey(true).Key;

                /*switch (pressedkey)
                {
                    case ConsoleKey.LeftArrow:
                        Program.keys.Left = true;
                        break;
                    case ConsoleKey.UpArrow:
                        Program.keys.Up = true;
                        break;
                    case ConsoleKey.DownArrow:
                        Program.keys.Down = true;
                        break;
                    case ConsoleKey.RightArrow:
                        Program.keys.Right = true;
                        break;
                }*/

            }
        }
    }
}