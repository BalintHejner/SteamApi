using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamApp.Models
{

    public class UserData
    {
        public Steamuser response { get; set; }
    }

    public class Steamuser
    {
        public string steamid { get; set; }
        public int success { get; set; }
    }

}
