using OpenQA.Selenium;
using UserInterface.BaseForm;
using UserInterface.BaseElement;


namespace UserInterface.PageObject
{
    public class UserForm : BasePageForm
    {
        private Label userFormLabel = new Label(By.XPath("//div[@class='avatar-and-interests__form']"),"User form label");
        private Button dowlandImageButton = new Button(By.XPath("//button[text()='Download image']"), "Dowland image button");
        private Button uploadButton = new Button(By.XPath("//a[@class='avatar-and-interests__upload-button']"), "Upload button");
        private CheckBox unselectAllCheckBox = new CheckBox(By.XPath("//label[@for=\"interest_unselectall\"]"), " Unselect All CheckBox");
        private CheckBox interest1 = new CheckBox(By.XPath("//label[@for='interest_ponies']"), " Interest1 CheckBox");
        private CheckBox interest2 = new CheckBox(By.XPath("//label[@for='interest_polo']"), " Interest2 CheckBox");
        private CheckBox interest3 = new CheckBox(By.XPath("//label[@for='interest_dough']"), " Interest3 CheckBox");

        public UserForm()
        {
            base.element = userFormLabel;
            base.name = userFormLabel.name;
        }

        public UserForm UnSelectAllCheckBox()
        {
            unselectAllCheckBox.Click();
            return this;
        }

        public UserForm SelectIneterestCheckBox()
        {
            interest1.GetElement().Click();
            interest2.GetElement().Click();
            interest3.GetElement().Click();
            return this;
        }

        public UserForm ClickDowlandImage()
        {
            dowlandImageButton.Click();
            return this;
        }

        public UserForm ClickUpload()
        {
            uploadButton.Click();
            return this;
        }
    }
}
