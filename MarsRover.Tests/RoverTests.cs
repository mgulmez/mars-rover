using NUnit.Framework;
using System;

namespace MarsRover.Tests
{
    public class RoverTests
    {
        PlateSize plateSize;
        [SetUp]
        public void Setup()
        {
            plateSize = new PlateSize(5, 5);
        }

        [TestCase("1 2 N", "LMLMLMLMM", "1 3 N")]
        [TestCase("3 3 E", "MMRMMRMRRM", "5 1 E")]
        public void RoverPositionMustBeValid(string roverPos, string commands, string expectedResult)
        {
            var expectedPosition = Position.Parse(expectedResult);

            var roverPosition = Position.Parse(roverPos);
            var directive = CommandPackage.Parse(commands);
            var roverKnownPos = directive.ComputePosition(roverPosition);
            Assert.IsTrue(expectedPosition.X == roverKnownPos.X && expectedPosition.Y == roverKnownPos.Y && expectedPosition.Direction == roverKnownPos.Direction, "Rover doðru konumda deðil!");
        }
    }
}