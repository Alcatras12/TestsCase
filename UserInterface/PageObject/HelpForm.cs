using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UserInterface.BaseElement;
using UserInterface.BaseForm;
using UserInterface.Utils;


namespace UserInterface.PageObject
{
    public class HelpForm : BasePageForm
    {
        private Label helpFormLabel = new Label(By.XPath("//div[@class=\"align align--fluid align--even\"]"), "Help form label");
        private Button sendButton = new Button(By.XPath("//button[@class='button button--solid button--blue help-form__send-to-bottom-button']"), "Send button");

        public HelpForm()
        {
            base.element = helpFormLabel;
            base.name = helpFormLabel.name;
        }

        public HelpForm ClickSend()
        {
            sendButton.Click();
            return this;
        }

        public bool IsElementDisappeared()
        {
            LogUtils.log.Info($"Waiting for element {sendButton.name} to disappear");

            WebDriverWait wait = new WebDriverWait(DriverWebUtils.GetWebDriver(), TimeSpan.FromSeconds(20));
            try
            {
                wait.Until(driver => !sendButton.IsVisible());
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                LogUtils.log.Info("Element was still visible after waiting. Return FALSE");
                return false;
            }
        }
    }
}
