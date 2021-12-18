using PromotionEngine.Core;
using PromotionEngine.Domains;
using System;
using System.Collections.Generic;
using Xunit;

namespace PromotionEngine.Tests
{
    public class ScenarioServiceTests
    {
        ScenarioItem Factory_ScenarioItem(string sku, float unitPrice, int quantity)
        {
            return new ScenarioItem
            {
                Product = new Product
                {
                    SKU = sku,
                    UnitPrice = unitPrice
                },
                Quantity = quantity
            };
        }

        [Fact]
        public void CalculateScenatioTotal_TestScenarioAPassed_ShouldCalculateTotal()
        {
            //Arrange
            Scenario scenario = new Scenario
            {
                ScenarioName = "A",
                ScenarioItems = new Dictionary<string, ScenarioItem>
                {
                    { "A", Factory_ScenarioItem("A", 50, 1) },
                    {"B",  Factory_ScenarioItem("B", 30, 1) },
                    {"C", Factory_ScenarioItem("C", 20, 1) }
                }
            };

            ScenarioService scenarioService = new ScenarioService(scenario);
            int expectedTotal = 100;

            //Act
            var actutalTotal = scenarioService.CalculateScenatioTotal();

            //Assert
            Assert.Equal(expectedTotal, actutalTotal);

        }

        [Fact]
        public void CalculateScenatioTotal_TestScenarioBPassed_ShouldCalculateTotal()
        {
            //Arrange
            Scenario scenario = new Scenario
            {
                ScenarioName = "B",
                ScenarioItems = new Dictionary<string, ScenarioItem>
                {
                    { "A", Factory_ScenarioItem("A", 50, 5) },
                    {"B",  Factory_ScenarioItem("B", 30, 5) },
                    {"C", Factory_ScenarioItem("C", 20, 1) }
                }
            };

            ScenarioService scenarioService = new ScenarioService(scenario);
            int expectedTotal = 370;

            //Act
            var actutalTotal = scenarioService.CalculateScenatioTotal();

            //Assert
            Assert.Equal(expectedTotal, actutalTotal);

        }

        [Fact]
        public void CalculateScenatioTotal_TestScenarioCPassed_ShouldCalculateTotal()
        {
            //Arrange
            Scenario scenario = new Scenario
            {
                ScenarioName = "C",
                ScenarioItems = new Dictionary<string, ScenarioItem>
                {
                    { "A", Factory_ScenarioItem("A", 50, 3) },
                    {"B",  Factory_ScenarioItem("B", 30, 5) },
                    {"C", Factory_ScenarioItem("C", 20, 1) },
                    {"D", Factory_ScenarioItem("D", 15, 1) }
                }
            };

            ScenarioService scenarioService = new ScenarioService(scenario);
            int expectedTotal = 280;

            //Act
            var actutalTotal = scenarioService.CalculateScenatioTotal();

            //Assert
            Assert.Equal(expectedTotal, actutalTotal);

        }

        [Fact]
        public void CalculateScenatioTotal_TestScenarioC2Passed_ShouldCalculateTotal()
        {
            //Arrange
            Scenario scenario = new Scenario
            {
                ScenarioName = "C",
                ScenarioItems = new Dictionary<string, ScenarioItem>
                {
                    { "A", Factory_ScenarioItem("A", 50, 3) },
                    {"B",  Factory_ScenarioItem("B", 30, 5) },
                    {"C", Factory_ScenarioItem("C", 20, 2) },
                    {"D", Factory_ScenarioItem("D", 15, 1) }
                }
            };

            ScenarioService scenarioService = new ScenarioService(scenario);
            int expectedTotal = 300;

            //Act
            var actutalTotal = scenarioService.CalculateScenatioTotal();

            //Assert
            Assert.Equal(expectedTotal, actutalTotal);

        }

        [Fact]
        public void CalculateScenatioTotal_TestScenarioE2Passed_ShouldCalculateTotal()
        {
            //Arrange
            Scenario scenario = new Scenario
            {
                ScenarioName = "E",
                ScenarioItems = new Dictionary<string, ScenarioItem>
                {
                    {"E", Factory_ScenarioItem("E", 20, 7) },
                    {"F", Factory_ScenarioItem("F", 15, 3) }
                }
            };

            ScenarioService scenarioService = new ScenarioService(scenario);
            int expectedTotal = 165;

            //Act
            var actutalTotal = scenarioService.CalculateScenatioTotal();

            //Assert
            Assert.Equal(expectedTotal, actutalTotal);

        }

    }
}
