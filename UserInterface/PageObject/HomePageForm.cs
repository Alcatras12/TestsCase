using OpenQA.Selenium;
using UserInterface.BaseForm;
using UserInterface.BaseElement;


namespace UserInterface.PageObject
{
    public class HomePageForm : BasePageForm
    {
        private Label HomePageLabel = new Label(By.XPath("//div[@class='logo__icon']"), "Home page label");
        private Button ClickHereButton = new Button(By.XPath("//a[text()='HERE']"), "ClickHERE button");

        public HomePageForm()
        {
            base.element = HomePageLabel;
            base.name = HomePageLabel.name;
        }

        public void ClickHere() => ClickHereButton.Click();
    }
}
