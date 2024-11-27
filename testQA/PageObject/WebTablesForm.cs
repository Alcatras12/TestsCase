using testQA.baseElement;
using testQA.Utils;
using OpenQA.Selenium;
using testQA.model;


namespace testQA.PageObject
{
    public class WebTablesForm : BaseForm
    {
        private Label webTablesLabel = new Label(By.XPath("//h1[text()='Web Tables']"), "Label Web Tables");
        private Button addButton = new Button(By.CssSelector("#addNewRecordButton"), "Add button");

        public WebTablesForm()
        {
            base.elements = webTablesLabel;
            base.name = webTablesLabel.name;
        }

        public void ClickAdd() => addButton.Click();

        public string GetEmailUser(string email)
        {
            Label visibleEmail = new Label(By.XPath($"//div[text()='{email}']"), "Email User");
            return visibleEmail.GetText();
        }

        public void DeleteUser(User user) => GetDeleteButton(user.Email).Click();

        private Label GetDeleteButton(string email) => new Label(By.XPath($"//div[text()='{email}']//following-sibling::div[3]//span[contains(@id,'delete')]"), "Delete button");

        public bool IsVisibaleUser(User user)
        {
            try
            {
                LogUtils.log.Info($"Search element - {user.Email}");
                var element = DriverWebUtils.GetWebDriver().FindElement(By.XPath($"//div[text()='{user.Email}']"));
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
