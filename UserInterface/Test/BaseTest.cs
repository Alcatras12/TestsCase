using UserInterface.PageObject;
using UserInterface.Utils;


namespace UserInterface.Test
{
    public abstract class BaseTest
    {
        protected Dictionary<string, string> config = ConfigUtils.GetConfig();
        protected HomePageForm homepageform = new HomePageForm();

        [SetUp]

        public void SetUp()
        {
            DriverWebUtils.GetWebDriver().Manage().Window.Maximize();
            DriverWebUtils.GetWebDriver().Navigate().GoToUrl(config["BaseUrl"]);
            Assert.IsTrue(homepageform.IsPageOpened());

        }

        [TearDown]

        public void TearDown()
        {
            DriverWebUtils.CloseWebDriver();
        }
    }
}
