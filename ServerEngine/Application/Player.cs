using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerEngine.Application
{
    public class Player
    {
        public string Name { get; set; }
        public int Level;
        public int PlayerID { get; set; }

        public Player(string _name, int playersCount)
        {
            Name = _name;
            Level = 0;
            PlayerID = playersCount + 1;
        }
    }
}
