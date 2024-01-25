using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SteamApp.Models;

namespace SteamApp
{
    public static class SteamData
    {
        public static async Task<string> GetSteamUser(string steamname)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.steampowered.com/ISteamUser/ResolveVanityURL/v0001/?key=550A8581E3C60A740DEDB772B9541D3A&vanityurl={steamname}");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                string stringData = await response.Content.ReadAsStringAsync();
                UserData userData = JsonSerializer.Deserialize<UserData>(stringData);
                return userData.response.steamid;
            }
            return null;
        }

        public static async Task<List<Game>> GetUsersGames(string id)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key=550A8581E3C60A740DEDB772B9541D3A&steamid={id}&include_appinfo=1&format=json");
            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                string stringData = await response.Content.ReadAsStringAsync();
                GamesRootobject gamesRootObj = JsonSerializer.Deserialize<GamesRootobject>(stringData);
                return gamesRootObj.response.games.ToList();
            }
            return null;
        }
    }
}
