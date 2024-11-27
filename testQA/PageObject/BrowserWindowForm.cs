using testQA.baseElement;
using OpenQA.Selenium;

namespace testQA.PageObject
{
    public class BrowserWindowForm : BaseForm
    {
        private Label browserWindowFormLabel = new Label(By.XPath("//h1[text()='Browser Windows']"), "Browser Windows label");
        private Button newTabButton = new Button(By.Id("tabButton"), "New Tab button");
        private Button elementsButton = new Button(By.XPath("//div[@class='header-text' and text()='Elements']"), "Elements button");
        public BrowserWindowForm()
        {
            base.elements = browserWindowFormLabel;
            base.name = browserWindowFormLabel.name;
        }

        public void ClickNewTab() => newTabButton.Click();

        public void ClickElements() => elementsButton.Click();
    }
}
