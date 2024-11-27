using UserInterface.PageObject;


namespace UserInterface.Test
{
    public class CaseTwo : BaseTest
    {
        private LoginForm loginForm = new LoginForm();
        private HelpForm helpForm = new HelpForm();


        [Test]

        public void Setup()
        {
            homepageform.ClickHere();
            Assert.IsTrue(loginForm.IsPageOpened(), "Login form is not open");
            Assert.IsTrue(helpForm.IsPageOpened(), "Help form is not vivsible");
            helpForm.ClickSend();
            Assert.IsFalse(helpForm.IsElementDisappeared(), "Element was still visible after waiting");
        }
    }
}