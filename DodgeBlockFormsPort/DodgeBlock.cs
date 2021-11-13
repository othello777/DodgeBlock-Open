using System;
using System.Net;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using ConsoleGame.GameObjects;
using ConsoleGame.MenuObjects;
using othello7Library;
using DodgeBlockFormsPort;

namespace ConsoleGame
{
    static class DodgeBlock
    {

        #region Globals
        //characters
        public static char Avatar;
        public static char Avatar2;
        public static char BonusPoint;
        public static char Backdrop;
        public static char Block;
        /*public static ConsoleColor AvatarColor;
        public static ConsoleColor BonusPointColor;
        public static ConsoleColor BlockColor;
        public static ConsoleColor BackdropColor;
        */


        public static Random random1 = new Random(DateTime.Now.Millisecond);
        public static Random random2 = new Random(DateTime.Now.Second);
        public static Write write = new Write();
        public static GameMusic music = new GameMusic();
        public static StringBuilder Stringbuilder = new StringBuilder();
        public static KeyCode PressedKey = KeyCode.None;
        public static KeyCode JustPressedKey = KeyCode.None;
        public static string WriteBoard;
        public const string Title = "DodgeBlock " + Version;
        public const string Version = "1.5.2 - 0C";
        public static int MaxMode = 4;
        public static string settingslocation;
        public static string SecretCode = "You have not died yet.";
        public static bool IsNetcore = false;
        public static bool IsMobile = false;
        public static bool IsPortrait = true;
        public static bool loadsuccess;
        public static bool FlasherFlipFlop;
        public static bool PowerFliper;
        public static bool MuteMusic;
        public static bool MuteSfx;
        public static bool Refresh;
        public static bool GodMode;
        public static bool Quitting;
        public static bool TwoPlayerMode;
        public static bool AdminPlayer2;
        public static bool FullScreen;
        public static bool ColorMode;
        public static bool raadmodetimerding;
        public static bool IsHolloween;
        public static bool IsThanksgiving;
        public static bool IsChristmas;
        public static bool UseNewControls;
        public static bool AllowInternet;
        public static bool UseCheckpoints;
        public static int BoardSize;
        public static int ScrResX;
        public static int ScrResY;
        public static int FlasherCounter;
        public static int TimerCounter;
        public static int ScoreFlashTimer;
        public static int explosiontimer;
        public static int snowflaketimer;
        public static int timer10;
        public static int timer100;
        public static int timer300;
        public static int MusicSelector;
        public static ShotC shotc = new ShotC();
        public static Bench BenchFPS = new Bench();
        public static CustomModeC customModeC;
        public static int Ammo;
        public static int Shields;
        public static int Mode;
        public static int Score;
        public static int HighScore;
        public static int Tick;
        public static int BlockTickBase;
        public static int BlockTick;
        public static int BlockTickCounter;
        public static int CurveTimer;
        public static int GameWidth;
        public static int GameHeight;
        public static int Position;
        public static int Position2;
        public static int OldPosition;
        public static int OldPosition2;
        public static GameObject[,] BackBoard;
        public static GameObject[,] UseBoard;
        #endregion

        public static void Game()
        {
            Program.form.TextBoxWriteLine("Start!");
            //init
            Program.form.TextBoxWriteLine("Initializing");
            Initialize();
            Program.form.TextBoxWriteLine("Setting Colors");
            InitConsoleColors();
            Program.form.BlueBackground(false);

            ImportSettings();

            InternetConnect();

            //Start Screen
            StartScreen();

            if (MuteMusic)
                music.PauseMusic();

            if (Mode > MaxMode)
            {
                Tick = 10;
                Avatar = '%';
                Avatar2 = '$';
                Backdrop = 'O';
                BonusPoint = '.';
            }



            Run();



            Program.form.TextBoxWriteLineRtf("\nQuitting...");

            if (MuteMusic == false)
                music.TerminateMusic();
            else
            {
                music.ResumeMusic();
                music.TerminateMusic();
            }

            DiscordDB.die();

            Thread.Sleep(1000);
            Program.form.CloseThis();


        }



        public static void Initialize()
        {
            Avatar = 'O';
            Avatar2 = 'S';
            BonusPoint = '$';
            Backdrop = '.';
            Block = '%';

            Score = 0;

            Mode = 0;
            Ammo = 0;
            Shields = 0;
            MusicSelector = 0;
            FlasherCounter = 0;
            TimerCounter = 0;
            ScoreFlashTimer = 0;
            explosiontimer = 0;
            timer10 = 0;
            timer100 = 0;
            timer300 = 0;
            snowflaketimer = 0;
            HighScore = 1530;
            WriteBoard = "";
            settingslocation = "Settings.txt";
            if (random2.Next(0, 10) % 2 == 1)
                PowerFliper = true;
            else PowerFliper = false;
            MuteMusic = false;
            MuteSfx = false;
            Refresh = true;
            GodMode = false;
            Quitting = false;
            TwoPlayerMode = false;
            AdminPlayer2 = false;
            FullScreen = false;
            ColorMode = true;
            raadmodetimerding = false;
            UseNewControls = true;
            AllowInternet = false;
            UseCheckpoints = true;
            BoardSize = 40;
            ScrResX = 1920;
            ScrResY = 1080;
            Tick = 60;
            BlockTickBase = 6;
            BlockTick = BlockTickBase;
            BlockTickCounter = 0;
            CurveTimer = 0;
            GameWidth = 12;
            GameHeight = 7;
            Position = 6;
            Position2 = 7;
            OldPosition = 6;
            OldPosition2 = 7;
            BackBoard = new GameObject[16, 16];
            write.DestinationFile = settingslocation;

            //Figure out if it is a holiday
            if (HolidayTest.IsHoloween())
            {
                IsHolloween = true;
            }
            else if (HolidayTest.IsThanksgiving())
            {
                IsThanksgiving = true;
            }
            else if (HolidayTest.IsChristmas())
            {
                IsChristmas = true;
            }
            else
            {
                IsHolloween = false;
                IsThanksgiving = false;
                IsChristmas = false;
            }

            customModeC = new CustomModeC();

            //Generate Reference
            for (int i = 0; i < GameHeight; i++)
            {
                for (int j = 0; j < GameWidth; j++)
                {
                    BackBoard[j, i] = new BackDrop();
                }
            }
            UseBoard = BackBoard.Clone() as GameObject[,];

            DiscordDB.DoesWork = false;//= DiscordDB.DiscordInit();

            Program.form.GameInitialized();

            DiscordDB.UpdatePresence();
        }

        public static void ImportSettings()
        {
            Program.form.TextBoxWriteLine("Importing Settings From " + settingslocation);
            try
            {
                //Android.Content.Res.AssetManager assets = App.Assets;
                //string[] Settings = Program.form.Parent.ReadAllLines(settingslocation);
                string[] Settings = File.ReadAllLines(settingslocation);

                MuteMusic = Boolconvert(Settings[5]);
                MuteSfx = Boolconvert(Settings[7]);
                GodMode = Boolconvert(Settings[9]);
                FullScreen = Boolconvert(Settings[11]);
                AllowInternet = Boolconvert(Settings[13]);
                AdminPlayer2 = Boolconvert(Settings[21]);
                customModeC.BoardX = Convert.ToInt32(Settings[15]);
                customModeC.BoardY = Convert.ToInt32(Settings[17]);
                UseNewControls = Boolconvert(Settings[19]);
                Mode = Convert.ToInt32(Settings[23]);
                customModeC.Tick = Convert.ToInt32(Settings[29]);
                MusicSelector = Convert.ToInt32(Settings[37]);
                UseCheckpoints = Boolconvert(Settings[39]);

                music.init();
                customModeC.SettingsChanged();

                if (IsHolloween || IsChristmas)
                {
                    Mode = 4;
                }

                if (FullScreen)
                {
                    Program.form.TextBoxWriteLine("Fullscreening");
                    Program.form.Fullscreen(true);
                }

                loadsuccess = true;
                ImportHighScore();

                TwoPlayerMode = false;
                ColorMode = true;
                ConvertTwoPlayerMode();


            }
            catch (Exception ex)
            {
                Program.form.TextBoxWriteLine("Could not import settings from " + settingslocation + " " + ex);
                Program.form.TextBoxWriteLine("Press any key to continue...");
                if (!IsMobile)
                {
                    Console.Beep();
                    Console.Beep();
                }
                loadsuccess = false;
                ////Console.ReadKey();
                Thread.Sleep(5000);
            }
        }

