using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeApi
{
    public class Poke
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public Pokemon[] results { get; set; }
        
    }
    public class Pokemon
    {
        public string name { get; set; }
        public string url { get; set; }
    }

}
