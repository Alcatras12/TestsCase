using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestApiVk.Utils;


namespace TestApiVk.BaseElement
{
    public abstract class BaseElements
    {
        public string name;
        public By locator;

        public BaseElements(By locator, string name)
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
            LogUtils.log.Info($"Click element '{name}'");
            GetElement().Click();
        }

        public bool IsVisible(ElementState state = ElementState.Visible)
        {
            LogUtils.log.Info($"Wait element '{name}'");
            WebDriverWait wait = new WebDriverWait(DriverWebUtils.GetWebDriver(), TimeSpan.FromSeconds(5));
            try
            {
                wait.Until(driver => state == ElementState.Visible ? GetElement().Displayed : !GetElement().Displayed);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public string GetText()
        {
            var text = GetElement().Text;
            LogUtils.log.Info($"Get text: '{text}' from {name}");
            return text;
        }
    }

    public enum ElementState
    {
        Visible,
        NotVisible
    }
}
