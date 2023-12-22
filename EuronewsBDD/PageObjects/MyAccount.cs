using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace EuroNewsTest.PageObjects
{
    public class MyAccount : Form
    {
        private IButton SettingsBtn = ElementFactory.GetButton(By.XPath("//span[normalize-space()='Settings']"), "Settings Button");
        public MyAccount() : base(By.XPath("//h2[normalize-space()='My Profile']"), "My profile")
        {
        }

        public bool IsDisplayed()
        {
            SettingsBtn.State.WaitForDisplayed();
            return SettingsBtn.State.WaitForDisplayed();
        }

        public void ClickSettingsBtn()
        {
            SettingsBtn.Click();
        }
    }
}
