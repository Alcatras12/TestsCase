using UserInterface.PageObject;


namespace UserInterface.Test
{
    public class CaseThree : BaseTest
    {
        private LoginForm loginForm = new LoginForm();

        [Test]

        public void Setup()
        {
            homepageform.ClickHere();
            Assert.IsTrue(loginForm.IsPageOpened(), "Login form is not open");
            loginForm.ClickAccept();
            Assert.IsTrue(loginForm.IsCookie(), "Massage cookie is vivsible");
        }
    }
}