        public static void InternetConnect()
        {
            //See if we are allowed to use Internet
            if (!AllowInternet)
            {
                bool NotAnswered = true;
                while (NotAnswered)
                {
                    Program.form.TextBoxReplace(
                        "Would you like to allow DodgeBlock \n" +
                        "to connect to dodgeblock.cf to\n" +
                        "retrieve basic information?\n \n" +
                        "Left = Yes | Right = No");

                    if (NativeKeyboard.IsKeyDown(KeyCode.Left))
                    {
                        write.ToThisTxt(13, "1");
                        AllowInternet = true;
                        NotAnswered = false;
                    }
                    if (NativeKeyboard.IsKeyDown(KeyCode.Right))
                    {
                        return;
                    }
                    Thread.Sleep(150);
                }
            }

            Program.form.TextBoxWriteLine("Connecting to dodgeblock.cf");

            bool Newer = false;
            try
            {
                //fix https error
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | (SecurityProtocolType)(0xc0 | 0x300 | 0xc00);

                //Get Website HTML
                string htmlCode;
                using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
                {
                    htmlCode = client.DownloadString("https://dodgeblock.cf/index.html");
                }

                //Calculate if there is a "Newer" version
                int first = htmlCode.IndexOf("<!--$#$-->");
                int last = htmlCode.IndexOf("<!--#$#-->");
                first += 10;
                string DBVER = htmlCode.Substring(first, last - first);


                if (int.Parse(DBVER.Substring(0, 1)) > int.Parse(Version.Substring(0, 1)))
                {
                    Newer = true;
                }

                if (int.Parse(DBVER.Substring(0, 1)) >= int.Parse(Version.Substring(0, 1)))
                {
                    if (int.Parse(DBVER.Substring(2, 1)) > int.Parse(Version.Substring(2, 1)))
                    {
                        Newer = true;
                    }
                }

                if (int.Parse(DBVER.Substring(0, 1)) >= int.Parse(Version.Substring(0, 1)))
                {
                    if (int.Parse(DBVER.Substring(2, 1)) >= int.Parse(Version.Substring(2, 1)))
                    {
                        if (int.Parse(DBVER.Substring(4, 1)) > int.Parse(Version.Substring(4, 1)))
                        {
                            Newer = true;
                        }
                    }
                }
            }
            catch (WebException)
            {
                Program.form.TextBoxWriteLine("Failed to connect");
            }
            catch (Exception)
            {
                Program.form.TextBoxWriteLine("Failed to try to connect");
            }

            //Send Reaction
            bool NotReturned = false;
            if (Newer)
                NotReturned = true;
            while (NotReturned)
            {
                Program.form.TextBoxReplace(
                    "A newer version of DodgeBlock is \n" +
                    "available from the website (dodgeblock.cf) \n \n" +
                    "Press Down to Continue");

                if (NativeKeyboard.IsKeyDown(KeyCode.Down))
                {
                    NotReturned = false;
                }
                Thread.Sleep(150);
            }
        }

        public static void InitConsoleColors()
        {
            StringBuilderSetBackgroundColor = ConsoleColor.Black;
            StringBuilderSetColor = ConsoleColor.White;
        }



        private static void Run()
        {
            //Run
            while (Refresh)
            {

                TestKeydowns();

                PositionPlayers();

                if (ScoreFlashTimer <= TimerCounter && ScoreFlashTimer > TimerCounter - 10 &&
                        ColorMode == true && TimerCounter > 20)
                    InitStringBuilder(ConsoleColor.Magenta);
                else
                    InitStringBuilder(ConsoleColor.White);

                BlockHandling();


                WriteBoard = Stringbuilder.ToString();

                DisplayAndDelay();

                DiscordDB.Update();
                Thread.Sleep(Tick);
            }
        }



        public static void TestKeydowns()
        {
            NativeKeyboard.Update();

            //Test Keydowns
            if (NativeKeyboard.IsKeyDown(KeyCode.Left))
            {
                OldPosition = Position;
                Position = Position - 1;
                if (Position < 0)
                    Position = 0;
            }
            if (NativeKeyboard.IsKeyDown(KeyCode.Right))
            {
                OldPosition = Position;
                Position = Position + 1;
                if (Position > GameWidth - 1)
                    Position = GameWidth - 1;
            }
            if (NativeKeyboard.IsKeyDown(KeyCode.Up))
            {
                if (!shotc.IsAlive && Ammo > 0 && shotc.ShootCooldown == 0)
                {
                    Ammo -= 1;

                    shotc.Y = 0;
                    shotc.X = Position;
                    shotc.IsAlive = true;

                    shotc.ShootCooldown = 4;
                }
            }

            if (NativeKeyboard.IsKeyDown(KeyCode.Down) && AdminPlayer2 == false ||
                NativeKeyboard.IsKeyDown(KeyCode.Down) && TwoPlayerMode == false ||
                    NativeKeyboard.IsKeyDown(KeyCode.S) && AdminPlayer2 && TwoPlayerMode)
            {
                if (Quitting == false)
                {
                    NewSettingsMenu.SettingsMenu();
                }

            }

            if (TwoPlayerMode)
            {

                if (NativeKeyboard.IsKeyDown(KeyCode.A))
                {
                    OldPosition2 = Position2;
                    Position2 = Position2 - 1;
                    if (Position2 < 0)
                        Position2 = 0;
                }
                if (NativeKeyboard.IsKeyDown(KeyCode.D))
                {
                    OldPosition2 = Position2;
                    Position2 = Position2 + 1;
                    if (Position2 > GameWidth - 1)
                        Position2 = GameWidth - 1;
                }


            }

        }



        public static void PositionPlayers()
        {
            //Position
            UseBoard[Position, 0] = new Player(1);
            if (OldPosition != Position && UseBoard[OldPosition, 0].GetType() == new Player(1).GetType())
                UseBoard[OldPosition, 0] = new BackDrop();
            //position player2 (if using)
            if (TwoPlayerMode)
            {
                if (Position == Position2)
                {
                    UseBoard[Position, 0] = new Player(0);
                }
                else
                {
                    UseBoard[Position2, 0] = new Player(2);
                }
                if (OldPosition2 != Position2 && OldPosition2 != Position
                    && UseBoard[OldPosition2, 0].GetType() == new Player(2).GetType())
                    UseBoard[OldPosition2, 0] = new BackDrop();

            }

            //Design Shield (Shell)
            if (Shields > 0)
            {
                if (UseBoard[Position, 1] is BackDrop || UseBoard[Position, 1] is Block || UseBoard[Position, 1] is Shell)
                {
                    if (Shields == 1)
                    {
                        UseBoard[Position, 1] = new Shell('-');
                    }
                    else
                    {
                        UseBoard[Position, 1] = new Shell('=');
                    }
                }

                if (OldPosition != Position && UseBoard[OldPosition, 1] is Shell)
                    UseBoard[OldPosition, 1] = new BackDrop();
            }
        }

        //Display&Delay
        public static void DisplayAndDelay()
        {
            //Display
            WriteToScreen();
            Program.form.TextBoxReplaceRtf(WriteBoard);
            BenchFPS.OnMapUpdated();

            //Delay
            if (GodMode == false)
                Score += 1;
            TimerCounter += 1;
            UpdateDificultyCurve();
            if (Score > HighScore)
                HighScore = Score;
        }

        public static ConsoleColor StringBuilderSetColor
        {
            set
            {

                switch (value)
                {
                    case ConsoleColor.Black:
                        Stringbuilder.Append(@"\cf0");
                        break;
                    case ConsoleColor.White:
                        Stringbuilder.Append(@"\cf1");
                        break;
                    case ConsoleColor.Green:
                        Stringbuilder.Append(@"\cf2");
                        break;
                    case ConsoleColor.Yellow:
                        Stringbuilder.Append(@"\cf3");
                        break;
                    case ConsoleColor.Magenta:
                        Stringbuilder.Append(@"\cf4");
                        break;
                    case ConsoleColor.Red:
                        Stringbuilder.Append(@"\cf5");
                        break;
                    case ConsoleColor.Blue:
                        Stringbuilder.Append(@"\cf6");
                        break;
                    case ConsoleColor.Cyan:
                        Stringbuilder.Append(@"\cf7");
                        break;
                    case ConsoleColor.DarkMagenta:
                        Stringbuilder.Append(@"\cf8");
                        break;
                    case ConsoleColor.DarkGreen:
                        Stringbuilder.Append(@"\cf9");
                        break;
                    case ConsoleColor.DarkGray:
                        Stringbuilder.Append(@"\cf10");
                        break;
                    default:
                        Stringbuilder.Append(@"\cf1");
                        break;
                }


            }
        }

        public static ConsoleColor StringBuilderSetBackgroundColor
        {
            set
            {

                switch (value)
                {
                    case ConsoleColor.Black:
                        Stringbuilder.Append(@"\highlight0");
                        break;
                    case ConsoleColor.White:
                        Stringbuilder.Append(@"\highlight1");
                        break;
                    case ConsoleColor.Magenta:
                        Stringbuilder.Append(@"\highlight4");
                        break;
                    case ConsoleColor.Green:
                        Stringbuilder.Append(@"\highlight2");
                        break;
                    case ConsoleColor.Yellow:
                        Stringbuilder.Append(@"\highlight3");
                        break;
                    case ConsoleColor.Red:
                        Stringbuilder.Append(@"\highlight5");
                        break;
                    case ConsoleColor.Blue:
                        Stringbuilder.Append(@"\highlight6");
                        break;
                    case ConsoleColor.Cyan:
                        Stringbuilder.Append(@"\highlight7");
                        break;
                    default:
                        Stringbuilder.Append(@"\highlight0");
                        break;

                }


            }
        }

