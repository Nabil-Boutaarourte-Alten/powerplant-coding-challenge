using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Powerplant_coding_challenge.Models
{
    public class PowerPlantResponse
    {
        public string name { get; set; }
        public int P { get; set; }

        public PowerPlantResponse(string Name, int p)
        {
            this.name = Name;
            this.P = p;
        }
    }
}
