using OpenQA.Selenium.Appium.Windows;
using WinAppDriverTests.CalculatorViews.Enums;

namespace WinAppDriverTests.CalculatorViews;

public class TemperatureCalculatorView : ConvertionBaseView
{
    public TemperatureCalculatorView(WindowsDriver<WindowsElement> driver) : base(driver) 
    { 
    }

    public void SelectUnitFrom(TemperatureUnits unit)
    {
        UnitFrom.Click();
        SelectUnit(unit);
    }

    public void SelectUnitTo(TemperatureUnits unit)
    {
        UnitTo.Click();
        SelectUnit(unit);
    }

    public void SelectUnit(TemperatureUnits unit)
    {
        _driver.FindElementByName(unit.ToString()).Click();
    }
}
