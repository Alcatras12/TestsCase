using testQA.PageObject;
using testQA.Utils;


namespace testQA.Test
{
    public abstract class BaseTest
    {
        protected MainPage mainPage = new MainPage();
        protected Dictionary<string, string> testData = ConfigUtils.GetTestData();
        protected Dictionary<string, string> config = ConfigUtils.GetConfig();


        [SetUp]
        public void SetUp()
        {
            DriverWebUtils.GetWebDriver().Manage().Window.Maximize();
            DriverWebUtils.GetWebDriver().Navigate().GoToUrl(config["BaseUrl"]);
        }

        [TearDown]
        public void TearDown()
        {
            DriverWebUtils.CloseWebDriver();
        }
    }
}
