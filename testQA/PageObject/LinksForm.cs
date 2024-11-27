using OpenQA.Selenium;
using testQA.baseElement;

namespace testQA.PageObject
{
    public class LinksForm : BaseForm
    {
        private Label linksLabel = new Label(By.XPath("//h1[text()='Links']"), "Links label");
        private Button homeButton = new Button(By.Id("simpleLink"), "Hone button");

        public LinksForm()
        {
            base.elements = linksLabel;
            base.name = linksLabel.name;
        }

        public void ClickHome() => homeButton.Click();
    }
}
