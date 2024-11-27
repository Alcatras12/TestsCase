using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestApiVk.Utils;


namespace TestApiVk.Elements
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

        public List<IWebElement> GetElements()
        {
            return DriverWebUtils.GetWebDriver().FindElements(locator).ToList();
        }

        public void Click()
        {
            LogUtils.log.Info($"Click element '{name}'");
            GetElement().Click();
        }

        public bool IsVisible(ElementState state = ElementState.Visible)
        {
            LogUtils.log.Info($"Wait element '{name}'");
            WebDriverWait wait = new WebDriverWait(DriverWebUtils.GetWebDriver(), TimeSpan.FromSeconds(10));
            return wait.Until(driver => state == ElementState.Visible ? GetElements().Count != 0 : GetElements().Count == 0);
        }

        public string GetText()
        {
            LogUtils.log.Info($"Get text from {name}");
            var text = GetElement().Text;
            return text;
        }

        public void ScrollToElement()
        {
            LogUtils.log.Info($"Scroll window to {name}");
            IJavaScriptExecutor js = (IJavaScriptExecutor)DriverWebUtils.GetWebDriver();
            js.ExecuteScript("arguments[0].scrollIntoView(true);", GetElement());
        }
    }
}
