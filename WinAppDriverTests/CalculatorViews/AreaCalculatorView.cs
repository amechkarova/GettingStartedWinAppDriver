using OpenQA.Selenium.Appium.Windows;
using WinAppDriverTests.CalculatorViews.Enums;

namespace WinAppDriverTests.CalculatorViews;

public class AreaCalculatorView : ConvertionBaseView
{
    protected WindowsElement SquareCm => _driver.FindElementByName("Square centimeters");
    protected WindowsElement SquareFeet => _driver.FindElementByName("Square feet");

    public AreaCalculatorView(WindowsDriver<WindowsElement> driver) : base(driver)
    {
    }

    public void SelectUnit(AreaUnits unit)
    {
        switch (unit)
        {
            case AreaUnits.SquareCentimeters: SquareCm.Click(); break;
            case AreaUnits.SquareFeet: SquareFeet.Click(); break;
            default: throw new InvalidDataException();
        }
    }

    public void SelectUnitFrom(AreaUnits unit)
    {
        UnitFrom.Click();
        SelectUnit(unit);
    }

    public void SelectUnitTo(AreaUnits unit)
    {
        UnitTo.Click();
        SelectUnit(unit);
    }
}
