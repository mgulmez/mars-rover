using NUnit.Framework;
using System;

namespace MarsRover.Tests
{
    public class PositionTests
    {
        [TestCase("1 1 N")]
        [TestCase("3 1 W")]
        [TestCase("3 0 E")]
        [TestCase("2 4 S")]
        public void MustBeSuccessedOnValidInput(string info)
        {
            try
            {
                var position = Position.Parse(info);
                Assert.Pass();
            }
            catch (SuccessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }


        [TestCase("-3 0 W")]
        [TestCase("1 5 WE")]
        [TestCase("0 S")]
        public void MustBeFailOnInvalidInput(string info)
        {
            try
            {
                var position = Position.Parse(info);
                Assert.Fail("Başarısız bir input girilmesine rağmen position doğru olarak parse etti.");
            }
            catch (SuccessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Assert.Pass();
            }
        }
    }
}
