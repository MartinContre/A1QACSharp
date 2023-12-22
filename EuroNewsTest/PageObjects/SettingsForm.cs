using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace EuroNewsTest.PageObjects
{
    public class SettingsForm : Form
    {
        private ILink DeleteAccountLink => ElementFactory.GetLink(By.XPath("//a[contains(@class, 'delete-account-link')]"), "Delete account link");
        public SettingsForm() : base(By.XPath("//a[contains(@class, 'delete-account-link')]"), "Settings form page")
        {
        }

        public bool IsDispleyed()
        {
            return DeleteAccountLink.State.WaitForDisplayed();
        }

        public void ClickDeleteAccount()
        {
            DeleteAccountLink.Click();
        }
    }
}
