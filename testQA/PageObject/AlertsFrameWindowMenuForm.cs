using OpenQA.Selenium;
using testQA.baseElement;


namespace testQA.PageObject
{
    public class AlertsFrameWindowMenuForm : BaseForm
    {
        private Label alertsFrameWindowMenuLabel = new Label(By.XPath("//div[@class=\"element-list collapse show\"]"), "AlertsFrameWindow title");
        private Button framesButton = new Button(By.XPath("//span[text()='Frames']"), "Frames Button");
        private Button nestedFarmeButton = new Button(By.XPath("//span[text()='Nested Frames']"), "Nested farme Button");
        private Button alertsButton = new Button(By.XPath("//span[text()='Alerts']"), "alerts button");
        private Button browserWindowButton = new Button(By.XPath("//span[text()='Browser Windows']"), "Browser window button");

        public AlertsFrameWindowMenuForm()
        {
            base.elements = alertsFrameWindowMenuLabel;
            base.name = alertsFrameWindowMenuLabel.name;
        }

        public void ClickFramesButton() => framesButton.Click();

        public void ClickNestedFarmeButton() => nestedFarmeButton.Click();

        public void ClickAlerts() => alertsButton.Click();

        public void ClickBrowserWindowButton() => browserWindowButton.Click();
    }
}
