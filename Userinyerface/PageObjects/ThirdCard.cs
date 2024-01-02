using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Userinyerface.PageObjects
{
    public class ThirdCard : Form
    {
        private static ILabel PersonalDetailsLabel => ElementFactory.GetLabel(By.XPath("//h3[text()='Personal details'"), "Personal detaisl title");
        public ThirdCard() : base(By.XPath("//h3[text()='Personal details']"), "Personal details form")
        {
        }

        public bool IsDisplayed()
        {
            return PersonalDetailsLabel.State.WaitForDisplayed();
        }
    }
}
