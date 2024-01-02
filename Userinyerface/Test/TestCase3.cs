using Userinyerface.PageObjects;

namespace Userinyerface.Test
{
    public class TestCase3 : BaseTest
    {
        [Test]
        public void Test()
        {
            CookiesForm cookiesForm = new CookiesForm();
            cookiesForm.ClickAcceptCookies();

            Assert.That(cookiesForm.MessageDipalyed(), Is.True, "Cookies form still visible");
        }
    }
}
