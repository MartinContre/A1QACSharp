using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace EuroNewsTest.PageObjects
{
    public class CompleteSubscription : Form
    {
        private ITextBox PasswordTxtBox => ElementFactory.GetTextBox(By.XPath("//input[contains(@id, 'password') and contains(@class, 'password')]\r\n"), "Password field");
        private IButton CreateAccountBtn => ElementFactory.GetButton(By.XPath("//input[@value='Create my account']"), "Create account button");

        public CompleteSubscription() : base(By.XPath("//h2[contains(text(),'Complete your registration')]"), "Create your account")
        {
        }

        public bool IsDisplayed()
        {
            return PasswordTxtBox.State.WaitForDisplayed();
        }

        public void FillPassword(string password)
        {
            PasswordTxtBox.ClearAndType(password);
        }

        public void ClickCreateAccountBtn()
        {
            CreateAccountBtn.State.WaitForClickable();            
            CreateAccountBtn.Click();
        }
    }
}
