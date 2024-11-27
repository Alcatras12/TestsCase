using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;


namespace testQA.Utils
{
    public class DriverWebUtils
    {
        private static IWebDriver? driver;

        private DriverWebUtils() { }

        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                {
                    LogUtils.log.Info("Create ChromeDriver");
                    driver = new ChromeDriver();
                }
                return driver;
            }
        }

        public static IWebDriver GetWebDriver()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = Driver;
            return driver;
        }

        public static void CloseWebDriver()
        {
            if (driver != null)
            {
                LogUtils.log.Info("Close WebDriver");
                driver.Quit();
                driver = null;
            }
        }

        public static void SwitchToNextWindow()
        {
            LogUtils.log.Info($"Switch to next window");
            string currentWindowHandle = driver.CurrentWindowHandle;
            var windowHandles = driver.WindowHandles;
            int currentIndex = windowHandles.IndexOf(currentWindowHandle);
            if (currentIndex < windowHandles.Count - 1)
            {
                driver.SwitchTo().Window(windowHandles[currentIndex + 1]);
            }
            else
            {
                driver.SwitchTo().Window(windowHandles[0]);
            }
        }

        public static void SwitchToParentWindow()
        {
            LogUtils.log.Info("Switch to parent window");
            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }

        public static void CloseWindow() => driver.Close();

        public static void ScrollWindowDown()
        {
            LogUtils.log.Info($"Scroll window down");
            IJavaScriptExecutor js = (IJavaScriptExecutor)GetWebDriver();
            js.ExecuteScript("window.scrollBy(0,1000)");
        }
        public static void ScrollToElement(IWebElement element)
        {
            LogUtils.log.Info($"Scroll to {element}");
            IJavaScriptExecutor js = (IJavaScriptExecutor)GetWebDriver();
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
    }
}
