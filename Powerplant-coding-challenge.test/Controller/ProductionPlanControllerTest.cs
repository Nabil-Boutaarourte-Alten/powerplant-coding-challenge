using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Powerplant_coding_challenge.Models;
using Powerplant_coding_challenge.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace Powerplant_coding_challenge.test.Controller
{
    public class ProductionPlanControllerTest
    {
        [Fact]
        public void ProductionPlanController_Calculate_ReturnOK()
        {
            //Arrange
            var controller = new ProductionPlanController();
            var Body = A.Fake<PostModel>();
            Body.fuels = A.Fake<Fuel>();
            Body.powerPlants = A.Fake<List<Powerplant>>();

            //Act
            var result = controller.Calculate(Body);

            //Assert
            result.Should().BeOfType(typeof(List<PowerPlantResponse>));
        }
    }
}
