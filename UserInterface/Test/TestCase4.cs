using UserInterface.PageObject;


namespace UserInterface.Test
{
    public class CaseFor : BaseTest
    {
        private LoginForm loginForm = new LoginForm();

        [Test]

        public void Setup()
        {
            homepageform.ClickHere();
            Assert.IsTrue(loginForm.IsPageOpened(), "Login form is not open");
            Assert.That(config["Timer"], Is.EqualTo(loginForm.GetTextTimer()), "The timer does not start a 00.00");
        }
    }
}
