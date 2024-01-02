using Aquality.Selenium.Core.Logging;
using Userinyerface.PageObjects;
using Userinyerface.Utilis;

namespace Userinyerface.Test
{
    public class TestCase2 : BaseTest
    {
        [Test]
        public void Test()
        {
            HelpForm helpForm = new HelpForm();
            helpForm.ClickHideHelpForm();
            Assert.That(helpForm.DisplayedHelpForm(), Is.True, "Help form is still displayed");
        }
    }
}
