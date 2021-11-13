using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleGame
{
    
    class DiscordDB
    {
        public static bool DoesWork = false;
        public static Discord.Discord discord;
        public static Discord.ActivityManager activityManager;
        public static Discord.ActivityManager.UpdateActivityHandler callb;

        public static bool DiscordInit()
        {
            try
            {
                /*
                Grab that Client ID from earlier
                Discord.CreateFlags.Default will require Discord to be running for the game to work
                If Discord is not running, it will:
                1. Close your game
                2. Open Discord
                3. Attempt to re-open your game
                Step 3 may fail when running directly from your editor
                Therefore, always keep Discord running during tests, or use Discord.CreateFlags.NoRequireDiscord
                */
                discord = new Discord.Discord(775029329285480468, (UInt64)Discord.CreateFlags.Default);
                /*
                DiscordEventHandlers handlers;
                memset(&handlers, 0, sizeof(handlers));
                handlers.ready = handleDiscordReady;
                handlers.errored = handleDiscordError;
                handlers.disconnected = handleDiscordDisconnected;
                handlers.joinGame = handleDiscordJoinGame;
                handlers.spectateGame = handleDiscordSpectateGame;
                handlers.joinRequest = handleDiscordJoinRequest;

                // Discord_Initialize(const char* applicationId, DiscordEventHandlers* handlers, int autoRegister, const char* optionalSteamId)
                Discord_Initialize("418562325121990661", &handlers, 1, "1234");
                */

                callb = result => { };

                activityManager = discord.GetActivityManager();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void Update()
        {
            if(DoesWork)
                discord.RunCallbacks();
        }

        public static void UpdatePresence()
        {
            if (DoesWork)
            {
                

                string mode = "";

                switch (DodgeBlock.Mode)
                {
                    case 0:
                        mode = "Classic Mode";
                        break;
                    case 1:
                        mode = "Normal Mode";
                        break;
                    case 2:
                        mode = "Expert Mode";
                        break;
                    case 3:
                        mode = "Two Player Mode";
                        break;
                    case 4:
                        if (DodgeBlock.IsHolloween)
                        {
                            mode = ("Halloween Event");
                        }
                        else if (DodgeBlock.IsChristmas)
                        {
                            mode = ("Winter Event");
                        }
                        else
                        {
                            mode = ("Custom Mode");
                        }
                        break;
                    default:
                        mode = "raaad mode";
                        break;
                }
                var activity = new Discord.Activity
                {
                    State = "Recent Score: " + DodgeBlock.Score,
                    Details = mode,
                    /*    Timestamps =
                    {
                        Start = 5,
                        End = 6,
                    },*/
                    Assets =
            {
                LargeImage = "dodgeblockicon600",
                LargeText = "DodgeBlock " + DodgeBlock.Version,
            },
                    /*     Party = {
                        //Id = lobby.Id.ToString(),
                        Size = {
                             //CurrentSize = lobbyManager.MemberCount(lobby.Id),
                             //MaxSize = (int)lobby.Capacity,
                         },
                     },
                         Secrets = {
                         //Join = lobbyManager.GetLobbyActivitySecret(lobby.Id),
                     },*/
                    Instance = true,
                };

                /*
                DiscordRichPresence discordPresence;
                memset(&discordPresence, 0, sizeof(discordPresence));
                discordPresence.state = "Recent Score: 1530";
                discordPresence.details = "Classic Mode";
                discordPresence.startTimestamp = 1507665886;
                discordPresence.endTimestamp = 1507665886;
                discordPresence.largeImageKey = "dodgeblockicon600";
                discordPresence.largeImageText = "DodgeBlock";
                Discord_UpdatePresence(&discordPresence);*/
                try
                {
                    activityManager.UpdateActivity(activity, callb);
                }
                catch(Exception)
                {
                    
                }
            }
        }

        public static void die()
        {
            if (DoesWork)
            {
                discord.Dispose();
            }
        }

    }
}
