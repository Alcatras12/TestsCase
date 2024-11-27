using TestApiVk.Elements;
using OpenQA.Selenium;


namespace TestApiVk.PageObject
{
    public class AutorizationPageForm : BaseForm
    {
        private Label vkAutorizationLabel = new Label(By.XPath("//div[@class='vkc__StepInfo__avatar vkc__StepInfo__hideAvatarMedia']"), "vkAutorization label");
        private Input passwordInput = new Input(By.XPath("//input[@name='password']"), "Password input");
        private Button signInButton = new Button(By.XPath("//span[@class='vkuiButton__in']"), "Sign in button");

        public AutorizationPageForm()
        {
            base.elements = vkAutorizationLabel;
            base.name = vkAutorizationLabel.name;
        }

        public AutorizationPageForm EntryPassword(string password)
        {
            passwordInput.ClearInputField()
                         .SendKey(password);
            return this;
        }

        public AutorizationPageForm ClickSignIn()
        {
            signInButton.Click();
            return this;
        }
    }
}