        public static void InitStringBuilder(ConsoleColor color)
        {
            //prepare Stringbuilder
            Stringbuilder.Clear();
            Stringbuilder.Append(@"\fs" + BoardSize);
            StringBuilderSetColor = color;
            if (Mode == 4 && customModeC.CustomModeAble)
                Stringbuilder.Append(@"        Score:" + Score + @" \line\line "
                   + "                     " + Math.Round(BenchFPS.DoGetFps(), 5) + "FPS");
            else
                Stringbuilder.Append(@"        Score:" + Score + @" \line   High Score:" + HighScore + @" \line "
                   + "                     " + Math.Round(BenchFPS.DoGetFps(), 5) + "FPS");
        }



        public static void WriteToScreen()
        {
            int Margin = 5;
            string[] BoardToSide = new string[]
            {
                "Player1 Arrow Keys",
                "Left&Right = Move",
                "Down = Settings",
                "",
                "",
                "",
                ""
            };
            if (Mode == 1)
                BoardToSide[3] = "Up = Shoot";

            if (TwoPlayerMode)
            {
                BoardToSide[4] = "Player2 WSAD";
                BoardToSide[5] = "A&D = Move";
                BoardToSide[6] = "S = Settings";
            }

            InitConsoleColors();

            for (int i = GameHeight - 1; i >= 0; i--)
            {
                if (Score == HighScore && !(Mode == 4 && customModeC.CustomModeAble) && Flasher() ||
                    ScoreFlashTimer <= TimerCounter && ScoreFlashTimer > TimerCounter - 10 && ColorMode == true && TimerCounter > 20 ||
                    CheckPointFlasher())
                {
                    StringBuilderSetColor = ConsoleColor.Yellow;

                    if (ScoreFlashTimer <= TimerCounter && ScoreFlashTimer > TimerCounter - 10 && ColorMode == true && TimerCounter > 20)
                        StringBuilderSetColor = ConsoleColor.Magenta;

                    if (CheckPointFlasher())
                        StringBuilderSetColor = ConsoleColor.Cyan;
                    Stringbuilder.Append(@"\line  | ");
                    InitConsoleColors();
                }
                else
                    Stringbuilder.Append(@"\line    ");

                for (int j = 0; j < GameWidth; j++)
                {
                    StringBuilderSetBackgroundColor = UseBoard[j, i].BackColor;

                    StringBuilderSetColor = UseBoard[j, i].Color;
                    Stringbuilder.Append(UseBoard[j, i].Character);
                }

                Stringbuilder.Append(@"\highlight0 ");

                if (Score == HighScore && !(Mode == 4 && customModeC.CustomModeAble) && Flasher() ||
                    ScoreFlashTimer <= TimerCounter && ScoreFlashTimer > TimerCounter - 10 && TimerCounter > 20 ||
                    CheckPointFlasher())
                {
                    StringBuilderSetColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Black;

                    if (ScoreFlashTimer <= TimerCounter && ScoreFlashTimer > TimerCounter - 10 && TimerCounter > 20)
                        StringBuilderSetColor = ConsoleColor.Magenta;

                    if (CheckPointFlasher())
                        StringBuilderSetColor = ConsoleColor.Cyan;

                    Stringbuilder.Append("  |");
                }
                else
                {
                    Stringbuilder.Append("  ");
                }
                InitConsoleColors();

                for (int m = 0; m < Margin; m++)
                {
                    Stringbuilder.Append(" ");
                }
                if (!(IsMobile && IsPortrait))
                    if (GameHeight - 1 - i < BoardToSide.Length)
                        Stringbuilder.Append(BoardToSide[GameHeight - 1 - i]);
            }
            if (IsMobile && IsPortrait)
            {
                Stringbuilder.Append("\n");
                for (int i = 0; i < 3; i++)
                    Stringbuilder.Append("\n" + BoardToSide[i]);
            }

            BoardAppend();

            WriteBoard = Stringbuilder.ToString();
        }


        public static bool Flasher()
        {
            if (TimerCounter >= FlasherCounter + 10)
            {
                FlasherCounter = TimerCounter;
                if (FlasherFlipFlop)
                    FlasherFlipFlop = false;
                else
                    FlasherFlipFlop = true;
            }

            return FlasherFlipFlop;
        }

        public static void FallingObjectTimers()
        {
            if (TimerCounter >= timer10 + 10)
            {
                timer10 = TimerCounter;
            }

            if (TimerCounter >= timer100 + 100)
            {
                timer100 = TimerCounter;
            }

            if (TimerCounter >= timer300 + 300)
            {
                timer300 = TimerCounter;
            }
        }


        public static void UpdateDificultyCurve()
        {
            CurveTimer += 1;
            if (CurveTimer >= 250 && BlockTick > 0)
            {
                BlockTick -= 1;
                CurveTimer = 0;
            }
        }

        public static void StringBuilderBuild()
        {

            //Turn Arrays into a String
            for (int i = GameHeight - 1; i >= 0; i--)
            {
                if (ColorMode)
                {
                    if (Score == HighScore && Flasher() || ScoreFlashTimer <= TimerCounter &&
                        ScoreFlashTimer > TimerCounter - 10 && TimerCounter > 20)
                    {

                        Stringbuilder.Append(@"\line  | ");

                    }
                    else
                        Stringbuilder.Append(@"\line    ");
                }
                else
                {
                    if (Score == HighScore && Flasher() || ScoreFlashTimer <= TimerCounter &&
                        ScoreFlashTimer > TimerCounter - 10 && TimerCounter > 20)
                    {

                        Stringbuilder.Append("\n  | ");

                    }
                    else
                        Stringbuilder.Append("\n    ");
                }
                for (int j = 0; j < GameWidth; j++)
                {
                    Stringbuilder.Append(UseBoard[j, i].Character);
                }

                if (Score == HighScore && Flasher() || ScoreFlashTimer <= TimerCounter &&
                    ScoreFlashTimer > TimerCounter - 10 && TimerCounter > 20)
                {

                    Stringbuilder.Append(" |  ");

                }

            }

            WriteBoard = Stringbuilder.ToString();
        }

        public static void BoardAppend()
        {
            if (Mode == 1 || Mode == 4 && !customModeC.CustomModeAble)
            {
                StringBuilderSetColor = ConsoleColor.White;

                Stringbuilder.Append(@"\line\line Ammo = " + Ammo + " Shields = " + Shields);

                InitConsoleColors();
            }
        }

        public static void DeathScreen(int Place)
        {
            void deathinit()
            {
                Stringbuilder.Clear();
                Stringbuilder.Append(@"\fs" + BoardSize);
                StringBuilderSetColor = ConsoleColor.Red;
                Stringbuilder.Append(@"\line\line ");
            }
            if (ColorMode)
            {
                deathinit();
                UseBoard[Place, 0].Character = '#';
                StringBuilderBuild();
                Program.form.TextBoxReplaceRtf(WriteBoard);
                Thread.Sleep(700);

                deathinit();
                UseBoard[Place, 0].Character = '@';
                StringBuilderBuild();
                Program.form.TextBoxReplaceRtf(WriteBoard);
                Thread.Sleep(700);

                deathinit();
                UseBoard[Place, 0].Character = 'X';
                StringBuilderBuild();
                Program.form.TextBoxReplaceRtf(WriteBoard);
                Thread.Sleep(1400);
            }
            else
            {
                UseBoard[Place, 0].Character = '#';
                StringBuilderBuild();
                Program.form.TextBoxReplace(WriteBoard);
                Thread.Sleep(700);

                InitStringBuilder(ConsoleColor.White);
                UseBoard[Place, 0].Character = '@';
                StringBuilderBuild();
                Program.form.TextBoxReplace(WriteBoard);
                Thread.Sleep(700);

                InitStringBuilder(ConsoleColor.White);
                UseBoard[Place, 0].Character = 'X';
                StringBuilderBuild();
                Program.form.TextBoxReplace(WriteBoard);
                Thread.Sleep(1400);
            }
        }

        //ye old code
        public static void ChangeResolution(int ResolutionX, int ResolutionY)
        {
            string FileName = @"c:\qres\qres.exe";
            string FileName2 = @"qres\qres.exe";
            try
            {
                Process proc = new Process();

                proc.StartInfo.FileName = FileName; // put full path in here
                proc.StartInfo.Arguments = ("/x " + ResolutionX + " /y " + ResolutionY).ToString(); // say
                proc.Start();
                proc.WaitForExit();
            }
            catch (System.ComponentModel.Win32Exception)
            {
                try
                {
                    Process proc = new Process();

                    proc.StartInfo.FileName = FileName2; // put full path in here
                    proc.StartInfo.Arguments = ("/x " + ResolutionX + " /y " + ResolutionY).ToString(); // say
                    proc.Start();
                    proc.WaitForExit();
                }
                catch (System.ComponentModel.Win32Exception)
                {


                    Program.form.TextBoxWriteLine("Fullscreen Mode Error\nUnable to locate " + FileName + " or " + FileName2 +
                        "\nPlease Specify the location of QRes.exe");
                    Program.form.TextBoxWriteLine("Press any key to continue...");
                    Console.Beep();
                    Console.Beep();
                    //Console.ReadKey();
                    FullScreen = false;
                }
            }
        }

