using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace EuroNewsTest.Tests
{
    public class NewsletterUnsubscriptionForm : Form
    {
        private ITextBox EmailAddressInputBox => ElementFactory.GetTextBox(By.XPath("//input[@id='email']"), "Email address input box");
        private ITextBox UnsubscriptionConfirmationTextBox => ElementFactory.GetTextBox(
            By.XPath("//strong[normalize-space()='You are unsubscribed.']"), "Unsubscription Confirmation Text Box");
        private IButton ConfirmUnsubscriptionButton = ElementFactory.GetButton(
                By.XPath("//button[@type='submit']"), "Confirm Unsubscription Button");


        public NewsletterUnsubscriptionForm() : base(By.XPath("//h3[normalize-space()='Newsletter unsubscription']"), "Newsletter unsubscription")
        {
        }

        public bool IsDisplayed()
        {
            return EmailAddressInputBox.State.WaitForDisplayed();
        }

        public void FillOutEmailAddressInputBox(string Email)
        {
            EmailAddressInputBox.ClearAndType(Email);
        }

        public void ClickConfirmUnsuscriptionBtn()
        {
            ConfirmUnsubscriptionButton.Click();
        }

        public bool IsUnsuscriptionConfirmationTxtBoxDiplayed()
        {
            return UnsubscriptionConfirmationTextBox.State.WaitForDisplayed();
        }
    }
}
