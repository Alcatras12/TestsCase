using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UserInterface.BaseElement;
using UserInterface.Utils;



namespace UserInterface.BaseForm
{
    public abstract class BasePageForm
    {
        protected Label element;
        protected string name;

        public bool IsPageOpened()
        {
            LogUtils.log.Info($"Waiting elemenst {element.name}");

            WebDriverWait wait = new WebDriverWait(DriverWebUtils.GetWebDriver(), TimeSpan.FromSeconds(5));
            try
            {
                wait.Until(driver => element.IsVisible());
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
