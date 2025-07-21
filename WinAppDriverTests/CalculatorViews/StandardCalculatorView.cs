using OpenQA.Selenium.Appium.Windows;

namespace WinAppDriverTests.CalculatorViews;

public class StandardCalculatorView : CalculatorBaseView
{
    public StandardCalculatorView(WindowsDriver<WindowsElement> driver) : base(driver) 
    { 
    }
}
