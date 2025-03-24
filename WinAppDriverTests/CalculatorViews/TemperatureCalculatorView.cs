using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppDriverTests.CalculatorViews
{
    public class TemperatureCalculatorView : ConvertionBaseView
    {
        protected WindowsElement Celsius => _driver.FindElementByName("Celsius");
        protected WindowsElement Fahrenheit => _driver.FindElementByName("Fahrenheit");
        protected WindowsElement Kelvin => _driver.FindElementByName("Kelvin");

        public TemperatureCalculatorView(WindowsDriver<WindowsElement> driver) : base(driver) 
        { 
        }

        public override void SelectUnit(string unit)
        {
            switch(unit)
            {
                case "Celsius": Celsius.Click(); break;
                case "Fahrenheit": Fahrenheit.Click(); break;
                case "Kelvin": Kelvin.Click(); break;   
            }
        }
    }
}
