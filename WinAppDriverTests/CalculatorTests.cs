using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework.Legacy;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using WinAppDriverTests.CalculatorViews;
using WinAppDriverTests.CalculatorViews.Enums;

namespace WinAppDriverTests;

[TestFixture]
[AllureNUnit]
[AllureTag("CI")]
[AllureIssue("8911")]
[AllureTms("532")]
[AllureOwner("Aneliya")]
[AllureSuite("Calculator")]
public class CalculatorTests
{
    private WindowsDriver<WindowsElement> _driver;
    [SetUp]
    public void TestInIt()
    {
        if(_driver == null)
        {
            var options = new AppiumOptions();
            options.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            _driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"),
           options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
    }

    [TearDown]
    public void TestTearDown()
    {
        if(_driver != null)
        {
            _driver.Close();
            _driver = null;
        }
    }

    [Test]
    [AllureSubSuite("Convertion")]
    [AllureFeature("Temperature")]
    public void CelsiusToFahrenheit()
    {
        CalculatorBaseView baseView = new CalculatorBaseView(_driver);
        baseView.SelectCalculatorType(CalculatorType.Temperature);
        TemperatureCalculatorView temperatureCalculatorView = new TemperatureCalculatorView(_driver);
        temperatureCalculatorView.SelectUnitFrom(TemperatureUnits.Celsius);
        temperatureCalculatorView.SelectUnitTo(TemperatureUnits.Fahrenheit);
        temperatureCalculatorView.insertValue("36.6");
        string fahrenheit = temperatureCalculatorView.getResult();
        ClassicAssert.IsTrue(fahrenheit.Contains("97.88"));
    }

    [Test]
    [AllureSubSuite("Convertion")]
    [AllureFeature("Area")]
    public void SquareCentimetersToSuqareFeets()
    {
        CalculatorBaseView baseView = new CalculatorBaseView(_driver);
        baseView.SelectCalculatorType(CalculatorType.Area);
        AreaCalculatorView areaCalculatorView = new AreaCalculatorView(_driver);
        areaCalculatorView.SelectUnitFrom(AreaUnits.SquareCentimeters);
        areaCalculatorView.SelectUnitTo(AreaUnits.SquareFeet);
        areaCalculatorView.insertValue("10");
        string feet = areaCalculatorView.getResult();
        ClassicAssert.IsTrue(feet.Contains("0.010764"));
    }

    [Test]
    [AllureSubSuite("Formula Calculation")]
    [AllureFeature("Expressions")]
    [TestCase("45", "5", "2", "-5.2051948326348630821610397049348")]
    [TestCase("6", "2", "6", "-8.0802560960265631290285898187409")]
    [TestCase("77", "9.12", "1.6", "-9.5639166212377248900749403868848")]
    public void CalculateTheFormula(string operand1, string operand2, string operand3, string result)
    {
        CalculatorBaseView baseView = new CalculatorBaseView(_driver);
        baseView.SelectCalculatorType(CalculatorType.Scientific);
        ScientificCalculatorView scientificCalculatorView = new ScientificCalculatorView(_driver);
        string calculatedValue = scientificCalculatorView.CalculateFormula(operand1, operand2, operand3);
        
        ClassicAssert.IsTrue(calculatedValue.Contains(result));
    }

    [Test]
    [AllureSubSuite("Formula Calculation")]
    [AllureFeature("Trigonometry")]
    [TestCase("-5.2051948326348630821610397049348", "-0.09072287360974533679507748049222", "0.99587617714452341101765281274962")]
    [TestCase("-8.0802560960265631290285898187409", "-0.14056006525599466872192764707835", "0.99007215295413218706189973980864")]
    [TestCase("-9.5639166212377248900749403868848", "-0.16614775924946538440226613696557", "0.98610086811460707171368806397877")]
    public void CalculateSinAndCos(string input, string sinValue, string cosValue)
    {
        CalculatorBaseView baseView = new CalculatorBaseView(_driver);
        baseView.SelectCalculatorType(CalculatorType.Scientific);
        ScientificCalculatorView scientificCalculatorView = new ScientificCalculatorView(_driver);
        string sinResult =  scientificCalculatorView.CalculateSin(input);
        string cosResult = scientificCalculatorView.CalculateCos(input);
        
        ClassicAssert.IsTrue(sinResult.Contains(sinValue));
        ClassicAssert.IsTrue(cosResult.Contains(cosValue));
    }
}
