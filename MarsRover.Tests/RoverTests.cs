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
            plateSize = new PlateSize(10, 10);
        }

        //[TestCase("1 1 N", "RMMLMRMLM")]
        //public void Test1()
        //{
        //    Assert.Pass();
        //}
        [Test]
        public void Test1()
        {
            var directionEnums = Enum.GetValues(typeof(DirectionKey));
            var commandEnums = Enum.GetValues(typeof(CommandKey));
            foreach (var d in directionEnums)
            {
                var direction =  (DirectionKey)d;
                foreach (var c in commandEnums)
                {
                    var command = (CommandKey)c;
                    var message = $"Direction is {direction} and command is {command}. Current direction: {direction.ChangeDirection(command)}";
                }
            }
        }
    }
}