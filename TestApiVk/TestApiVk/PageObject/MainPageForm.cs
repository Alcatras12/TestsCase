using TestApiVk.Elements;
using OpenQA.Selenium;


namespace TestApiVk.PageObject
{
    public class MainPageForm:BaseForm
    {
        private Label vkLabel = new Label(By.XPath("//a[@class='TopHomeLink ']"), "VKonakte label");
        private Input loginInput = new Input(By.XPath("//input[@class='VkIdForm__input']"), "Login input");
        private CheckBox saveLoginCheckBox = new CheckBox(By.XPath("//span[@class='VkIdCheckbox__name']"), "Save login check box");
        private Button signInButton = new Button(By.XPath("//div[@id='index_login']/descendant::span[@class='FlatButton__in']"), "Sign in button");

        public MainPageForm()
        {
            base.elements = vkLabel;
            base.name = vkLabel.name;
        }

        public MainPageForm EntryLogin(string login)
        {
            loginInput.ClearInputField().SendKey(login);
            return this;
        }

        public MainPageForm ClickSaveLoginCheckBox()
        {
            saveLoginCheckBox.Click();
            return this;
        }

        public MainPageForm ClickSignInButton()
        {
            signInButton.Click();
            return this;
        }
    }
}
