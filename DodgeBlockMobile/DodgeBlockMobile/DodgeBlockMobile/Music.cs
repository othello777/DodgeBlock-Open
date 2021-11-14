using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleGame
{
    class GameMusic
    {
        //public Thread thread1 = new Thread(Song);


        public static Thread thMario2 = new Thread(Song);
        public static Thread thMario = new Thread(Mario);
        public static Thread thTetris = new Thread(Tetris);
        public static Thread thStarWars = new Thread(StarWars);
        public static Thread thBirthday = new Thread(Birthday);
        public static Thread thBetterMario = new Thread(BetterMario);
        public static Thread thMissionImpossible = new Thread(MissionImpossible);
        public static Thread thAltStarWars = new Thread(AltStarWars);
        public static Thread thGarble = new Thread(Garble);
        public int Select;

        public static Thread[] SongList = new Thread[]
{
                thMario2,
                thMario,
                thTetris,
                thStarWars,
                thBirthday,
                thBetterMario,
                thMissionImpossible,
                thAltStarWars,
                thGarble
};

        public void init()
        {
            Select = DodgeBlock.MusicSelector;
        }

        public void DieNoise()
        {
            //(new Thread(Death)).Start();
        }

        public void PlayMusic()
        {
            //SongList[Select].Start();
        }

        public void PauseMusic()
        {
            //SongList[Select].Suspend();
        }

        public void ResumeMusic()
        {
            //SongList[Select].Resume();
        }

        public void TerminateMusic()
        {/*
            for (int i = 0; i < SongList.Length; i++)
            {
                if (SongList[i].ThreadState == ThreadState.Suspended)
                    SongList[i].Resume();

                SongList[i].Abort();
            }*/
        }

        public void SwitchMusic(int OldValue, int NewValue)
        {
            //(DodgeBlock.MuteMusic) //(SongList[OldValue].ThreadState == ThreadState.Suspended)

            Select = NewValue;

            if (!SongList[NewValue].IsAlive)
            {
                //SongList[NewValue].Start();
                //SongList[NewValue].Suspend();
            }


        }


        public static void Beep(double frequency, int duration)
        {
            Console.Beep(Convert.ToInt32(frequency), duration);
        }

        public static void Beep(int duration, double frequency, int i)
        {
            Console.Beep(Convert.ToInt32(frequency), duration);
        }

        public static void Sleep(int duration)
        {
            Thread.Sleep(duration);
        }

        public void Death()
        {
            Console.Beep(1000, 50);
            Console.Beep(600, 50);
            Console.Beep(400, 50);
            Console.Beep(200, 50);
            Console.Beep(100, 50);
        }

        static void SongStarter()
        {




        }


        static void Song()
        {
            while (true)
            {
                // 800 = 1/4 note
                // 400 = 8th note
                // 200 16th note

                //----
                Beep(480, 200);

                Beep(1568, 200);

                Beep(1568, 200);

                Beep(1568, 200);



                Beep(739.99, 200);

                Beep(783.99, 200);

                Beep(783.99, 200);

                Beep(783.99, 200);

                

                Beep(369.99, 200);

                Beep(392, 200);

                Beep(369.99, 200);

                Beep(392, 200);



                Beep(392, 400);

                Beep(196, 400);
                
                //---- start

                Beep(739.99, 200);

                Beep(783.99, 200);

                Beep(783.99, 200);

                Beep(739.99, 200);



                Beep(783.99, 200);

                Beep(783.99, 200);

                Beep(739.99, 200);

                Beep(830.99, 200);



                Beep(880, 200);

                Beep(830.61, 200);

                Beep(880, 200);


                Beep(987.77, 400);


                Beep(880, 200);

                Beep(783.99, 200);

                Beep(698.46, 200);

                //----

                Beep(739.99, 200);

                Beep(783.99, 200);

                Beep(783.99, 200);

                Beep(739.99, 200);

                

                Beep(783.99, 200);

                Beep(783.99, 200);

                Beep(739.99, 200);

                Beep(783.99, 200);

                

                Beep(880, 200);

                Beep(830.61, 200);

                Beep(880, 200);

                Beep(987.77, 400);

                //Thread.Sleep(200);

                //Beep(1108, 10);
                Beep(1174.7, 200);
                //Beep(1480, 10);
                Beep(1568, 200);

                Thread.Sleep(200);

                //---

                Beep(739.99, 200);

                Beep(783.99, 200);

                Beep(783.99, 200);

                Beep(739.99, 200);

                Beep(783.99, 200);

                Beep(783.99, 200);

                Beep(739.99, 200);

                Beep(783.99, 200);

                Beep(880, 200);

                Beep(830.61, 200);

                Beep(880, 200);

                Beep(987.77, 400);


                Beep(880, 200);

                Beep(783.99, 200);

                Beep(698.46, 200);


                Beep(659.25, 200);

                Beep(698.46, 200);

                Beep(784, 200);

                Beep(880, 400);

                Beep(784, 200);

                Beep(698.46, 200);

                Beep(659.25, 200);



                Beep(587.33, 200);

                Beep(659.25, 200);

                Beep(698.46, 200);

                Beep(784, 400);

                Beep(698.46, 200);

                Beep(659.25, 200);

                Beep(587.33, 200);



                Beep(523.25, 200);

                Beep(587.33, 200);

                Beep(659.25, 200);

                Beep(698.46, 400);

                Beep(659.25, 200);

                Beep(587.33, 200);

                Beep(493.88, 200);

                Beep(523.25, 200);


                Thread.Sleep(400);
                Beep(349.23, 400);

                Beep(392, 200);

                Beep(329.63, 200);

                Beep(523.25, 200);

                Beep(493.88, 200);

                Beep(466.16, 200);



                Beep(440, 200);

                Beep(493.88, 200);

                Beep(523.25, 200);

                Beep(880, 200);

                Beep(493.88, 200);

                Beep(880, 200);

                Beep(1760, 200);

                Beep(440, 200);



                Beep(392, 200);

                Beep(440, 200);

                Beep(493.88, 200);

                Beep(783.99, 200);

                Beep(440, 200);

                Beep(783.99, 200);

                Beep(1568, 200);

                Beep(392, 200);



                Beep(349.23, 200);

                Beep(392, 200);

                Beep(440, 200);

                Beep(698.46, 200);

                Beep(415.2, 200);

                Beep(698.46, 200);

                Beep(1396.92, 200);

                Beep(349.23, 200);



                Beep(329.63, 200);

                Beep(311.13, 200);

                Beep(329.63, 200);

                Beep(659.25, 200);

                Beep(698.46, 400);

                Beep(783.99, 400);



                Beep(440, 200);

                Beep(493.88, 200);

                Beep(523.25, 200);

                Beep(880, 200);

                Beep(493.88, 200);

                Beep(880, 200);

                Beep(1760, 200);

                Beep(440, 200);



                Beep(392, 200);

                Beep(440, 200);

                Beep(493.88, 200);

                Beep(783.99, 200);

                Beep(440, 200);

                Beep(783.99, 200);

                Beep(1568, 200);

                Beep(392, 200);



                Beep(349.23, 200);

                Beep(392, 200);

                //Beep(440, 00);

                Beep(698.46, 200);

                Beep(659.25, 200);

                Beep(698.46, 200);

                Beep(739.99, 200);

                Beep(783.99, 200);

                Beep(392, 200);

                Beep(392, 200);

                Beep(392, 200);

                Beep(392, 200);

                Beep(196, 200);

                Beep(196, 200);

                Beep(196, 200);



                Beep(185, 200);

                Beep(196, 200);

                Beep(185, 200);

                Beep(196, 200);

                Beep(207.65, 200);

                Beep(220, 200);

                Beep(233.08, 200);

                Beep(246.94, 200);
            }

        }

        static void Mario()
        {
            while (true)
            {
                Console.Beep(659, 125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(523, 125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(784, 125); Thread.Sleep(375); Console.Beep(392, 125); Thread.Sleep(375); Console.Beep(523, 125); Thread.Sleep(250); Console.Beep(392, 125); Thread.Sleep(250); Console.Beep(330, 125); Thread.Sleep(250); Console.Beep(440, 125); Thread.Sleep(125); Console.Beep(494, 125); Thread.Sleep(125); Console.Beep(466, 125); Thread.Sleep(42); Console.Beep(440, 125); Thread.Sleep(125); Console.Beep(392, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(784, 125); Thread.Sleep(125); Console.Beep(880, 125); Thread.Sleep(125); Console.Beep(698, 125); Console.Beep(784, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(587, 125); Console.Beep(494, 125); Thread.Sleep(125); Console.Beep(523, 125); Thread.Sleep(250); Console.Beep(392, 125); Thread.Sleep(250); Console.Beep(330, 125); Thread.Sleep(250); Console.Beep(440, 125); Thread.Sleep(125); Console.Beep(494, 125); Thread.Sleep(125); Console.Beep(466, 125); Thread.Sleep(42); Console.Beep(440, 125); Thread.Sleep(125); Console.Beep(392, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(784, 125); Thread.Sleep(125); Console.Beep(880, 125); Thread.Sleep(125); Console.Beep(698, 125); Console.Beep(784, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(587, 125); Console.Beep(494, 125); Thread.Sleep(375); Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(415, 125); Console.Beep(440, 125); Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(440, 125); Console.Beep(523, 125); Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(698, 125); Thread.Sleep(125); Console.Beep(698, 125); Console.Beep(698, 125); Thread.Sleep(625); Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(415, 125); Console.Beep(440, 125); Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(440, 125); Console.Beep(523, 125); Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(622, 125); Thread.Sleep(250); Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(523, 125); Thread.Sleep(1125); Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(415, 125); Console.Beep(440, 125); Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(440, 125); Console.Beep(523, 125); Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(698, 125); Thread.Sleep(125); Console.Beep(698, 125); Console.Beep(698, 125); Thread.Sleep(625); Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(415, 125); Console.Beep(440, 125); Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(440, 125); Console.Beep(523, 125); Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(622, 125); Thread.Sleep(250); Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(523, 125);
            }
        }

        static void Tetris()
        {
            while (true)
            {
                Console.Beep(658, 125); Console.Beep(1320, 500); Console.Beep(990, 250); Console.Beep(1056, 250); Console.Beep(1188, 250); Console.Beep(1320, 125); Console.Beep(1188, 125); Console.Beep(1056, 250); Console.Beep(990, 250); Console.Beep(880, 500); Console.Beep(880, 250); Console.Beep(1056, 250); Console.Beep(1320, 500); Console.Beep(1188, 250); Console.Beep(1056, 250); Console.Beep(990, 750); Console.Beep(1056, 250); Console.Beep(1188, 500); Console.Beep(1320, 500); Console.Beep(1056, 500); Console.Beep(880, 500); Console.Beep(880, 500); Thread.Sleep(250); Console.Beep(1188, 500); Console.Beep(1408, 250); Console.Beep(1760, 500); Console.Beep(1584, 250); Console.Beep(1408, 250); Console.Beep(1320, 750); Console.Beep(1056, 250); Console.Beep(1320, 500); Console.Beep(1188, 250); Console.Beep(1056, 250); Console.Beep(990, 500); Console.Beep(990, 250); Console.Beep(1056, 250); Console.Beep(1188, 500); Console.Beep(1320, 500); Console.Beep(1056, 500); Console.Beep(880, 500); Console.Beep(880, 500); Thread.Sleep(500); Console.Beep(1320, 500); Console.Beep(990, 250); Console.Beep(1056, 250); Console.Beep(1188, 250); Console.Beep(1320, 125); Console.Beep(1188, 125); Console.Beep(1056, 250); Console.Beep(990, 250); Console.Beep(880, 500); Console.Beep(880, 250); Console.Beep(1056, 250); Console.Beep(1320, 500); Console.Beep(1188, 250); Console.Beep(1056, 250); Console.Beep(990, 750); Console.Beep(1056, 250); Console.Beep(1188, 500); Console.Beep(1320, 500); Console.Beep(1056, 500); Console.Beep(880, 500); Console.Beep(880, 500); Thread.Sleep(250); Console.Beep(1188, 500); Console.Beep(1408, 250); Console.Beep(1760, 500); Console.Beep(1584, 250); Console.Beep(1408, 250); Console.Beep(1320, 750); Console.Beep(1056, 250); Console.Beep(1320, 500); Console.Beep(1188, 250); Console.Beep(1056, 250); Console.Beep(990, 500); Console.Beep(990, 250); Console.Beep(1056, 250); Console.Beep(1188, 500); Console.Beep(1320, 500); Console.Beep(1056, 500); Console.Beep(880, 500); Console.Beep(880, 500); Thread.Sleep(500); Console.Beep(660, 1000); Console.Beep(528, 1000); Console.Beep(594, 1000); Console.Beep(495, 1000); Console.Beep(528, 1000); Console.Beep(440, 1000); Console.Beep(419, 1000); Console.Beep(495, 1000); Console.Beep(660, 1000); Console.Beep(528, 1000); Console.Beep(594, 1000); Console.Beep(495, 1000); Console.Beep(528, 500); Console.Beep(660, 500); Console.Beep(880, 1000); Console.Beep(838, 2000); Console.Beep(660, 1000); Console.Beep(528, 1000); Console.Beep(594, 1000); Console.Beep(495, 1000); Console.Beep(528, 1000); Console.Beep(440, 1000); Console.Beep(419, 1000); Console.Beep(495, 1000); Console.Beep(660, 1000); Console.Beep(528, 1000); Console.Beep(594, 1000); Console.Beep(495, 1000); Console.Beep(528, 500); Console.Beep(660, 500); Console.Beep(880, 1000); Console.Beep(838, 2000);
            }
        }

        static void StarWars()
        {
            while (false)
            {
                Console.Beep(300, 500);
                Thread.Sleep(50);
                Console.Beep(300, 500);
                Thread.Sleep(50);
                Console.Beep(300, 500);
                Thread.Sleep(25);

                Console.Beep(220, 300);
                Console.Beep(350, 200);
                Console.Beep(300, 500);

                Thread.Sleep(25);

                Console.Beep(220, 300);
                Console.Beep(350, 200);
                Console.Beep(300, 500);
            }

            while(true)
            {
                Beep(440, 500);
                Beep(440, 500);
                Beep(440, 500);
                Beep(349, 350);
                Beep(523, 150);

                Beep(440, 500);
                Beep(349, 350);
                Beep(523, 150);
                Beep(440, 1000);

                Beep(659, 500);
                Beep(659, 500);
                Beep(659, 500);
                Beep(698, 350);
                Beep(523, 150);

                Beep(415, 500);
                Beep(349, 350);
                Beep(523, 150);
                Beep(440, 1000);

                Beep(880, 500);
                Beep(440, 350);
                Beep(440, 150);
                Beep(880, 500);
                Beep(830, 250);
                Beep(784, 250);

                Beep(740, 125);
                Beep(698, 125);
                Beep(740, 250);

                Beep(455, 250);
                Beep(622, 500);
                Beep(587, 250);
                Beep(554, 250);

                Beep(523, 125);
                Beep(466, 125);
                Beep(523, 250);

                Beep(349, 125);
                Beep(415, 500);
                Beep(349, 375);
                Beep(440, 125);

                Beep(523, 500);
                Beep(440, 375);
                Beep(523, 125);
                Beep(659, 1000);

                Beep(880, 500);
                Beep(440, 350);
                Beep(440, 150);
                Beep(880, 500);
                Beep(830, 250);
                Beep(784, 250);

                Beep(740, 125);
                Beep(698, 125);
                Beep(740, 250);

                Beep(455, 250);
                Beep(622, 500);
                Beep(587, 250);
                Beep(554, 250);

                Beep(523, 125);
                Beep(466, 125);
                Beep(523, 250);

                Beep(349, 250);
                Beep(415, 500);
                Beep(349, 375);
                Beep(523, 125);

                Beep(440, 500);
                Beep(349, 375);
                Beep(261, 125);
                Beep(440, 1000);
            }
        }

        static void Birthday()
        {
            while (true)
            {
                Thread.Sleep(2000);
                Console.Beep(264, 125);
                Thread.Sleep(250);
                Console.Beep(264, 125);
                Thread.Sleep(125);
                Console.Beep(297, 500);
                Thread.Sleep(125);
                Console.Beep(264, 500);
                Thread.Sleep(125);
                Console.Beep(352, 500);
                Thread.Sleep(125);
                Console.Beep(330, 1000);
                Thread.Sleep(250);
                Console.Beep(264, 125);
                Thread.Sleep(250);
                Console.Beep(264, 125);
                Thread.Sleep(125);
                Console.Beep(297, 500);
                Thread.Sleep(125);
                Console.Beep(264, 500);
                Thread.Sleep(125);
                Console.Beep(396, 500);
                Thread.Sleep(125);
                Console.Beep(352, 1000);
                Thread.Sleep(250);
                Console.Beep(264, 125);
                Thread.Sleep(250);
                Console.Beep(264, 125);
                Thread.Sleep(125);
                Console.Beep(528, 500);
                Thread.Sleep(125);
                Console.Beep(440, 500);
                Thread.Sleep(125);
                Console.Beep(352, 250);
                Thread.Sleep(125);
                Console.Beep(352, 125);
                Thread.Sleep(125);
                Console.Beep(330, 500);
                Thread.Sleep(125);
                Console.Beep(297, 1000);
                Thread.Sleep(250);
                Console.Beep(466, 125);
                Thread.Sleep(250);
                Console.Beep(466, 125);
                Thread.Sleep(125);
                Console.Beep(440, 500);
                Thread.Sleep(125);
                Console.Beep(352, 500);
                Thread.Sleep(125);
                Console.Beep(396, 500);
                Thread.Sleep(125);
                Console.Beep(352, 1000);
            }
        }

        static void BetterMario()
        {
            while (true)
            {
                /*Intro*/
                Beep(330, 100); Sleep(100);
                Beep(330, 100); Sleep(300);
                Beep(330, 100); Sleep(300);
                Beep(262, 100); Sleep(100);
                Beep(330, 100); Sleep(300);
                Beep(392, 100); Sleep(700);
                Beep(196, 100); Sleep(700);
                /*Parte 1*/
                Beep(262, 300); Sleep(300);
                Beep(196, 300); Sleep(300);
                Beep(164, 300); Sleep(300);
                Beep(220, 300); Sleep(100);
                Beep(246, 100); Sleep(300);
                Beep(233, 200);
                Beep(220, 100); Sleep(300);
                Beep(196, 100); Sleep(150);
                Beep(330, 100); Sleep(150);
                Beep(392, 100); Sleep(150);
                Beep(440, 100); Sleep(300);
                Beep(349, 100); Sleep(100);
                Beep(392, 100); Sleep(300);
                Beep(330, 100); Sleep(300);
                Beep(262, 100); Sleep(100);
                Beep(294, 100); Sleep(100);
                Beep(247, 100); Sleep(500);
                /*Parte 1*/
                Beep(262, 300); Sleep(300);
                Beep(196, 300); Sleep(300);
                Beep(164, 300); Sleep(300);
                Beep(220, 300); Sleep(100);
                Beep(246, 100); Sleep(300);
                Beep(233, 200);
                Beep(220, 100); Sleep(300);
                Beep(196, 100); Sleep(150);
                Beep(330, 100); Sleep(150);
                Beep(392, 100); Sleep(150);
                Beep(440, 100); Sleep(300);
                Beep(349, 100); Sleep(100);
                Beep(392, 100); Sleep(300);
                Beep(330, 100); Sleep(300);
                Beep(262, 100); Sleep(100);
                Beep(294, 100); Sleep(100);
                Beep(247, 100); Sleep(900);
                /*Parte 2*/
                Beep(392, 100); Sleep(100);
                Beep(370, 100); Sleep(100);
                Beep(349, 100); Sleep(100);
                Beep(311, 100); Sleep(300);
                Beep(330, 100); Sleep(300);
                Beep(207, 100); Sleep(100);
                Beep(220, 100); Sleep(100);
                Beep(262, 100); Sleep(300);
                Beep(220, 100); Sleep(100);
                Beep(262, 100); Sleep(100);
                Beep(294, 100); Sleep(500);
                Beep(392, 100); Sleep(100);
                Beep(370, 100); Sleep(100);
                Beep(349, 100); Sleep(100);
                Beep(311, 100); Sleep(300);
                Beep(330, 100); Sleep(300);
                Beep(523, 100); Sleep(300);
                Beep(523, 100); Sleep(100);
                Beep(523, 100); Sleep(1100);
                Beep(392, 100); Sleep(100);
                Beep(370, 100); Sleep(100);
                Beep(349, 100); Sleep(100);
                Beep(311, 100); Sleep(300);
                Beep(330, 100); Sleep(300);
                Beep(207, 100); Sleep(100);
                Beep(220, 100); Sleep(100);
                Beep(262, 100); Sleep(300);
                Beep(220, 100); Sleep(100);
                Beep(262, 100); Sleep(100);
                Beep(294, 100); Sleep(500);
                Beep(311, 300); Sleep(300);
                Beep(296, 300); Sleep(300);
                Beep(262, 300); Sleep(1300);
                /*Parte 3*/
                Beep(262, 100); Sleep(100);
                Beep(262, 100); Sleep(300);
                Beep(262, 100); Sleep(300);
                Beep(262, 100); Sleep(100);
                Beep(294, 100); Sleep(300);
                Beep(330, 200); Sleep(50);
                Beep(262, 200); Sleep(50);
                Beep(220, 200); Sleep(50);
                Beep(196, 100); Sleep(700);
                Beep(262, 100); Sleep(100);
                Beep(262, 100); Sleep(300);
                Beep(262, 100); Sleep(300);
                Beep(262, 100); Sleep(100);
                Beep(294, 100); Sleep(100);
                Beep(330, 100); Sleep(700);
                Beep(440, 100); Sleep(300);
                Beep(392, 100); Sleep(500);
                Beep(262, 100); Sleep(100);
                Beep(262, 100); Sleep(300);
                Beep(262, 100); Sleep(300);
                Beep(262, 100); Sleep(100);
                Beep(294, 100); Sleep(300);
                Beep(330, 200); Sleep(50);
                Beep(262, 200); Sleep(50);
                Beep(220, 200); Sleep(50);
                Beep(196, 100); Sleep(700);
                /*Intro*/
                Beep(330, 100); Sleep(100);
                Beep(330, 100); Sleep(300);
                Beep(330, 100); Sleep(300);
                Beep(262, 100); Sleep(100);
                Beep(330, 100); Sleep(300);
                Beep(392, 100); Sleep(700);
                Beep(196, 100); Sleep(700);
                /*Level Clear*/
                Beep(196, 100); Sleep(125);
                Beep(262, 100); Sleep(125);
                Beep(330, 100); Sleep(125);
                Beep(392, 100); Sleep(125);
                Beep(523, 100); Sleep(125);
                Beep(660, 100); Sleep(125);
                Beep(784, 100); Sleep(575);
                Beep(660, 100); Sleep(575);
                Beep(207, 100); Sleep(125);
                Beep(262, 100); Sleep(125);
                Beep(311, 100); Sleep(125);
                Beep(415, 100); Sleep(125);
                Beep(523, 100); Sleep(125);
                Beep(622, 100); Sleep(125);
                Beep(830, 100); Sleep(575);
                Beep(622, 100); Sleep(575);
                Beep(233, 100); Sleep(125);
                Beep(294, 100); Sleep(125);
                Beep(349, 100); Sleep(125);
                Beep(466, 100); Sleep(125);
                Beep(587, 100); Sleep(125);
                Beep(698, 100); Sleep(125);
                Beep(932, 100); Sleep(575);
                Beep(932, 100); Sleep(125);
                Beep(932, 100); Sleep(125);
                Beep(932, 100); Sleep(125);
                Beep(1046, 675);
            }
        }

        static void MissionImpossible()
        {
            while (true)
            {
                Beep(784, 150);
                Sleep(300);
                Beep(784, 150);
                Sleep(300);
                Beep(932, 150);
                Sleep(150);
                Beep(1047, 150);
                Sleep(150);
                Beep(784, 150);
                Sleep(300);
                Beep(784, 150);
                Sleep(300);
                Beep(699, 150);
                Sleep(150);
                Beep(740, 150);
                Sleep(150);
                Beep(784, 150);
                Sleep(300);
                Beep(784, 150);
                Sleep(300);
                Beep(932, 150);
                Sleep(150);
                Beep(1047, 150);
                Sleep(150);
                Beep(784, 150);
                Sleep(300);
                Beep(784, 150);
                Sleep(300);
                Beep(699, 150);
                Sleep(150);
                Beep(740, 150);
                Sleep(150);
                Beep(932, 150);
                Beep(784, 150);
                Beep(587, 1200);
                Sleep(75);
                Beep(932, 150);
                Beep(784, 150);
                Beep(554, 1200);
                Sleep(75);
                Beep(932, 150);
                Beep(784, 150);
                Beep(523, 1200);
                Sleep(150);
                Beep(466, 150);
                Beep(523, 150);
            }
        }

        static void AltStarWars()
        {
            while(true)
            {
                Beep(350, 392, 100); Beep(350, 392, 100); Beep(350, 392, 100); Beep(250, 311.1, 100); Beep(25, 466.2, 100); Beep(350, 392, 100); Beep(250, 311.1, 100); Beep(25, 466.2, 100); Beep(700, 392, 100); Beep(350, 587.32, 100); Beep(350, 587.32, 100); Beep(350, 587.32, 100); Beep(250, 622.26, 100); Beep(25, 466.2, 100); Beep(350, 369.99, 100); Beep(250, 311.1, 100); Beep(25, 466.2, 100); Beep(700, 392, 100); Beep(350, 784, 100); Beep(250, 392, 100); Beep(25, 392, 100); Beep(350, 784, 100); Beep(250, 739.98, 100); Beep(25, 698.46, 100); Beep(25, 659.26, 100); Beep(25, 622.26, 100); Beep(50, 659.26, 400); Beep(25, 415.3, 200); Beep(350, 554.36, 100); Beep(250, 523.25, 100); Beep(25, 493.88, 100); Beep(25, 466.16, 100); Beep(25, 440, 100); Beep(50, 466.16, 400); Beep(25, 311.13, 200); Beep(350, 369.99, 100); Beep(250, 311.13, 100); Beep(25, 392, 100); Beep(350, 466.16, 100); Beep(250, 392, 100); Beep(25, 466.16, 100); Beep(700, 587.32, 100); Beep(350, 784, 100); Beep(250, 392, 100); Beep(25, 392, 100); Beep(350, 784, 100); Beep(250, 739.98, 100); Beep(25, 698.46, 100); Beep(25, 659.26, 100); Beep(25, 622.26, 100); Beep(50, 659.26, 400); Beep(25, 415.3, 200); Beep(350, 554.36, 100); Beep(250, 523.25, 100); Beep(25, 493.88, 100); Beep(25, 466.16, 100); Beep(25, 440, 100); Beep(50, 466.16, 400); Beep(25, 311.13, 200); Beep(350, 392, 100); Beep(250, 311.13, 100); Beep(25, 466.16, 100); Beep(300, 392.00, 150); Beep(250, 311.13, 100); Beep(25, 466.16, 100); Beep(700, 392);
            }
        }

        static void Garble()
        {
            Random randomSounds = new Random(DateTime.Now.Second);
            //for (int index = 0; index < 100; index++)
            while(true)
            {
                Console.Beep(randomSounds.Next(1000) + 100, 200);
            }
        }
    }
}