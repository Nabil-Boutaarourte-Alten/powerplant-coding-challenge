using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Powerplant_coding_challenge.Models
{
    public class PostModel
    {
        public float load { get; set; }
        public Fuel fuels { get; set; }
        public List<Powerplant> powerPlants { get; set; }
    }
}
