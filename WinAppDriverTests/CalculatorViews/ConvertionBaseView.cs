using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppDriverTests.CalculatorViews
{
    public class ConvertionBaseView: CalculatorBaseView
    {
        protected WindowsElement UnitFrom => _driver.FindElementByAccessibilityId("Units1");
        protected WindowsElement UnitTo => _driver.FindElementByAccessibilityId("Units2");
        protected WindowsElement UnitFromValue => _driver.FindElementByAccessibilityId("Value1");
        protected WindowsElement UnitToValue => _driver.FindElementByAccessibilityId("Value2");
        public ConvertionBaseView(WindowsDriver<WindowsElement> driver) : base(driver) 
        {
        }

        public void SelectUnitFrom(string unit)
        {
            UnitFrom.Click();
            SelectUnit(unit);
        }
        public void SelectUnitTo(string unit)
        {
            UnitTo.Click();
            SelectUnit(unit);
        }

        public virtual void SelectUnit(string unit)
        {

        }

        public void insertValue(string inputDegrees)
        {
            UnitFromValue.SendKeys(inputDegrees);
        }

        public string getResult()
        {
            return UnitToValue.Text;
        }

    }
}
