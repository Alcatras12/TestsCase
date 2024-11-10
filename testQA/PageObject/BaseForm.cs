using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using testQA.baseElement;
using testQA.Utils;


namespace testQA.PageObject
{
    public abstract class BaseForm
    {
        protected Label elements;
        protected string name;

        public bool IsPageOpened()
        {
            LogUtils.log.Info($"Waiting elemenst {elements.name}");

            WebDriverWait wait = new WebDriverWait(DriverWebUtils.GetWebDriver(), TimeSpan.FromSeconds(5));
            try
            {
                wait.Until(driver => elements.IsVisible());
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                LogUtils.log.Info("Element was not visible after waiting.Return FALSE");
                return false;
            }
        }
    }
}
