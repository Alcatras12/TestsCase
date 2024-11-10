using UserInterface.PageObject;
using UserInterface.Utils;


namespace UserInterface.Test
{
    public class CaseOne : BaseTest
    {
        private LoginForm loginForm = new LoginForm();
        private UserForm userForm = new UserForm();
        
        [Test]

        public void Setup()
        {
            homepageform.ClickHere();
            Assert.IsTrue(loginForm.IsPageOpened(), "Login form is not open");

            loginForm.SetPassword(config["Pasword"])
                     .SetEmailNameInput(config["EmailName"])
                     .SetDownDomain(config["DownDomen"])
                     .SetDomain(config["HighDomen"])
                     .ClickCheckBox()
                     .ClickNext();

            Assert.IsTrue(userForm.IsPageOpened(), "User form is not open");

            userForm.UnSelectAllCheckBox()
                    .SelectIneterestCheckBox()
                    .ClickDowlandImage();

            Assert.IsTrue(FileUtils.IsVisibleFile(config["DownloadPath"]), "File is not dowland or road for path is not correct");
        }

        [TearDown]

        public void Test1()
        {
            File.Delete(config["DownloadPath"]);
            Assert.IsFalse(File.Exists(config["DownloadPath"]), "File is not delete");
        }
    }
}