        static void BlockHandling()
        {
            //=======V====Falling=Objects====V======

            //H axis
            for (int i = 0; i < GameHeight; i++)
            {
                //W axis
                for (int j = 0; j < GameWidth; j++)
                {
                    //only on block tick
                    if (BlockTickCounter == 0)
                    {
                        if (UseBoard[j, i] is FallingObject)
                        {
                            //testfor Bonus
                            if (UseBoard[j, i] is BonusPoints)
                            {
                                UseBoard[j, i] = new BackDrop();

                                //if not on bottom row
                                if (i != 0)
                                {
                                    UseBoard[j, i - 1] = new BonusPoints();

                                    if ((GodMode == false) && (j == Position && i == 1 || TwoPlayerMode == true && j == Position2 && i == 1))
                                    {
                                        Score += 50;

                                        ScoreFlashTimer = TimerCounter;
                                    }
                                }
                            }

                            //testfor PowerUp
                            if (UseBoard[j, i] is Blaster)
                            {
                                UseBoard[j, i] = new BackDrop();

                                //if not on bottom row
                                if (i != 0)
                                {
                                    UseBoard[j, i - 1] = new Blaster();

                                    if ((GodMode == false) && (j == Position && i == 1 || TwoPlayerMode == true && j == Position2 && i == 1))
                                    {
                                        Ammo += 3;
                                    }
                                }
                            }
                            if (UseBoard[j, i] is Shield)
                            {
                                UseBoard[j, i] = new BackDrop();

                                //if not on bottom row
                                if (i != 0)
                                {
                                    UseBoard[j, i - 1] = new Shield();

                                    if ((GodMode == false) && (j == Position && i == 1 || TwoPlayerMode == true && j == Position2 && i == 1))
                                    {
                                        Shields += 1;
                                    }
                                }
                            }

                            if (UseBoard[j, i] is HalloweenBomb)
                            {
                                UseBoard[j, i] = new BackDrop();

                                //if not on bottom row
                                if (i != 0)
                                {
                                    UseBoard[j, i - 1] = new HalloweenBomb();

                                    if ((j == Position && i == 1 || TwoPlayerMode == true && j == Position2 && i == 1))
                                    {
                                        for (int z = 0; z < GameHeight; z++)
                                        {
                                            for (int l = 0; l < GameWidth; l++)
                                            {
                                                if (UseBoard[l, z] is Block)
                                                {
                                                    UseBoard[l, z] = new BackDrop();
                                                }
                                            }
                                        }
                                        explosiontimer = 5;
                                        Program.form.OrangeBackground(true);
                                    }
                                }
                            }

                            if (UseBoard[j, i] is Snowflake)
                            {
                                UseBoard[j, i] = new BackDrop();

                                //if not on bottom row
                                if (i != 0)
                                {
                                    UseBoard[j, i - 1] = new Snowflake();

                                    if ((j == Position && i == 1 || TwoPlayerMode == true && j == Position2 && i == 1))
                                    {
                                        /*for (int z = 0; z < GameHeight; z++)
                                        {
                                            for (int l = 0; l < GameWidth; l++)
                                            {
                                                if (UseBoard[l, z] is Block)
                                                {
                                                    UseBoard[l, z] = new BackDrop();
                                                }
                                            }
                                        }*/
                                        snowflaketimer = 50;
                                    }
                                }
                            }



                            //move blocks
                            if (UseBoard[j, i] is Block || raadmodetimerding)//testforblock
                            {
                                UseBoard[j, i] = new BackDrop();

                                if (i != 0)//if not on bottom row
                                {

                                    if (j == Position && i == 2 && Shields > 0)
                                    {
                                        Shields -= 1;

                                        if (Shields == 0 && UseBoard[j, i - 1] is Shell)
                                        {
                                            UseBoard[j, i - 1] = new BackDrop();
                                        }
                                    }
                                    else
                                        UseBoard[j, i - 1] = new Block();

                                    //would a player die? then kill them if they are not god.
                                    if ((GodMode == false) && (j == Position && i == 1 ||
                                        TwoPlayerMode == true && j == Position2 && i == 1) || raadmodetimerding)
                                    {
                                        OnDeath(j);
                                    }

                                }
                            }
                        }
                        //DiscordDB.UpdatePresence();
                    }//End of blocktick
                }
            }

            //add falling objects
            if (BlockTickCounter == 0)
            {
                //add Blocks or raaadmodethingies
                if (Mode > MaxMode)
                    UseBoard[random1.Next(0, GameWidth), GameHeight - 1] = new BonusPoints();
                else
                {
                    if (Mode == 4 && customModeC.CustomModeAble)
                    {
                        for (int i = 0; customModeC.Blocks > i; i++)
                        {
                            UseBoard[random1.Next(0, GameWidth), GameHeight - 1] = new Block();
                        }
                    }
                    else
                    {
                        if (snowflaketimer > 0)
                            UseBoard[random1.Next(0, GameWidth), GameHeight - 1] = new BonusPoints();
                        else
                            UseBoard[random1.Next(0, GameWidth), GameHeight - 1] = new Block();

                        if (Mode == 2)
                        {
                            UseBoard[random1.Next(0, GameWidth), GameHeight - 1] = new Block();
                            UseBoard[random1.Next(0, GameWidth), GameHeight - 1] = new Block();
                        }
                    }
                }
            }



            //Power-Up stuff
            if (snowflaketimer > 0)
            {
                snowflaketimer -= 1;
            }
            if (explosiontimer > 0)
            {
                explosiontimer -= 1;
                if (explosiontimer == 1)
                {
                    for (int z = 0; z < GameHeight; z++)
                    {
                        for (int l = 0; l < GameWidth; l++)
                        {
                            if (UseBoard[l, z] is Block)
                            {
                                UseBoard[l, z] = new BackDrop();
                            }
                        }
                    }
                    Program.form.OrangeBackground(false);
                }
            }
            FallingObjectTimers();
            if (Mode == 1 || Mode == 4 && !(Mode == 4 && customModeC.CustomModeAble))
            {
                if (timer100 == TimerCounter && TimerCounter != 0)//add bonuspoints
                    UseBoard[random2.Next(0, GameWidth), GameHeight - 1] = new BonusPoints();


                if (CurveTimer == 0 && TimerCounter != 0)//add superpower
                {
                    if (Mode == 4 && IsHolloween)
                    {
                        UseBoard[random2.Next(0, GameWidth), GameHeight - 1] = new HalloweenBomb();
                    }
                    if (Mode == 4 && IsChristmas)
                    {
                        UseBoard[random2.Next(0, GameWidth), GameHeight - 1] = new Snowflake();
                    }
                    else if (PowerFliper)
                    {
                        UseBoard[random2.Next(0, GameWidth), GameHeight - 1] = new Blaster();
                        PowerFliper = false;
                    }
                    else if (!PowerFliper)
                    {
                        UseBoard[random2.Next(0, GameWidth), GameHeight - 1] = new Shield();
                        PowerFliper = true;
                    }
                }


                //Move Shot
                if (shotc.IsAlive)
                {
                    //kill block that is on shot
                    if (UseBoard[shotc.X, shotc.Y] is Block && shotc.IsAlive)
                    {
                        shotc.IsAlive = false;
                        UseBoard[shotc.X, shotc.Y] = new BackDrop();
                    }

                    //move shot
                    if (shotc.Y != 0)
                        UseBoard[shotc.X, shotc.Y] = new BackDrop();
                    if (shotc.Y < GameHeight - 1 && shotc.IsAlive)
                    {
                        shotc.Y += 1;

                        //kill block that shot moved onto
                        if (UseBoard[shotc.X, shotc.Y] is Block)
                        {
                            shotc.IsAlive = false;
                            UseBoard[shotc.X, shotc.Y] = new BackDrop();
                        }

                        if (shotc.IsAlive)
                            UseBoard[shotc.X, shotc.Y] = new Shot();
                    }
                    else
                        shotc.IsAlive = false;
                }
                if (shotc.ShootCooldown > 0)
                {
                    shotc.ShootCooldown -= 1;
                }
            }
            if (TimerCounter == 1500 && Mode > MaxMode)
            {
                raadmodetimerding = true;
            }

            //Update Block Tick
            if (BlockTickCounter > 0)
                BlockTickCounter = BlockTickCounter - 1;
            else
                BlockTickCounter = BlockTick;


        }   //=====/\===================/\======

