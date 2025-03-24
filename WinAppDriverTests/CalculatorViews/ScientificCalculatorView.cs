using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace WinAppDriverTests.CalculatorViews
{
    public class ScientificCalculatorView : CalculatorBaseView
    {
        protected WindowsElement OpenParenthesis => _driver.FindElementByAccessibilityId("openParenthesisButton");
        protected WindowsElement CloseParenthesis => _driver.FindElementByAccessibilityId("closeParenthesisButton");
        protected WindowsElement Log10Base => _driver.FindElementByAccessibilityId("logBase10Button");
        protected WindowsElement Pi => _driver.FindElementByAccessibilityId("piButton");
        protected WindowsElement InputAndResult => _driver.FindElementByAccessibilityId("CalculatorResults");
        protected WindowsElement ClearEntry => _driver.FindElementByAccessibilityId("clearEntryButton");
        protected WindowsElement TrigonometryDropDown => _driver.FindElementByAccessibilityId("trigButton");
        protected WindowsElement SinButton => _driver.FindElementByAccessibilityId("sinButton");
        protected WindowsElement CosButton => _driver.FindElementByAccessibilityId("cosButton");

        public ScientificCalculatorView(WindowsDriver<WindowsElement> driver) : base(driver)
        { 
        }
        public string CalculateFormula(string operand1, string operand2, string operand3)
        {
            Pi.Click();
            Plus.Click();
            EnterNumberInCalculatorInputField(operand1);
            Log10Base.Click();
            Minus.Click();
            OpenParenthesis.Click();
            EnterNumberInCalculatorInputField(operand2);
            Multiply.Click();
            EnterNumberInCalculatorInputField(operand3);
            CloseParenthesis.Click(); 
            Equals.Click();

            return CalculatorResults.Text;
        }

        public string CalculateSin(string input)
        {
            InputAndResult.SendKeys(input);
            TrigonometryDropDown.Click();
            SinButton.Click();
            Equals.Click();
            return InputAndResult.Text;
        }

        public string CalculateCos(string input)
        {
            ClearEntry.Click();
            InputAndResult.SendKeys(input);
            TrigonometryDropDown.Click();
            CosButton.Click();
            Equals.Click();
            return InputAndResult.Text;
        }
    }
}
