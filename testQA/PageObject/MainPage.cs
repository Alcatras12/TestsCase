using OpenQA.Selenium;
using testQA.baseElement;


namespace testQA.PageObject
{
    public class MainPage : BaseForm
    {
        private Label mainLabel = new Label(By.CssSelector("img.banner-image"), "mainLabel");
        private Button alertsFrameWindowButton = new Button(By.XPath("//h5[text()='Alerts, Frame & Windows']"), "alertsFrameWindowButton");
        private Button elementsButton = new Button(By.XPath("//h5[text()='Elements']"), "Elements Button");
        private Button widgetsButton = new Button(By.XPath("//h5[text()='Widgets']"), "Widgets button");

        public MainPage()
        {
            base.elements = mainLabel;
            base.name = mainLabel.name;
        }

        public void ClickAlertsFrameWindow() => alertsFrameWindowButton.Click();

        public void ClickElementsButton() => elementsButton.Click();

        public void ClickWidgets() => widgetsButton.Click();
    }
}
