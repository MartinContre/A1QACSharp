using Aquality.Selenium.Core.Logging;
using Userinyerface.PageObjects;

namespace Userinyerface.Test
{
    public class TestCase4 : BaseTest
    {
        [Test]
        public void Test()
        {
            FirstCard firstCard = new FirstCard();
            string expectedTimerValue = TestData.GetValue<string>("start_timer").Trim();
            string actualTimerValue = firstCard.GetTimerLabelText();
            Assert.That(actualTimerValue.Trim(), Is.EqualTo(expectedTimerValue));
        }
    }
}
