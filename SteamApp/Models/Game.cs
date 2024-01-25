using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamApp.Models
{

    public class GamesRootobject
    {
        public GamesResponse response { get; set; }
    }

    public class GamesResponse
    {
        public int game_count { get; set; }
        public Game[] games { get; set; }
    }

    public class Game
    {
        public int appid { get; set; }
        public string name { get; set; }
        public int playtime_forever { get; set; }
        public string img_icon_url { get; set; }
        public int[] content_descriptorids { get; set; }
        public bool has_community_visible_stats { get; set; }
        public bool has_leaderboards { get; set; }
        public int playtime_2weeks { get; set; }
        public double playtime_forever_hours
        {
            get
            {
                return Math.Round((double)playtime_forever / 60, 0);
            }
        }
        public string img_url
        {
            get { return $"https://steamcdn-a.akamaihd.net/steam/apps/{appid}/header.jpg"; }
        }


    }

}
