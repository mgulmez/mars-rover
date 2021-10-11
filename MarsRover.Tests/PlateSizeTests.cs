using NUnit.Framework;
using System;

namespace MarsRover.Tests
{
    public class PlateSizeTests
    {
        [TestCase("1 1")]
        [TestCase("1-1")]
        [TestCase("1x1")]
        public void MustBeSuccessedOnValidInput(string info)
        {
            try
            {
                var plateSize = PlateSize.Parse(info);
                Assert.Pass();
            }
            catch(SuccessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }


        [TestCase("5x0")]
        [TestCase("0x0")]
        public void MustBeFailOnInvalidInput(string info)
        {
            try
            {
                var plateSize = PlateSize.Parse(info);
                Assert.Fail("Başarısız bir input girilmesine rağmen plateSize doğru olarak parse etti.");
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
