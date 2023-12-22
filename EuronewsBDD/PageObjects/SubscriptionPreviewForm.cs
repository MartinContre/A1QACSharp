using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace EuroNewsTest.PageObjects
{
    public class SubscriptionPreviewForm : Form
    {
        private ITextBox UnsuscribeBtn => ElementFactory.GetTextBox(By.XPath("//a[contains(@href, 'https://services.ownpage.fr/unsubscribe/')]"), "Unsubscribe button");

        private ITextBox PreviewForm => ElementFactory.GetTextBox(By.CssSelector(".jquery-modal.blocker.current"), "Preview Form");
        private readonly string IframeLocator = "iframe-preview";

        public SubscriptionPreviewForm() : base(By.CssSelector(".jquery-modal.blocker.current"), "Preview form")
        {
        }

        public bool IsDisplayed()
        {
            return UnsuscribeBtn.State.WaitForDisplayed();
        }

        public void ClickUnsuscribeBtn()
        {
            TextBox iframe = PreviewForm.FindChildElement<TextBox>(By.CssSelector(IframeLocator));
            AqualityServices.Browser.Driver.SwitchTo().Frame(iframe.GetElement());

            UnsuscribeBtn.JsActions.ScrollIntoView();
            AqualityServices.Browser.GoTo(UnsuscribeBtn.GetAttribute("href"));

        }

    }
}
