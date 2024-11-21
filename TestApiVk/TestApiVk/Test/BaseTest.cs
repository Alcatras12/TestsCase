using TestApiVk.PageObject;
using TestApiVk.Utils;


namespace TestApiVk.Test
{
    public abstract class BaseTest
    {
        protected Dictionary<string, string> testData = ConfigUtils.GetUserData();
        protected Dictionary<string, string> configApi = ConfigUtils.GetConfigData();
        protected MainPageForm mainPageForm = new MainPageForm();


        [SetUp]
        public void SetUp()
        {
            LogUtils.LogNewTest("New test");
            DriverWebUtils.GetWebDriver().Manage().Window.Maximize();
            DriverWebUtils.GetWebDriver().Navigate().GoToUrl(testData["BaseURL"]);
            Assert.IsTrue(mainPageForm.IsPageOpened(), "Main page is not opened");
        }

        [TearDown]
        public void TearDown()
        {
            DriverWebUtils.CloseWebDriver();
        }
    }
}
