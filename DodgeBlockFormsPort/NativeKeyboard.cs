using System;
//using System.Windows.Input;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

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
    }

    /// <summary>
    /// Provides keyboard access.
    /// </summary>
    internal static class NativeKeyboard
    {
        /// <summary>
        /// A positional bit flag indicating the part of a key state denoting
        /// key pressed.
        /// </summary>
        private const int KeyPressed = 0x8000;

        /// <summary>
        /// Returns a value indicating if a given key is pressed.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns>
        /// <c>true</c> if the key is pressed, otherwise <c>false</c>.
        /// </returns>
        public static bool IsKeyDown(KeyCode key)
        {
            if (!DodgeBlock.UseNewControls)
                return (GetKeyState((int)key) & KeyPressed) != 0;
            else
                return (GetKeyStateC(key));
        }

        private static bool GetKeyStateC(KeyCode testforkey)
        {

            if (testforkey != DodgeBlock.JustPressedKey && (GetKeyState((int)testforkey) & KeyPressed) != 0)
            {
                DodgeBlock.PressedKey = testforkey;
            }
            else
            {
                DodgeBlock.PressedKey = KeyCode.None;
            }

            if (DodgeBlock.PressedKey != KeyCode.None && DodgeBlock.PressedKey != DodgeBlock.JustPressedKey &&
(GetKeyState((int)DodgeBlock.PressedKey) & KeyPressed) != 0)
            {
                DodgeBlock.JustPressedKey = DodgeBlock.PressedKey;
            }
            else
            {
                DodgeBlock.PressedKey = KeyCode.None;
            }

            if (!((GetKeyState((int)DodgeBlock.PressedKey) & KeyPressed) != 0))
            {
                DodgeBlock.PressedKey = KeyCode.None;
                
            }
            if(!((GetKeyState((int)DodgeBlock.JustPressedKey) & KeyPressed) != 0))
            {
                DodgeBlock.JustPressedKey = KeyCode.None;
            }

            if (DodgeBlock.PressedKey == testforkey && DodgeBlock.PressedKey != KeyCode.None)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Update()
        {/*
            if (DodgeBlock.PressedKey != KeyCode.None && DodgeBlock.PressedKey != DodgeBlock.JustPressedKey &&
(GetKeyState((int)DodgeBlock.PressedKey) & KeyPressed) != 0)
            {
                DodgeBlock.JustPressedKey = DodgeBlock.PressedKey;
            }
            else
            {
                DodgeBlock.PressedKey = KeyCode.None;
            }

            if (!((GetKeyState((int)DodgeBlock.PressedKey) & KeyPressed) != 0) && DodgeBlock.PressedKey != KeyCode.None)
            {
                DodgeBlock.PressedKey = KeyCode.None;
                DodgeBlock.JustPressedKey = KeyCode.None;
            }

            */
        }



        /// <summary>
        /// Gets the key state of a key.
        /// </summary>
        /// <param name="key">Virtuak-key code for key.</param>
        /// <returns>The state of the key.</returns>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetKeyState(int key);
    }

}
