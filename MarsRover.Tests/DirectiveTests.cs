using NUnit.Framework;
using System;

namespace MarsRover.Tests
{
    public class DirectiveTests
    {
        [TestCase("RMMLMRM")]
        [TestCase("MLLRM")]
        [TestCase("LMLMLM")]
        public void MustBeSuccessedOnValidInput(string info)
        {
            try
            {
                var position = Directive.Parse(info);
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
        [TestCase("M2LR")]
        [TestCase(" ")]
        public void MustBeFailOnInvalidInput(string info)
        {
            try
            {
                var position = Directive.Parse(info);
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
