using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Powerplant_coding_challenge.Models
{
    public class Powerplant
    {
        public string name { get; set; }
        public string type { get; set; }
        public float efficiency { get; set; }
        public int pMin { get; set; }
        public int pMax { get; set; }
        //[JsonIgnore]
        public float fuelCost { get; set; }
        public float power { get; set; }

        public Powerplant()
        {

        }

        //Methods

        public void getFuelCost(float fuel)
        {
            this.fuelCost = fuel * efficiency;
        }

        public float getWindPower(float wind, float load)
        {
            if (this.type == "windturbine")
            {
                this.power = wind / 100 * this.pMax;
            }
            return load - this.power; 
        }

        public float getPower(float load)
        {
            if (load == 0)
            {
                return 0;
            }
            if (load > pMax - pMin)
            {
                this.power = pMax - pMin;
            } else
            {
                this.power = load - pMin;
            }

            return (this.power > 0 ? load - (this.power + pMin) : 0);


        }
    }
}
