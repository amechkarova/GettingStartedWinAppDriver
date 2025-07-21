using OpenQA.Selenium.Appium.Windows;

namespace WinAppDriverTests.CalculatorViews;

public class ConvertionBaseView: CalculatorBaseView
{
    protected WindowsElement UnitFrom => _driver.FindElementByAccessibilityId("Units1");
    protected WindowsElement UnitTo => _driver.FindElementByAccessibilityId("Units2");
    protected WindowsElement UnitFromValue => _driver.FindElementByAccessibilityId("Value1");
    protected WindowsElement UnitToValue => _driver.FindElementByAccessibilityId("Value2");
    public ConvertionBaseView(WindowsDriver<WindowsElement> driver) : base(driver) 
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
