using Aquality.Selenium.Core.Elements;
using Aquality.Selenium.Core.Logging;
using Aquality.Selenium.Elements;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using Userinyerface.Utilis;

namespace Userinyerface.PageObjects
{
    public class FirstCard : Form
    {
        private static ITextBox PassworField => ElementFactory.GetTextBox(By.XPath("//input[@placeholder='Choose Password']"), "Password field");
        private static ITextBox EmailField => ElementFactory.GetTextBox(By.XPath("//input[@placeholder='Your email']"), "Email field");
        private static ITextBox DomainField => ElementFactory.GetTextBox(By.XPath("//input[@placeholder='Domain']"), "Domain field");
        private static ILabel TimerLabel => ElementFactory.GetLabel(By.XPath("//div[contains(@class, 'timer')]"), "Timer label");
        private static IButton DropdownOpenerBtn => ElementFactory.GetButton(By.XPath("//div[@class='dropdown__opener']"), "Dropdown opener");
        private static By DropDownList = By.ClassName("dropdown__list-item");
        private List<ILabel> ExtensionDomainsList;
        private static IButton NextBtn = ElementFactory.GetButton(By.XPath("//a[@class='button--secondary']"), "Next button");
        private static ICheckBox TermsConditionsCheckBox = ElementFactory.GetCheckBox(By.XPath("//span[@class='checkbox__box']"), "Accept terms and conditions check box");

        public FirstCard() : base(By.XPath("//div[@class='login-form__container']"), "First Card")
        {
        }

        public bool FirstCardDisplayed()
        {
            return TimerLabel.State.WaitForDisplayed();
        }

        public void WritePassword(string password)
        {
            PassworField.ClearAndType(password);
        }

        public void WriteEmail(string email)
        {
            EmailField.ClearAndType(email);
        }

        public void WriteDomain(string domain)
        {
            DomainField.ClearAndType(domain);
        }

        public string GetTimerLabelText()
        {
            return TimerLabel.Text;
        }

        public void SelectDomainExtension()
        {
            OpenDomainDropdownList();

            ExtensionDomainsList ??= GetExtensiosDomainsList();
            int selected = RandomSelector.SelectRandomIndexes(1, ExtensionDomainsList.Count)[0];

            ExtensionDomainsList[selected].Click();
        }

        public void AcceptTermsAndConditions()
        {
            TermsConditionsCheckBox.Check();
        }

        public void ClickNextButton()
        {
            NextBtn.Click();
        }

        private void OpenDomainDropdownList()
        {
            DropdownOpenerBtn.Click();
        }

        private List<ILabel> GetExtensiosDomainsList()
        {
            return (List<ILabel>)ElementFactory.FindElements<ILabel>(DropDownList, "Domains");
        }
    }
}
