using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppDriverTests.CalculatorViews
{
    public class AreaCalculatorView : ConvertionBaseView
    {
        protected WindowsElement SquareCm => _driver.FindElementByName("Square centimeters");
        protected WindowsElement SquareFeet => _driver.FindElementByName("Square feet");

        public AreaCalculatorView(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }
        public override void SelectUnit(string unit)
        {
            switch (unit)
            {
                case "Square centimeters": SquareCm.Click(); break;
                case "Square feet": SquareFeet.Click(); break;
                default: throw new InvalidDataException();
            }
        }
    }
}
