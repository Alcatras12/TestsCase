using testQA.model;
using testQA.PageObject;
using testQA.Utils;


namespace testQA.Test
{
    public class TablesTest : BaseTest
    {
        private ElementsMenuForm elementsMenuForm = new ElementsMenuForm();
        private WebTablesForm webTablesForm = new WebTablesForm();
        private RegistrationForm registrationForm = new RegistrationForm();


        [Test, TestCaseSource(nameof(GetUsers))]
        public void TableTest1(User user)
        {
            LogUtils.LogNewTest("TableTest");

            Assert.IsTrue(mainPage.IsPageOpened(), "The main page is not open");

            mainPage.ClickElementsButton();
            Assert.IsTrue(elementsMenuForm.IsPageOpened(), "Elements menu is not open");
            elementsMenuForm.ClickWebTables();
            Assert.IsTrue(webTablesForm.IsPageOpened(), "Web Tables is not open");

            webTablesForm.ClickAdd();
            Assert.IsTrue(registrationForm.IsPageOpened(), "Registration form is not open");
            registrationForm.SendUserData(user);
            registrationForm.ClickSubmit();
            Assert.AreEqual(user.Email, webTablesForm.GetEmailUser(user.Email), "User is not add");

            webTablesForm.DeleteUser(user);
            Assert.IsFalse(webTablesForm.IsVisibaleUser(user), "User not deleted");
        }

        private static List<User> GetUsers() => ConfigUtils.GetUserData();
    }
}