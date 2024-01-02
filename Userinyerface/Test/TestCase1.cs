using Aquality.Selenium.Core.Logging;
using Userinyerface.PageObjects;
using Userinyerface.Utilis;

namespace Userinyerface.Test
{
    public class TestCase1 : BaseTest
    {
        private static int EmailLength => TestData.GetValue<int>("email_length");
        private static int PasswordLength => TestData.GetValue<int>("password_length");
        [Test]
        public void Test1()
        {
            string mail = RandomGenerator.GenerateRandomEmail(EmailLength);
            string password = RandomGenerator.GenerateRandomPassword(mail, PasswordLength);
            List<string> Domains = [.. TestData.GetValueList<string>("emails_domains")];
            string domain = RandomGenerator.GetEmailDomain(Domains);

            FirstCard firstCard = new FirstCard();
            SecondCard secondCard = new SecondCard();
            ThirdCard thirdCard = new ThirdCard();

            firstCard.WritePassword(password);
            firstCard.WriteEmail(mail);
            firstCard.WriteDomain(domain);
            firstCard.SelectDomainExtension();
            firstCard.AcceptTermsAndConditions();
            firstCard.ClickNextButton();

            Assert.That(secondCard.IsDisplayed(), Is.True, "Second card not opened");
            secondCard.CheckRandomBoxes(3);
            secondCard.ClickUploadAvatarLabel();
            
            string path = TestData.GetValue<string>("path_upload_image");
            int delayTime = TestData.GetValue<int>("delay_time");
            Clipboard.SetText(Environment.CurrentDirectory + path);
            ClipboardPaste.PasteAndHitEnter(delayTime);

            secondCard.ClickNextBtn();

            Assert.That(thirdCard.IsDisplayed(), Is.True, "Third card not opened");
        }
    }
}
