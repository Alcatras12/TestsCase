using OpenQA.Selenium;
using UserInterface.Utils;
using OpenQA.Selenium.Support.UI;


namespace UserInterface.BaseElement
{
    public abstract class BaseElement
    {
        public string name;
        public By locator;

        public BaseElement(By locator, string name)
        {
            this.name = name;
            this.locator = locator;
        }

        public IWebElement GetElement()
        {
            return DriverWebUtils.GetWebDriver().FindElement(locator);
        }

        public void Click()
        {
            LogUtils.log.Info($"Click element - {name}");
            GetElement().Click();
        }

        public bool IsVisible()
        {
            WebDriverWait wait = new WebDriverWait(DriverWebUtils.GetWebDriver(), TimeSpan.FromSeconds(15));
            try
            {
                LogUtils.log.Info($"Search element - {name}");
                wait.Until(element => GetElement().Displayed);

                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsNotVisible()
        {
            try
            {
                LogUtils.log.Info($"Search element - {name}");
                var element = GetElement().Displayed;

                return false;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
        }

        public string GetText()
        {
            var text = GetElement().Text;
            LogUtils.log.Info($"Get text: \"{text}\". From {name}");
            return text;
        }
    }
}
