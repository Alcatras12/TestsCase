using OpenQA.Selenium;
using testQA.Utils;


namespace testQA.baseElement
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
            try
            {
                LogUtils.log.Info($"Search element - {name}");
                var element = GetElement();
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public string GetText()
        {
            var text = GetElement().Text;
            LogUtils.log.Info($"Get text: \"{text}\". From {name}");
            return text;
        }

        public string GetAttribute(string value)
        {
            LogUtils.log.Info($"Get attribute from {value} from {name}");
            return GetElement().GetAttribute(value);
        }
    }
}
