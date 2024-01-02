using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using Userinyerface.Utilis;

namespace Userinyerface.PageObjects
{
    public class SecondCard : Form
    {
        private static ILabel UploadImageLabel => ElementFactory.GetLabel(By.XPath("//a[@class='avatar-and-interests__upload-button']"), "Upload avatar image");
        private static string CheckBoxLocator = "//div[contains(@class,'avatar-and-interests__interests-list__item')]/div/span/preceding-sibling::span";
        private static IButton NextBtn => ElementFactory.GetButton(By.XPath("//button[text()='Next']"), "Next button");
        private List<ICheckBox> CheckBoxesAvailable = new List<ICheckBox>();


        public SecondCard() : base(By.XPath("//h2[text()='This is me']"), "Avatar and interests form")
        {
        }

        public bool IsDisplayed()
        {
            return UploadImageLabel.State.WaitForDisplayed();
        }

        public void ClickUploadAvatarLabel()
        {
            UploadImageLabel.Click();
        }

        public void CheckRandomBoxes(int n)
        {
            CheckBoxesAvailable = GetCheckBoxes();

            UnselectAllCheckboxes();

            List<int> randomIndexes = RandomSelector.SelectRandomIndexes(n, CheckBoxesAvailable.Count);

            foreach (int index in randomIndexes)
            {
                CheckBoxesAvailable[index].Check();
            }
        }

        public void ClickNextBtn()
        {
            NextBtn.Click();
        }

        public void UnselectAllCheckboxes()
        {
            int lastMember = CheckBoxesAvailable.Count - 1;
            CheckBoxesAvailable[lastMember].Check();
            CheckBoxesAvailable.RemoveAt(lastMember);
        }

        private List<ICheckBox> GetCheckBoxes()
        {
            return (List<ICheckBox>)ElementFactory.FindElements<ICheckBox>(By.XPath(CheckBoxLocator), "Check boxes");
        }
    }
}
