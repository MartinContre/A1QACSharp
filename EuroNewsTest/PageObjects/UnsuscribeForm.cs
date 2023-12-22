﻿using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace EuroNewsTest.PageObjects
{
    public class UnsuscribeForm : Form
    {
        private ITextBox DeletedMsg => ElementFactory.GetTextBox(By.XPath("//h1[@class='gigya-screen-caption']"), "Delete message box");
        public UnsuscribeForm() : base(By.XPath("//h1[@class='gigya-screen-caption']"), "Delete account page")
        {
        }

        public bool IsDispleyed()
        {
            return DeletedMsg.State.WaitForDisplayed();
        }
    }
}
