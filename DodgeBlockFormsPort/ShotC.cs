using System;

namespace ConsoleGame
{
    public class ShotC
    {
        public ShotC()
        {
            X = 0;
            Y = 0;
            ShootCooldown = 5;
            IsAlive = false;
        }

        public int X;
        public int Y;
        public int ShootCooldown;
        public bool IsAlive;
        
    }
}
