using OpenQA.Selenium;
using UserInterface.BaseForm;
using UserInterface.BaseElement;
using UserInterface.Utils;


namespace UserInterface.PageObject
{
    public class LoginForm : BasePageForm
    {
        private Label loginform = new Label(By.CssSelector("div.login-form__container"), "Login form label");
        private Input passwordInput = new Input(By.XPath("//input[@placeholder=\"Choose Password\"]"), "Password input");
        private Input emailNameInput = new Input(By.XPath("//input[@placeholder=\"Your email\"]"), "Email input without attribute");
        private Input emailDownDomainInput = new Input(By.XPath("//input[@placeholder='Domain']"), "Email down domain input");
        private DropDown emailHighDomainDropDown = new DropDown(By.XPath("//div[@class='dropdown__field']"), "Email high domain DropDown");
        private CheckBox agreeCheckBox = new CheckBox(By.XPath("//span[@class='checkbox__box']"), "Agree check box");
        private Button nextButton = new Button(By.XPath("//a[@class='button--secondary']"), "Next button");
        private Button acceptCookieButton = new Button(By.XPath("//button[@class='button button--solid button--transparent']"), "Accept cookie button");
        private TextField timerTextField = new TextField(By.XPath("//div[@class='timer timer--white timer--center']"), "Timer text field");

        public LoginForm()
        {
            base.element = loginform;
            base.name = loginform.name;
        }

        public LoginForm SetDomain(string domain)
        {
            IWebElement webelement = emailHighDomainDropDown.GetElement();
            webelement.Click();
            var setdomain = DriverWebUtils.GetWebDriver().FindElement(By.XPath($"//div[text()='{domain}']"));
            setdomain.Click();
            return this;
        }

        public LoginForm SetPassword(string password)
        {
            passwordInput.ClearInputField().SendKey(password);
            return this;
        }

        public LoginForm SetEmailNameInput(string emailName)
        {
            emailNameInput.ClearInputField().SendKey(emailName);
            return this;
        }

        public LoginForm SetDownDomain(string downDomain)
        {
            emailDownDomainInput.ClearInputField().SendKey(downDomain);
            return this;
        }

        public LoginForm ClickCheckBox()
        {
            agreeCheckBox.Click();
            return this;
        }

        public LoginForm ClickNext()
        {
            nextButton.Click();
            return this;
        }

        public LoginForm ClickAccept()
        {
            acceptCookieButton.IsVisible();
            acceptCookieButton.Click();
            return this;
        }

        public bool IsCookie()
        {
            return acceptCookieButton.IsNotVisible();
        }

        public string GetTextTimer()
        {
            return timerTextField.GetText();
        }
    }
}