using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using TestApiVk.Utils;


namespace TestApiVk
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
            LogUtils.log.Info($"Close webdriver");
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }

        public static void CloseWindow() => driver.Close();
    }
}