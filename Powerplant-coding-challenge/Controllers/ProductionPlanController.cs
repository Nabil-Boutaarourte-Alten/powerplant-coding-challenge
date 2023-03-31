using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Powerplant_coding_challenge.Models;
using System.Reflection;

namespace Powerplant_coding_challenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductionPlanController : ControllerBase
    {
        readonly Dictionary<string, string> fuelTypeMapping = new Dictionary<string, string>()
        {
            { "gasfired", "gas" },
            { "turbojet", "kerosine" },
            { "windturbine", "wind" }
        };

        [HttpGet]
        public string Test()
        {
            return "SIUUUU";
        }
        [HttpPost]
        public List<PowerPlantResponse> Calculate(PostModel body)
        {
            // Gets the cost of each powerPlant
            foreach (Powerplant powerPlant in body.powerPlants)
            {
                // wind has no cost
                if (powerPlant.type == "windturbine")
                {
                    powerPlant.fuelCost = 0;
                    continue;
                }
                powerPlant.getFuelCost((float)body.fuels.GetType().GetProperty(fuelTypeMapping[powerPlant.type]).GetValue(body.fuels));
            }
            
            // Sort the powerplants based on fuel cost
            body.powerPlants = SortByMerit(body.powerPlants);

            // Since the powerPlants are sorted by merit (fuel cost) we can calculate the power of each powerplant with the pmin, pmax and current load
            foreach (Powerplant powerPlant in body.powerPlants)
            {
                // windturbine have a slightly different calculation method than gas and kerosine
                if (powerPlant.type == "windturbine")
                {
                    body.load = powerPlant.getWindPower(body.fuels.wind, body.load);
                    continue;
                }

                body.load = powerPlant.getPower(body.load);
            }

            // returns the p of each powerplant in the correct format
            return returnResponse(body.powerPlants);
        }

        [NonAction]
        public List<Powerplant> SortByMerit(List<Powerplant> powerPlants)
        {
            return powerPlants.OrderBy(x => x.fuelCost).ToList();
        }

        [NonAction]
        public List<PowerPlantResponse> returnResponse(List<Powerplant> powerPlants)
        {
            List<PowerPlantResponse> powerPlantResponses = new List<PowerPlantResponse>();
            foreach (Powerplant powerplant in powerPlants)
            {
                powerPlantResponses.Add(new PowerPlantResponse(powerplant.name, Convert.ToInt32(powerplant.power)));
            }
            return powerPlantResponses;
        }
    }
}