        public static void OnDeath(int j)
        {
            music.PauseMusic();

            if (MuteSfx == false)
                music.DieNoise();

            // log highscore
            if (loadsuccess && Score == HighScore && !(Mode == 4 && customModeC.CustomModeAble))
            {
                if (Mode == 0)
                    write.ToThisTxt(1, HighScore.ToString());
                else if (Mode == 1)
                    write.ToThisTxt(25, HighScore.ToString());
                else if (Mode == 2)
                    write.ToThisTxt(33, HighScore.ToString());
                else if (Mode == 3)
                    write.ToThisTxt(3, HighScore.ToString());
                else if (Mode == 4 && IsHolloween)
                    write.ToThisTxt(27, HighScore.ToString());
                else if (Mode == 4 && IsChristmas)
                    write.ToThisTxt(35, HighScore.ToString());
            }

            // setting deathscreen
            void OnPostDeathScreen()
            {
                Stringbuilder.Clear();

                if (IsHolloween)
                {
                    StringBuilderSetColor = ConsoleColor.DarkMagenta;
                    Stringbuilder.Append(@"\fs" + BoardSize + " ");
                }
                else if (IsThanksgiving)
                {
                    StringBuilderSetColor = ConsoleColor.DarkGray;
                    Stringbuilder.Append(@"\fs" + BoardSize + " ");
                }
                else
                {
                    StringBuilderSetColor = ConsoleColor.Cyan;
                    Stringbuilder.Append(@"\fs" + BoardSize + " ");
                }
            }
            // add endline
            void LineBreak()
            {
                if (ColorMode)
                    Stringbuilder.Append(@"\line ");
                else
                    Stringbuilder.Append("\n");
            }

            // kill the bloody loser
            if (TwoPlayerMode)
            {
                if (j == Position && j == Position2)
                {
                    DeathScreen(Position);
                    OnPostDeathScreen();
                    Stringbuilder.Append("Both Players Died!");
                }
                else if (j == Position2)
                {
                    DeathScreen(Position2);
                    OnPostDeathScreen();
                    Stringbuilder.Append("Player2 Died! (" + Avatar2 + ")");
                }
                else
                {
                    DeathScreen(Position);
                    OnPostDeathScreen();
                    Stringbuilder.Append("Player1 Died! (" + Avatar + ")");
                }
            }
            else
            {
                DeathScreen(Position);
                OnPostDeathScreen();
                Stringbuilder.Append("You Died!");
            }
            LineBreak();



            // add the results
            Stringbuilder.Append("Your Score: " + Score);
            LineBreak();
            if (!(Mode == 4 && customModeC.CustomModeAble))
            {
                if (Score >= HighScore)
                {
                    if (ColorMode)
                        StringBuilderSetColor = ConsoleColor.Yellow;
                    Stringbuilder.Append("*New High Score!*");
                    if (IsHolloween)
                    {
                        StringBuilderSetColor = ConsoleColor.DarkMagenta;
                    }
                    else if (IsThanksgiving)
                    {
                        StringBuilderSetColor = ConsoleColor.DarkGray;
                    }
                    else
                    {
                        StringBuilderSetColor = ConsoleColor.Cyan;
                    }
                    LineBreak();
                }
                else
                {
                    Stringbuilder.Append("High Score: " + HighScore);
                    LineBreak();

                }
            }


            Stringbuilder.Append("Playing: ");
            if (Mode == 0)
            {
                Stringbuilder.Append("Classic Mode");
            }
            else if (Mode == 1)
            {
                Stringbuilder.Append("Normal Mode");
            }
            else if (Mode == 2)
            {
                Stringbuilder.Append("Expert Mode");
            }
            else if (Mode == 3)
            {
                Stringbuilder.Append("Two Player Mode");
            }
            else if (Mode == 4 && IsHolloween)
            {
                Stringbuilder.Append("Halloween Event");
            }
            else if (Mode == 4 && IsChristmas)
            {
                Stringbuilder.Append("Winter Event");
            }
            else if (Mode == 4)
            {
                Stringbuilder.Append("Custom Mode");
            }
            else
            {
                Stringbuilder.Append("raaad mode");
            }
            if ((Mode == 0 || Mode == 2) && UseCheckpoints)
            {
                if (Score > 500)
                    LineBreak();
                if (Score > 1000)
                    Stringbuilder.Append("Checkpoint Achieved: 1000");
                else if (Score > 500)
                    Stringbuilder.Append("Checkpoint Achieved: 500");
            }
            if (IsNetcore)
            {
                LineBreak();
                Stringbuilder.Append("Secret Code written to Settings.txt");
            }
            LineBreak();
            LineBreak();
            Stringbuilder.Append("Press Up to Continue");
            LineBreak();
            Stringbuilder.Append("Press Down to Quit");

            WriteBoard = Stringbuilder.ToString();
            if (ColorMode)
                Program.form.TextBoxReplaceRtf(WriteBoard);
            else
                Program.form.TextBoxReplace(WriteBoard);


            if (loadsuccess)
            {
                string modeAppend;
                if (Mode == 0)
                    modeAppend = "C";
                else if (Mode == 1)
                    modeAppend = "N";
                else if (Mode == 2)
                    modeAppend = "H";
                else if (Mode == 3)
                    modeAppend = "T";
                else if (Mode == 4 && (IsHolloween))
                    modeAppend = "HW-EVNT";
                else if (Mode == 4 && (IsChristmas))
                    modeAppend = "CHR-EVNT";
                else if (Mode == 4 && (Mode == 4 || customModeC.CustomModeAble))
                    modeAppend = "CSTM";
                else
                    modeAppend = "R";
                SecretCode = Crypto.EncryptStringAES(Score.ToString() + modeAppend + "-" + Version, Crypto.sharedsecret);
                write.ToThisTxt(31, SecretCode);
                Program.form.GameInitialized();
            }
            else
            {
                SecretCode = "WARNING: Settings.txt not loaded correctly. Please ensure that Settings.txt and Dodgeblock.exe are in the same directory and not zipped!";
                Program.form.GameInitialized();
            }

            DiscordDB.UpdatePresence();

            bool go = true;
            while (go)
            {
                if (NativeKeyboard.IsKeyDown(KeyCode.Up))
                {
                    go = false;
                }
                if (NativeKeyboard.IsKeyDown(KeyCode.Down))
                {
                    go = false;
                    Refresh = false;
                    Quitting = true;


                }
                Thread.Sleep(80);
            }

            int savescore = TimerCounter;
            ResetGame();
            DoCheckPoints(savescore);

            if (MuteMusic == false)
                music.ResumeMusic();
            InitConsoleColors();
        }

        public static void ResetGame()
        {
            Tick = 60;
            if (Mode > MaxMode)
                Tick = 10;
            if (Mode < 4)
                snowflaketimer = 0;
            Score = 0;
            Ammo = 0;
            Shields = 0;
            CurveTimer = 0;
            GameWidth = 12;
            GameHeight = 7;
            BlockTick = BlockTickBase;
            for (int i = 0; i < GameHeight; i++)
            {
                for (int j = 0; j < GameWidth; j++)
                {
                    BackBoard[j, i] = new BackDrop();
                }
            }
            UseBoard = BackBoard.Clone() as GameObject[,];
            TimerCounter = 0;
            ScoreFlashTimer = 0;
            timer10 = 0;
            timer100 = 0;
            timer300 = 0;
            raadmodetimerding = false;

            customModeC.SettingsChanged();
        }

        public static void DoCheckPoints(int savescore)
        {
            if ((Mode == 0 || Mode == 2) && UseCheckpoints)
            {
                if (savescore >= 1000)
                {
                    Score = 1000;
                    TimerCounter = 1000;
                    BlockTick = BlockTickBase - 4;
                }
                else if (savescore >= 500)
                {
                    Score = 500;
                    TimerCounter = 500;
                    BlockTick = BlockTickBase - 2;
                }
            }
        }

        public static bool CheckPointFlasher()
        {
            if ((Mode == 0 || Mode == 2) && UseCheckpoints)
                if ((Score >= 1000 && Score <= 1010) || (Score >= 500 && Score <= 510))
                    return true;
            return false;
        }

