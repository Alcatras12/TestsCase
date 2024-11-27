using OpenQA.Selenium;
using testQA.baseElement;


namespace testQA.PageObject
{
    public class AlertsForm : BaseForm
    {
        private Label alertLabel = new Label(By.CssSelector("h1.text-center"), "AlertLabel");
        private Button seeAlertButton = new Button(By.CssSelector("div.row #alertButton"), "seeAlertButton ");
        private Button confirmationWindowButton = new Button(By.CssSelector("button#confirmButton"), "confirmationWindowButton");
        private Button promtButton = new Button(By.CssSelector("button#promtButton"), "PromtButton");

        public AlertsForm()
        {
            base.elements = alertLabel;
            base.name = alertLabel.name;
        }

        public void ClickSeeAlert() => seeAlertButton.Click();

        public void ClickConfirmationWindow() => confirmationWindowButton.Click();

        public void ClickPromtButton() => promtButton.Click();
    }
}
