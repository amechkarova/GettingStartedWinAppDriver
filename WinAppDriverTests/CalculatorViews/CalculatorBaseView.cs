using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppDriverTests.CalculatorViews
{
    public class CalculatorBaseView
    {
        protected WindowsDriver<WindowsElement> _driver;
        protected WindowsElement ToggleButton => _driver.FindElementByAccessibilityId("TogglePaneButton");
        protected WindowsElement TemperatureType => _driver.FindElementByAccessibilityId("Temperature");
        protected WindowsElement ScientificType => _driver.FindElementByAccessibilityId("Scientific");
        protected WindowsElement AreaType => _driver.FindElementByAccessibilityId("Area");
        protected WindowsElement StandardType => _driver.FindElementByAccessibilityId("Standard");
        protected WindowsElement Zero => _driver.FindElementByAccessibilityId("num0Button");
        protected WindowsElement One => _driver.FindElementByAccessibilityId("num1Button");
        protected WindowsElement Two => _driver.FindElementByAccessibilityId("num2Button");
        protected WindowsElement Three => _driver.FindElementByAccessibilityId("num3Button");
        protected WindowsElement Four => _driver.FindElementByAccessibilityId("num4Button");
        protected WindowsElement Five => _driver.FindElementByAccessibilityId("num5Button");
        protected WindowsElement Six => _driver.FindElementByAccessibilityId("num6Button");
        protected WindowsElement Seven => _driver.FindElementByAccessibilityId("num7Button");
        protected WindowsElement Eight => _driver.FindElementByAccessibilityId("num8Button");
        protected WindowsElement Nine => _driver.FindElementByAccessibilityId("num9Button");
        protected WindowsElement Plus => _driver.FindElementByAccessibilityId("plusButton");
        protected WindowsElement Minus => _driver.FindElementByAccessibilityId("minusButton");
        protected WindowsElement Multiply => _driver.FindElementByAccessibilityId("multiplyButton");
        protected WindowsElement Divide => _driver.FindElementByAccessibilityId("");
        protected WindowsElement Equals => _driver.FindElementByAccessibilityId("equalButton");
        protected WindowsElement DecimalSeparator => _driver.FindElementByAccessibilityId("decimalSeparatorButton");
        protected WindowsElement CalculatorResults => _driver.FindElementByAccessibilityId("CalculatorResults");
        public CalculatorBaseView(WindowsDriver<WindowsElement> driver) 
        { 
            _driver = driver ?? throw new ArgumentNullException("Driver can't be null");
        }

        public void SelectCalculatorType(string type)
        {
            ToggleButton.Click();
            switch(type)
            {
                case "Scientific": ScientificType.Click(); break;
                case "Temperature": TemperatureType.Click(); break;
                case "Area":
                    _driver.Keyboard.PressKey(Keys.PageDown);
                    AreaType.Click(); break;
                case "Standard": StandardType.Click(); break;
            }
        }

        public void EnterNumberInCalculatorInputField(string number)
        {
            CalculatorResults.SendKeys(number);
        } 
    }
}
