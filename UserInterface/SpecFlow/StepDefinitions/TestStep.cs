using TechTalk.SpecFlow;
using UserInterface.PageObject;
using UserInterface.Utils;


namespace UserInterface.SpecFlow.StepDefinitions
{
    [Binding]

    public class TestStep
    {
        protected Dictionary<string, string> config = ConfigUtils.GetConfig();
        protected HomePageForm homepageform = new HomePageForm();
        private LoginForm loginForm = new LoginForm();
        private UserForm userForm = new UserForm();
        private HelpForm helpForm = new HelpForm();

        [Given(@"I make the window the maximum size")]
        public void GetMaximazeWindow()
        {
            DriverWebUtils.GetWebDriver().Manage().Window.Maximize();
        }

        [When(@"I go to the site ""userinyerface.com""")]
        public void GoNavigateURL()
        {
            DriverWebUtils.GetWebDriver().Navigate().GoToUrl(config["BaseUrl"]);
        }

        [Then(@"The home page is opened")]
        public void IsOpenHomePage()
        {
            Assert.IsTrue(homepageform.IsPageOpened(), "Home page is not open");
        }

        [When(@"In home page i click button ""HERE""")]
        public void ClickHereButton()
        {
            homepageform.ClickHere();
        }

        [Then(@"Login form is opened")]
        public void IsOpenLoginForm()
        {
            Assert.IsTrue(loginForm.IsPageOpened(), "Login form is not open");
        }

        [When(@"I clear the input fields and enter the password '(.*)', email '(.*)', lower domain '(.*)' and high domain '(.*)'")]
        public void InputData(string password, string email, string lowerdomain, string highdomain)
        {
            loginForm.SetPassword(password)
                     .SetEmailNameInput(email)
                     .SetDownDomain(lowerdomain)
                     .SetDomain(highdomain);
        }

        [When(@"I accept the user agreement, uncheck the box and click ""Next""")]
        public void ClickNextButton()
        {
            loginForm.ClickCheckBox()
                     .ClickNext();
        }

        [Then(@"User form is opened")]
        public void IsOpenUserForm()
        {
            Assert.IsTrue(userForm.IsPageOpened(), "User form is not open");
        }

        [When(@"I uncheck all interests and check three interests")]
        public void UncheckCheck()
        {
            userForm.UnSelectAllCheckBox().SelectIneterestCheckBox();
        }

        [When(@"Click button ""Daowland image""")]
        public void DaowlandImage()
        {
            userForm.ClickDowlandImage();
        }

        [Then(@"The download file has loaded")]
        public void IsCheckDownlandFile()
        {
            Assert.IsTrue(FileUtils.IsVisibleFile(config["DownloadPath"]), "File is not dowland or road for path is not correct");
        }

        [When(@"I delete the downloaded file")]
        public void DeleteFile()
        {
            File.Delete(config["DownloadPath"]);
        }

        [Then(@"The file was deleted")]
        public void IsCheckFilePC()
        {
            Assert.IsFalse(File.Exists(config["DownloadPath"]), "File is not delete");
        }

        [Then(@"Help form is opened")]
        public void IsOpenHelpForm()
        {
            Assert.IsTrue(helpForm.IsPageOpened(), "Help form is not vivsible");
        }

        [When(@"I click button ""Send""")]
        public void ClickSendButton()
        {
            helpForm.ClickSend();
        }

        [Then(@"The help form is missing")]
        public void IsOpenHelpform()
        {
            Assert.IsFalse(helpForm.IsElementDisappeared(), "Element was still visible after waiting");
        }

        [When(@"I Click accept coockie")]
        public void ClickAcceptButton()
        {
            loginForm.ClickAccept();
        }

        [Then(@"Field cookie is missed")]
        public void IsMissCookie()
        {
            Assert.IsTrue(loginForm.IsCookie(), "Massage cookie is vivsible");
        }

        [Then(@"Timer strarts wirh '(.*)'")]
        public void IsStartTimer(string time)
        {
            Assert.That(time, Is.EqualTo(loginForm.GetTextTimer()), "The timer does not start a 00.00");
        }
    }
}
