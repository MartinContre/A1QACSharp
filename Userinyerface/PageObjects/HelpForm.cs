using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Userinyerface.PageObjects
{
    public class HelpForm : Form
    {
        private static IButton SendToBottomBtn => ElementFactory.GetButton(By.XPath("//button[contains(@class, 'help-form__send-to-bottom-button')]"), "Hide help form button");
        private static ILabel HelpFormTitle => ElementFactory.GetLabel(By.XPath("//h2[@class='help-form__title']"), "Hide help form title");

        public HelpForm() : base(By.XPath("//h2[@class='help-form__title']"), "Help form")
        {
        }

        public void ClickHideHelpForm()
        {
            SendToBottomBtn.Click();
        }

        public bool DisplayedHelpForm()
        {
            return HelpFormTitle.State.WaitForNotDisplayed();
        }
    }
}
