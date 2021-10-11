using NUnit.Framework;

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

        [TestCase("1 1 N", "RMMLMRMLM")]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}