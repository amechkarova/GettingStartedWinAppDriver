using Interop.UIAutomationClient;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System.Collections.ObjectModel;
using System.Linq;

namespace WinAppDriverTests
{
    [TestFixture]
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
        public void CelciusToFahrenHeit()
        {
            _driver.FindElementByAccessibilityId("TogglePaneButton").Click();
            _driver.FindElementByAccessibilityId("Temperature").Click();
            _driver.FindElementByAccessibilityId("Units1").Click();
            _driver.FindElementByName("Celsius").Click();
            _driver.FindElementByAccessibilityId("Units2").Click();
            _driver.FindElementByName("Fahrenheit").Click();
            _driver.FindElementByAccessibilityId("num3Button").Click();
            _driver.FindElementByAccessibilityId("num6Button").Click();
            _driver.FindElementByAccessibilityId("decimalSeparatorButton").Click();
            _driver.FindElementByAccessibilityId("num6Button").Click();
            string fahrenheit = _driver.FindElementByAccessibilityId("Value2").Text;
            ClassicAssert.IsTrue(fahrenheit.Contains("97.88"));
        }

        [Test]
        public void SquareCentimetersToSuqareFeets()
        {
            _driver.FindElementByAccessibilityId("TogglePaneButton").Click();
            _driver.FindElementByAccessibilityId("Area").Click();
            _driver.FindElementByAccessibilityId("Units1").Click();
            _driver.FindElementByName("Square centimeters").Click();
            _driver.FindElementByAccessibilityId("Units2").Click();
            _driver.FindElementByName("Square feet").Click();
            _driver.FindElementByAccessibilityId("num1Button").Click();
            _driver.FindElementByAccessibilityId("num0Button").Click();
            string feet = _driver.FindElementByAccessibilityId("Value2").Text;
            ClassicAssert.IsTrue(feet.Contains("0.010764"));

            //Trying to verify the value in 'About equal to' section
            //var elements = _driver.FindElementsByTagName("Text");
            //bool squareInches = false;
            //bool squareMillimeters = false;
            //bool hands = false;
            //for (int i = 0; i < elements.Count; i++)
            //{
            //    if (elements[i].GetAttribute("Name").StartsWith("1.55 Square inches"))
            //        squareInches = true;
            //    if(elements[i].GetAttribute("Name").StartsWith("1,000 Square millimeters"))
            //        squareMillimeters = true;
            //    if (elements[i].GetAttribute("Name").StartsWith("0.08 hands"))
            //        hands = true;
            //}
            //ClassicAssert.IsTrue(squareInches);
            //ClassicAssert.IsTrue(squareMillimeters);
            //ClassicAssert.IsTrue(hands);
        }

        [Test]
        [TestCase("45", "5", "2", "-5.2051948326348630821610397049348")]
        [TestCase("6", "2", "6", "-8.0802560960265631290285898187409")]
        [TestCase("77", "9.12", "1.6", "-9.5639166212377248900749403868848")]
        public void CalculateTheFormula(string m, string x, string y, string result)
        {
            _driver.FindElementByAccessibilityId("TogglePaneButton").Click();
            _driver.FindElementByAccessibilityId("Scientific").Click();
            _driver.FindElementByAccessibilityId("piButton").Click();
            _driver.FindElementByAccessibilityId("plusButton").Click();
            _driver.FindElementByAccessibilityId("CalculatorResults").SendKeys(m);
            _driver.FindElementByAccessibilityId("logBase10Button").Click();
            _driver.FindElementByAccessibilityId("minusButton").Click();
            _driver.FindElementByAccessibilityId("openParenthesisButton").Click();
            _driver.FindElementByAccessibilityId("CalculatorResults").SendKeys(x);
            _driver.FindElementByAccessibilityId("multiplyButton").Click();
            _driver.FindElementByAccessibilityId("CalculatorResults").SendKeys(y);
            _driver.FindElementByAccessibilityId("closeParenthesisButton").Click();
            _driver.FindElementByAccessibilityId("equalButton").Click();
            ClassicAssert.IsTrue(_driver.FindElementByAccessibilityId("CalculatorResults").Text.Contains(result));
        }

        [Test]
        [TestCase("-5.2051948326348630821610397049348", "-0.09072287360974533679507748049222", "0.99587617714452341101765281274962")]
        [TestCase("-8.0802560960265631290285898187409", "-0.14056006525599466872192764707835", "0.99007215295413218706189973980864")]
        [TestCase("-9.5639166212377248900749403868848", "-0.16614775924946538440226613696557", "0.98610086811460707171368806397877")]
        public void CalculateSinAndCos(string input, string sinValue, string cosValue)
        {
            _driver.FindElementByAccessibilityId("TogglePaneButton").Click();
            _driver.FindElementByAccessibilityId("Scientific").Click();
            _driver.FindElementByAccessibilityId("CalculatorResults").SendKeys(input);
            _driver.FindElementByAccessibilityId("trigButton").Click();
            _driver.FindElementByAccessibilityId("sinButton").Click();
            _driver.FindElementByAccessibilityId("equalButton").Click();
            string sinValueActual = _driver.FindElementByAccessibilityId("CalculatorResults").Text;   
            _driver.FindElementByAccessibilityId("clearEntryButton").Click();
            _driver.FindElementByAccessibilityId("CalculatorResults").SendKeys(input);
            _driver.FindElementByAccessibilityId("trigButton").Click();
            _driver.FindElementByAccessibilityId("cosButton").Click();
            _driver.FindElementByAccessibilityId("equalButton").Click();
            string cosValueActual = _driver.FindElementByAccessibilityId("CalculatorResults").Text;
            ClassicAssert.IsTrue(sinValueActual.Contains(sinValue));
            ClassicAssert.IsTrue(cosValueActual.Contains(cosValue));
        }
    }
}