        //also ye old code
        static void SettingsMenu()
        {
            Program.form.TextBoxReplace("");
            music.PauseMusic();

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;

            Program.form.TextBoxWriteLine(
"###########Settings###########\n" +
"#                            #\n" +
"#    Right = Mute/Unmute     #\n" +
"#    Left =  Quit & Quit     #\n" +
"#    Up = Return to Game     #\n" +
"#                            #\n" +
"##############################\n");
            int ButtonCooldown = 0;
            bool NotReturned = true;

            while (NotReturned)
            {
                if (NativeKeyboard.IsKeyDown(KeyCode.Left))
                {
                    Refresh = false;
                    NotReturned = false;
                    InitConsoleColors();
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                if (NativeKeyboard.IsKeyDown(KeyCode.Right))
                {
                    if (MuteMusic == true && ButtonCooldown == 0)
                    {
                        Program.form.TextBoxWriteLine("Unmuted");
                        MuteMusic = false;
                        ButtonCooldown = 5;
                    }
                    else if (MuteMusic == false && ButtonCooldown == 0)
                    {
                        Program.form.TextBoxWriteLine("Muted");
                        MuteMusic = true;
                        ButtonCooldown = 5;
                    }

                }

                if (NativeKeyboard.IsKeyDown(KeyCode.Up))
                {
                    NotReturned = false;
                    InitConsoleColors();
                }

                if (ButtonCooldown > 0)
                    ButtonCooldown = ButtonCooldown - 1;

                System.Threading.Thread.Sleep(60);
            }
            if (MuteMusic == false)
                music.ResumeMusic();
            Program.form.TextBoxReplace("");

        }

        static void StartScreen()
        {
            Program.form.TextBoxWriteLine("CONGRATS! starting.");
            Thread.Sleep(1000);

            if (IsChristmas)
                Cutscene();

            bool NotStarted = true;
            while (NotStarted)
            {
                if (IsHolloween)
                {
                    Program.form.TextBoxReplace("        Version " + DodgeBlock.Version + "  \n" +
                "################################\n" +
                "#.._____.....Happy......_____..#\n" +
                "#./.....\\.@@@@@@@@@@@@ /.....\\.#\n" +
                "#|.0...0.|@ Press Up @|.0...0.|#\n" +
                "#.\\..A../.@@@@@@@@@@@@.\\..A../.#\n" +
                "#..|||||...Halloween!...|||||..#\n" +
                "################################\n" +
                "\n       (c) othello7 2020");
                }
                else if (IsThanksgiving)
                {
                    Program.form.TextBoxReplace("        Version " + DodgeBlock.Version + "  \n" +
                "################################\n" +
               @"#.|\....Happy.......@ Press Up #" + "\n" +
                "#.| `-._,=''' =,....@@@@@@@@@@@#\n" +
               @"#.\    //o.-)-.\.Thanksgiving!.#" + "\n" +
               @"#..\   ||/:/:\:\-..............#" + "\n" +
               @"#...`. \\\:\:/:/ o_),..........#" + "\n" +
               @"#.....`->>> 8888 >; (_)o.......#" + "\n" +
                "################################\n" +
                "\n       (c) othello7 2020");

                }
                else if (IsChristmas)
                {
                    Program.form.TextBoxReplace("        Version " + DodgeBlock.Version + "  \n" +
                @"################################" + "\n" +
                @"#..._._................../*\...#" + "\n" +
                @"#..(_X_)..@@@@@@@@@@@@..// \\..#" + "\n" +
                @"#.[  |  ].@ Press Up @./// \\\.#" + "\n" +
                @"#.[--+--].@@@@@@@@@@@@//// \\\\#" + "\n" +
                @"#.[  |  ]................| |...#" + "\n" +
                @"################################" + "\n" +
                "\n       (c) othello7 2020");
                }
                else
                {
                    //Start Screen
                    Animations.PlayAnimatedStartScreen();
                }

                if (NativeKeyboard.IsKeyDown(KeyCode.Up))
                {
                    NotStarted = false;
                }
                System.Threading.Thread.Sleep(150);
            }
            if (IsMobile && IsPortrait)
                Program.form.ZoomTextBox(20);

            Program.form.TextBoxReplace("");
            music.PlayMusic();
        }

        public static void ConvertTwoPlayerMode()
        {
            if (Mode == 3)
                TwoPlayerMode = true;
            else
                TwoPlayerMode = false;
        }

        public static string Boolconvert(bool setting)
        {
            string str;
            if (setting)
                str = "1";
            else
                str = "0";
            return str;
        }
        public static bool Boolconvert(string setting)
        {
            bool boolean;
            if (setting == "1")
                boolean = true;
            else
                boolean = false;
            return boolean;
        }
        public static void ImportHighScore()
        {
            if (loadsuccess)
            {
                try
                {
                    string[] Settings = File.ReadAllLines(settingslocation);

                    if (Mode == 0)
                    {
                        HighScore = Convert.ToInt32(Settings[1]);
                    }
                    else if (Mode == 1)
                    {
                        HighScore = Convert.ToInt32(Settings[25]);
                    }
                    else if (Mode == 2)
                    {
                        HighScore = Convert.ToInt32(Settings[33]);
                    }
                    else if (Mode == 3)
                    {
                        HighScore = Convert.ToInt32(Settings[3]);
                    }
                    else if (Mode == 4 && IsHolloween)
                    {
                        HighScore = Convert.ToInt32(Settings[27]);
                    }
                    else if (Mode == 4 && IsChristmas)
                    {
                        HighScore = Convert.ToInt32(Settings[35]);
                    }

                }
                catch (Exception ex)
                {
                    Program.form.TextBoxWriteLine("Could not import settings from " + settingslocation + " " + ex);
                    Console.Beep();
                    Console.Beep();
                    Thread.Sleep(777);
                }
            }
        }

        //AGAIN whats with all this elden code?
        public static string Code(string Input)
        {
            char[] charArray = Input.ToCharArray();

            int[] intarray = new int[charArray.Length];

            for (int i = 0; i < charArray.Length; i++)
            {
                intarray[i] = (int)charArray[i] + 17;

                charArray[i] = (char)intarray[i];
            }

            string b = new string(charArray);
            return b;
        }

        public static void Cutscene()
        {
            Program.form.ZoomTextBox(Program.form.ZoomTextBox() / 1.5f, true);
            List<string> Playmation = new List<string>() {
@"                                                  /\
        _____                                    /* \
       /_    \_                                 /  ^ \
      // \_____\                               / *  o \
     (_) {______}                             /_  - $ _\
          ######                               / o    \
         #      #           _ _               /_  $ * _\
        #        #         (_V_)               / % o  \ 
        #        #         __V__              /____ ___\
        #        #        [  |  ]                 [ ]
         #      #         [--+--]                 [ ]
          ######          [  |  ]                 [ ]
-------------------------------------------------------
",
@"                                                  /\
        _____                                    /* \
       /_    \_                                 /  ^ \
      // \_____\                               / *  o \
     (_) {______}                             /_  - $ _\
          ######                               / o    \
         #      #           _ _               /_  $ * _\
        #        #         (_V_)               / % o  \ 
        #        #         __V__              /____ ___\
        #        #        [  |  ]                 [ ]
         #      #         [--+--]                 [ ]
          ######          [  |  ]                 [ ]
-------------------------------------------------------
",
@"                                                 /\
        _____                                   /* \
       /_    \_                                /  ^ \
      // \_____\                              / *  o \
     (_) {______}                            /_  - $ _\
          ######                              / o    \
         #      #          _ _               /_  $ * _\
        #        #        (_V_)               / % o  \ 
        #        #        __V__              /____ ___\
        #        #       [  |  ]                 [ ]
         #      #        [--+--]                 [ ]
          ######         [  |  ]                 [ ]
-------------------------------------------------------
",
@"                                                /\
        _____                                  /* \
       /_    \_                               /  ^ \
      // \_____\                             / *  o \
     (_) {______}                           /_  - $ _\
          ######                             / o    \
         #      #         _ _               /_  $ * _\
        #        #       (_V_)               / % o  \ 
        #        #       __V__              /____ ___\
        #        #      [  |  ]                 [ ]
         #      #       [--+--]                 [ ]
          ######        [  |  ]                 [ ]
-------------------------------------------------------
",
@"                                               /\
        _____                                 /* \
       /_    \_                              /  ^ \
      // \_____\                            / *  o \
     (_) {______}                          /_  - $ _\
          ######                            / o    \
         #      #        _ _               /_  $ * _\
        #        #      (_V_)               / % o  \ 
        #        #      __V__              /____ ___\
        #        #     [  |  ]                 [ ]
         #      #      [--+--]                 [ ]
          ######       [  |  ]                 [ ]
-------------------------------------------------------
",
@"                                             /\
        _____                               /* \
       /_    \_                            /  ^ \
      // \_____\                          / *  o \
     (_) {______}                        /_  ~ $ _\
          ######                          / o    \
         #      #       _ _              /_  $ * _\
        #        #     (_V_)              / % o  \ 
        #        #     __V__             /____ ___\
        #        #    [  |  ]                [ ]
         #      #     [--+--]                [ ]
          ######      [  |  ]                [ ]
---------------------------------------------------------
",
@"                                             /\
        _____                               /* \
       /_    \_                            /  ^ \
      // \_____\                          / *  o \
     (_) {______}                        /_  ~ $ _\
          ######                          / o    \
         #      #       _ _              /_  $ * _\
        #        #     (_V_)              / % o  \ 
        #        #     __V__             /____ ___\
        #        #    [  |  ]                [ ]
         #      #     [--+--]                [ ]
          ######      [  |  ]                [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                          / o    \
         #      #      _ _              /_  $ * _\
        #        #    (_V_)              / % o  \ 
        #        #    __V__             /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]                [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                          / o    \
         #      #      _ _              /_  $ * _\
        #        #    (_V_)              / % o  \ 
        #        #    __V__             /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]                [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                          / o    \
         #      #      _ _              /_  $ * _\
        #        #    (_V_)              / % o  \ 
        #        #    __V__             /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]                [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                          / o    \
         #      #      _ _              /_  $ * _\
        #        #    (_V_)              / % o  \ 
        #        #    __V__             /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]                [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #      _                /_  $ * _\
        #        #    (_V\_              / % o  \ 
        #        #    __V__             /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]                [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #      _                /_  $ * _\
        #        #    {_V\_              / % o  \ 
        #        #    __V__             /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]                [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #    _/V\_              / % o  \ 
        #        #    __V__             /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]                [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #    \____             / % o  \ 
        #        #    __V__\           /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]                [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #         ___           / % o  \ 
        #        #    __V_    \         /____ ___\
        #        #   [  |  ]  |             [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]                [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #           _           / % o  \ 
        #        #    _/ _    |         /____ ___\
        #        #   [  |  ]  \             [ ]
         #      #    [--+--]   |            [ ]
          ######     [  |  ]                [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #                       / % o  \ 
        #        #    _/ _              /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]    \           [ ]
          ######     [  |  ]     |---.      [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #                       / % o  \ 
        #        #    _/ _              /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    __---.      [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _                    / % o  \ 
        #        #   \   \_             /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _                    / % o  \ 
        #        #   \   |_             /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _      _             / % o  \ 
        #        #   \    |             /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _      _             / % o  \ 
        #        #   \    |             /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _   _   _            / % o  \ 
        #        #   \ //  /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #        _              /_  $ * _\
        #        #  _   //  _            / % o  \ 
        #        #   \ //  /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######          _              / o    \
         #      #        //             /_  $ * _\
        #        #  _   //  _            / % o  \ 
        #        #   \ //  /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######          _              / o    \
         #      #        //             /_  $ * _\
        #        #  _   //   _           / % o  \ 
        #        #   \()7() /           /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_             _             /  ^ \
      // \_____\           // _          / *  o \
     (_) {______}     _   // (_)        /_  ~ $ _\
          ######     (_) //              / o    \
         #      #       //              /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                              // _          /\
        _____            _   // (_)        /* \
       /_    \_         (_) //            /  ^ \
      // \_____\           //            / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                         _    //(_)         /\
        _____           (_)  //            /* \
       /_    \_             //            /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                              // '-'        /\
        _____            (_) //            /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                          '-' //            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"            //                              /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / /  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"        '-' //                              /\
        __ //                              /* \
       /_ \--\_                           /  ^ \
      // \_____\                         / /  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"        '-' //                              /\
        __ //                              /* \
       /_ \--\_                           /  ^ \
      // \_____\                         / /  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"        (_) //                              /\
        _  //                              /* \
       /_\//-\_                           /  ^ \
      // \_____\                         / /  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"        (_) //                              /\
           //                              /* \
       _/`//-\_                           /  ^ \
      /,_\_____\                         / /  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"        _   // '-'                          /\
       (_) //                              /* \
       _/`//-\_                           /  ^ \
      /,_//____\                         / /  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"        _   // '-'                          /\
       (_) //                              /* \
       __,//-._                           /  ^ \
      /,_//____\                         / /  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                _                           /\
            // (_)                         /* \
       _ ,,//.__                          /  ^ \
      (_) //____\                        / /  o \
     //  //______}                      /_  ~ $ _\
    (_)   ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                _                           /\
            // (_)                         /* \
       _   // __                          /  ^ \
      (_) //_/__\                        / /  o \
     _|/ //______}                      /_  ~ $ _\
    (_)   ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
               _                           /* \
           // (_)                         /  ^ \
          //_/__\                        / /  o \
     _   //______}                      /_  ~ $ _\
    (_) // ######                        / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
                                           /* \
                _                         /  ^ \
           //_.(_)                       / /  o \
      _   //______}                     /_  ~ $ _\
     (_) //=#####                       / o    \
        //#      #                     /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
                                           /* \
                                          /  ^ \
           //_,_                         / /  o \
     _    //_ (_)                       /_  ~ $ _\
    (_)  //======                        / o    \
        //=      #                      /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
                                           /* \
                                          /  ^ \
                                         / /  o \
     _   //_  _}                        /_  ~ $ _\
    (_) // ##(_).                        / o    \
       // #  \===#                      /_  $ * _\
      // #       #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
                                           /* \
                                          /  ^ \
                                         / /  o \
     _                                  /_  ~ $ _\
    (_) //   _                           / o    \
       // ==(_)===                      /_  $ * _\
      // #       #  _       _            / % o  \ 
     // #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
                                           /* \
                                          /  ^ \
                                         / /  o \
     _                                  /_  ~ $ _\
    (_) //                               / o    \
       //   _                           /_  $ * _\
      // ==(_)====  _       _            / % o  \ 
     // #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
                                           /* \
                                          /  ^ \
                                         / /  o \
                                        /_  ~ $ _\
                                         / o    \
                                        /_  $ * _\
    _   //    _     _       _            / % o  \ 
   (_) //,===(_)===  \     /            /____ ___\
      // #       #   [  |  ]                [ ]
     //  #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
                                           /* \
                                          /  ^ \
                                         / /  o \
                                        /_  ~ $ _\
                                         / o    \
                                        /_  $ * _\
    _   //          _       _            / % o  \ 
   (_) //    _       \     /            /____ ___\
      // ===(_)===   [  |  ]                [ ]
     //  #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
                                           /* \
                                          /  ^ \
                                         / /  o \
                                        /_  ~ $ _\
                                         / o    \
                                        /_  $ * _\
    _   //          _       _            / % o  \ 
   (_) //    _       \     /            /____ ___\
      // ===(_)===   [  |  ]                [ ]
     //  #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
"};

            int FrameCounter = 0;
            bool NotSkipped = true;
            while (NotSkipped)
            {
                Program.form.TextBoxReplace(Playmation[FrameCounter] +
            "\nAnimated by The King of Ducks \nPress any (arrow) key to skip");

                if (FrameCounter == Playmation.Count - 1)
                    NotSkipped = false;
                else
                    FrameCounter = FrameCounter + 1;

                if (NativeKeyboard.IsKeyDown(KeyCode.Up) ||
                    NativeKeyboard.IsKeyDown(KeyCode.Down) ||
                    NativeKeyboard.IsKeyDown(KeyCode.Left) ||
                    NativeKeyboard.IsKeyDown(KeyCode.Right))
                {
                    NotSkipped = false;
                }
                if (FrameCounter < 21)
                    Thread.Sleep(200);
                if (FrameCounter < 33)
                    Thread.Sleep(100);
                Thread.Sleep(100);
            }
            Program.form.ZoomTextBox(Program.form.ZoomTextBox() * 1.5f);
        }

        public static bool Import()
        {

            Program.form.ZoomTextBox(Program.form.ZoomTextBox() / 1.5f);

            List<List<string>> MasterAnimations = new List<List<string>>();
            List<string> Playmation = new List<string>() {
@"                                                  /\
        _____                                    /* \
       /_    \_                                 /  ^ \
      // \_____\                               / *  o \
     (_) {______}                             /_  - $ _\
          ######                               / o    \
         #      #           _ _               /_  $ * _\
        #        #         (_V_)               / % o  \ 
        #        #         __V__              /____ ___\
        #        #        [  |  ]                 [ ]
         #      #         [--+--]                 [ ]
          ######          [  |  ]                 [ ]
-------------------------------------------------------
",
@"                                                  /\
        _____                                    /* \
       /_    \_                                 /  ^ \
      // \_____\                               / *  o \
     (_) {______}                             /_  - $ _\
          ######                               / o    \
         #      #           _ _               /_  $ * _\
        #        #         (_V_)               / % o  \ 
        #        #         __V__              /____ ___\
        #        #        [  |  ]                 [ ]
         #      #         [--+--]                 [ ]
          ######          [  |  ]                 [ ]
-------------------------------------------------------
",
@"                                                 /\
        _____                                   /* \
       /_    \_                                /  ^ \
      // \_____\                              / *  o \
     (_) {______}                            /_  - $ _\
          ######                              / o    \
         #      #          _ _               /_  $ * _\
        #        #        (_V_)               / % o  \ 
        #        #        __V__              /____ ___\
        #        #       [  |  ]                 [ ]
         #      #        [--+--]                 [ ]
          ######         [  |  ]                 [ ]
-------------------------------------------------------
",
@"                                                /\
        _____                                  /* \
       /_    \_                               /  ^ \
      // \_____\                             / *  o \
     (_) {______}                           /_  - $ _\
          ######                             / o    \
         #      #         _ _               /_  $ * _\
        #        #       (_V_)               / % o  \ 
        #        #       __V__              /____ ___\
        #        #      [  |  ]                 [ ]
         #      #       [--+--]                 [ ]
          ######        [  |  ]                 [ ]
-------------------------------------------------------
",
@"                                               /\
        _____                                 /* \
       /_    \_                              /  ^ \
      // \_____\                            / *  o \
     (_) {______}                          /_  - $ _\
          ######                            / o    \
         #      #        _ _               /_  $ * _\
        #        #      (_V_)               / % o  \ 
        #        #      __V__              /____ ___\
        #        #     [  |  ]                 [ ]
         #      #      [--+--]                 [ ]
          ######       [  |  ]                 [ ]
-------------------------------------------------------
",
@"                                             /\
        _____                               /* \
       /_    \_                            /  ^ \
      // \_____\                          / *  o \
     (_) {______}                        /_  ~ $ _\
          ######                          / o    \
         #      #       _ _              /_  $ * _\
        #        #     (_V_)              / % o  \ 
        #        #     __V__             /____ ___\
        #        #    [  |  ]                [ ]
         #      #     [--+--]                [ ]
          ######      [  |  ]                [ ]
---------------------------------------------------------
",
@"                                             /\
        _____                               /* \
       /_    \_                            /  ^ \
      // \_____\                          / *  o \
     (_) {______}                        /_  ~ $ _\
          ######                          / o    \
         #      #       _ _              /_  $ * _\
        #        #     (_V_)              / % o  \ 
        #        #     __V__             /____ ___\
        #        #    [  |  ]                [ ]
         #      #     [--+--]                [ ]
          ######      [  |  ]                [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                          / o    \
         #      #      _ _              /_  $ * _\
        #        #    (_V_)              / % o  \ 
        #        #    __V__             /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]                [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                          / o    \
         #      #      _ _              /_  $ * _\
        #        #    (_V_)              / % o  \ 
        #        #    __V__             /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]                [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                          / o    \
         #      #      _ _              /_  $ * _\
        #        #    (_V_)              / % o  \ 
        #        #    __V__             /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]                [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                          / o    \
         #      #      _ _              /_  $ * _\
        #        #    (_V_)              / % o  \ 
        #        #    __V__             /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]                [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #      _                /_  $ * _\
        #        #    (_V\_              / % o  \ 
        #        #    __V__             /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]                [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #      _                /_  $ * _\
        #        #    {_V\_              / % o  \ 
        #        #    __V__             /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]                [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #    _/V\_              / % o  \ 
        #        #    __V__             /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]                [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #    \____             / % o  \ 
        #        #    __V__\           /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]                [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #         ___           / % o  \ 
        #        #    __V_    \         /____ ___\
        #        #   [  |  ]  |             [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]                [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #           _           / % o  \ 
        #        #    _/ _    |         /____ ___\
        #        #   [  |  ]  \             [ ]
         #      #    [--+--]   |            [ ]
          ######     [  |  ]                [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #                       / % o  \ 
        #        #    _/ _              /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]    \           [ ]
          ######     [  |  ]     |---.      [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #                       / % o  \ 
        #        #    _/ _              /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    __---.      [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _                    / % o  \ 
        #        #   \   \_             /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _                    / % o  \ 
        #        #   \   |_             /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _      _             / % o  \ 
        #        #   \    |             /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _      _             / % o  \ 
        #        #   \    |             /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _   _   _            / % o  \ 
        #        #   \ //  /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #        _              /_  $ * _\
        #        #  _   //  _            / % o  \ 
        #        #   \ //  /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######          _              / o    \
         #      #        //             /_  $ * _\
        #        #  _   //  _            / % o  \ 
        #        #   \ //  /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######          _              / o    \
         #      #        //             /_  $ * _\
        #        #  _   //   _           / % o  \ 
        #        #   \()7() /           /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_             _             /  ^ \
      // \_____\           // _          / *  o \
     (_) {______}     _   // (_)        /_  ~ $ _\
          ######     (_) //              / o    \
         #      #       //              /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                              // _          /\
        _____            _   // (_)        /* \
       /_    \_         (_) //            /  ^ \
      // \_____\           //            / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                         _    //(_)         /\
        _____           (_)  //            /* \
       /_    \_             //            /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                              // '-'        /\
        _____            (_) //            /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                          '-' //            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / *  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"            //                              /\
        _____                              /* \
       /_    \_                           /  ^ \
      // \_____\                         / /  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"        '-' //                              /\
        __ //                              /* \
       /_ \--\_                           /  ^ \
      // \_____\                         / /  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"        '-' //                              /\
        __ //                              /* \
       /_ \--\_                           /  ^ \
      // \_____\                         / /  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"        (_) //                              /\
        _  //                              /* \
       /_\//-\_                           /  ^ \
      // \_____\                         / /  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"        (_) //                              /\
           //                              /* \
       _/`//-\_                           /  ^ \
      /,_\_____\                         / /  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"        _   // '-'                          /\
       (_) //                              /* \
       _/`//-\_                           /  ^ \
      /,_//____\                         / /  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"        _   // '-'                          /\
       (_) //                              /* \
       __,//-._                           /  ^ \
      /,_//____\                         / /  o \
     (_) {______}                       /_  ~ $ _\
          ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                _                           /\
            // (_)                         /* \
       _ ,,//.__                          /  ^ \
      (_) //____\                        / /  o \
     //  //______}                      /_  ~ $ _\
    (_)   ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                _                           /\
            // (_)                         /* \
       _   // __                          /  ^ \
      (_) //_/__\                        / /  o \
     _|/ //______}                      /_  ~ $ _\
    (_)   ######                         / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
               _                           /* \
           // (_)                         /  ^ \
          //_/__\                        / /  o \
     _   //______}                      /_  ~ $ _\
    (_) // ######                        / o    \
         #      #                       /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
                                           /* \
                _                         /  ^ \
           //_.(_)                       / /  o \
      _   //______}                     /_  ~ $ _\
     (_) //=#####                       / o    \
        //#      #                     /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
                                           /* \
                                          /  ^ \
           //_,_                         / /  o \
     _    //_ (_)                       /_  ~ $ _\
    (_)  //======                        / o    \
        //=      #                      /_  $ * _\
        #        #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
                                           /* \
                                          /  ^ \
                                         / /  o \
     _   //_  _}                        /_  ~ $ _\
    (_) // ##(_).                        / o    \
       // #  \===#                      /_  $ * _\
      // #       #  _       _            / % o  \ 
        #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
                                           /* \
                                          /  ^ \
                                         / /  o \
     _                                  /_  ~ $ _\
    (_) //   _                           / o    \
       // ==(_)===                      /_  $ * _\
      // #       #  _       _            / % o  \ 
     // #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
                                           /* \
                                          /  ^ \
                                         / /  o \
     _                                  /_  ~ $ _\
    (_) //                               / o    \
       //   _                           /_  $ * _\
      // ==(_)====  _       _            / % o  \ 
     // #        #   \     /            /____ ___\
        #        #   [  |  ]                [ ]
         #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
                                           /* \
                                          /  ^ \
                                         / /  o \
                                        /_  ~ $ _\
                                         / o    \
                                        /_  $ * _\
    _   //    _     _       _            / % o  \ 
   (_) //,===(_)===  \     /            /____ ___\
      // #       #   [  |  ]                [ ]
     //  #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
                                           /* \
                                          /  ^ \
                                         / /  o \
                                        /_  ~ $ _\
                                         / o    \
                                        /_  $ * _\
    _   //          _       _            / % o  \ 
   (_) //    _       \     /            /____ ___\
      // ===(_)===   [  |  ]                [ ]
     //  #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
",
@"                                            /\
                                           /* \
                                          /  ^ \
                                         / /  o \
                                        /_  ~ $ _\
                                         / o    \
                                        /_  $ * _\
    _   //          _       _            / % o  \ 
   (_) //    _       \     /            /____ ___\
      // ===(_)===   [  |  ]                [ ]
     //  #      #    [--+--]                [ ]
          ######     [  |  ]    _____       [ ]
---------------------------------------------------------
"};

            /*string Filename = "anim.worlk";
            int FrameID = 0;
            MasterAnimations.Clear();
            if (File.Exists(Filename))
            {
                string[] TextRead = File.ReadAllLines(Filename);
                try
                {
                    if (TextRead[0] == "")
                    {
                        MessageBox.Show("Unable to read file " + Filename + ". \n Please use a proper .worlk file.");
                        return false;
                    }
                }
                catch
                {
                    MessageBox.Show("Unable to read file" + Filename + ". \n Please use a proper .worlk file.");
                    return false;
                }


                for (int i = 0; i < TextRead.Length; i++)
                {
                    if (TextRead[i].Substring(0, 1) == "%")
                    {
                        MainTextBox.Font =
                            new Font(MainTextBox.Font.FontFamily, float.Parse(TextRead[i].Substring(1)));
                    }

                    if (TextRead[i].Substring(0, 1) == "*")
                    {
                        FrameID += 1;

                        List<string> CurrentFrameLines = new List<string>();
                        bool notreturned = true;
                        int j = i;


                        while (notreturned)
                        {
                            if (TextRead[j].Substring(0, 1) == "*" && j != i || j == TextRead.Length - 1)
                            {
                                notreturned = false;
                            }
                            if (TextRead[j].Substring(0, 1) == "&")
                            {
                                CurrentFrameLines.Add(TextRead[j].Substring(1));
                            }

                            j++;
                        }
                        MasterAnimations.Add(CurrentFrameLines);
                    }
                }

                StringBuilder ExportBuilder = new StringBuilder();

                
                foreach (List<string> Frame in MasterAnimations)
                {
                    foreach (string line in Frame)
                    {
                        ExportBuilder.Append(line + "\n");
                    }
                    Playmation.Add(ExportBuilder.ToString());
                    ExportBuilder.Clear();
                }
                */
            int FrameCounter = 0;
            bool NotSkipped = true;
            while (NotSkipped)
            {
                Program.form.TextBoxReplace(Playmation[FrameCounter] +
            "\nAnimated by The King of Ducks     Press any (arrow) key to skip");

                if (FrameCounter == Playmation.Count - 1)
                    NotSkipped = false;
                else
                    FrameCounter = FrameCounter + 1;

                if (NativeKeyboard.IsKeyDown(KeyCode.Up) ||
                    NativeKeyboard.IsKeyDown(KeyCode.Down) ||
                    NativeKeyboard.IsKeyDown(KeyCode.Left) ||
                    NativeKeyboard.IsKeyDown(KeyCode.Right))
                {
                    NotSkipped = false;
                }
                Thread.Sleep(400);
            }
            Program.form.ZoomTextBox(Program.form.ZoomTextBox() * 1.5f);

            return true;
            /*}
            else
            {
                DialogResult result = MessageBox.Show("Unable to find default animation file " + Filename,
                    "Worlk error");
                return false;
            }*/

        }

    }
}
