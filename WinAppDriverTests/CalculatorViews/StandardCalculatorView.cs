using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppDriverTests.CalculatorViews
{
    public class StandardCalculatorView : CalculatorBaseView
    {
        public StandardCalculatorView(WindowsDriver<WindowsElement> driver) : base(driver) 
        { 
        }

    }
}
