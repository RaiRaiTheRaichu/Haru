using System.Collections.Generic;
using Newtonsoft.Json;

namespace Haru.Models.EFT.Locale
{
    public struct MenuModel
    {
        [JsonProperty("menu")]
        public Dictionary<string, string> Menu;

        public MenuModel(GlobalModel global)
        {
            var keys = new string[]
            {
                "EXIT",
                "Escape from Tarkov",
                "AUTHORIZATION",
                "DOWN: ",
                "Servers are currently at full capacity",
                "NEXT",
                "REMEMBER ACCOUNT",
                "LEFT: ",
                "RIGHT: ",
                "{0} Beta version",
                "Profile data loading...",
                "UP: ",
                "230 - MAX LOGIN COUNT",
                "213 - Error connecting to auth server",
                "Place in queue:",
                "206 - Wrong email or password",
                "240 - Servers temporarily unavailable. Please, try later.",
                "BATTLEYE_UnknownRestartReason",
                "BATTLEYE_ANTICHEAT_ClientNotResponding",
                "BATTLEYE_ServiceNeedsToBeUpdated",
                "SABER_ANTICHEAT_AnticheatConnectionFailed",
                "BATTLEYE_ANTICHEAT_DisallowedProgram",
                "BATTLEYE_ANTICHEAT_FailedToLoadAnticheat",
                "BATTLEYE_ANTICHEAT_CorruptedMemory",
                "BATTLEYE_ANTICHEAT_WinAPIFailure",
                "BATTLEYE_ServiceNotRunningProperly",
                "BATTLEYE_ANTICHEAT_QueryTimeout",
                "BATTLEYE_ANTICHEAT_GlobalBan",
                "BATTLEYE_ANTICHEAT_CorruptedData",
                "BATTLEYE_ANTICHEAT_GameRestartRequired",
                "BATTLEYE_ANTICHEAT_BadServiceVersion",
                "UI/leave_game_confirmation_caption",
                "When you leave the raid you don’t get anything and also receive Left the Action exit status.",
                "UI/leave_game_confirmation_text",
                "ASSEMBLE",
                "Production completed: {0}"
            };

            Menu = new Dictionary<string, string>();

            foreach (var key in keys)
            {
                Menu.Add(key, global.Interface[key]);
            }
        }
    }
}