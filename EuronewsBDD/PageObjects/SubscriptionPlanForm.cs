using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace EuroNewsTest.PageObjects
{
    public class SubscriptionPlanForm : Form
    {
        private static ITextBox EmailTextBox => ElementFactory.GetTextBox(By.XPath("//input[@placeholder='Enter your email']"), "Email text box");
        private static IButton SubmitFormBtn => ElementFactory.GetButton(By.XPath("//input[@value='Continue']"), "Submit subscription form");

        public SubscriptionPlanForm() : base(By.Id("register-newsletters-form"), "Register subscription plan email form")
        {
        }

        public bool IsDisplayed()
        {
            return EmailTextBox.State.WaitForDisplayed();
        }

        public void FiilOutEmail(string email)
        {
            EmailTextBox.SendKeys(email);
        }

        public void ClickSubmitSuscriptionBtn()
        {
            SubmitFormBtn.ClickAndWait();
        }
    }
}
