using testQA.baseElement;
using OpenQA.Selenium;
using testQA.model;
using testQA.Utils;


namespace testQA.PageObject
{
    public class RegistrationForm : BaseForm
    {
        private Label registationformLabel = new Label(By.XPath("//div[text()='Registration Form']"), "Registration Form");
        private Input firstnameInput = new Input(By.Id("firstName"), "First name input");
        private Input lastnametInput = new Input(By.Id("lastName"), "Last name input");
        private Input emailInput = new Input(By.Id("userEmail"), "Email input");
        private Input ageInput = new Input(By.Id("age"), "Age input");
        private Input salaryInput = new Input(By.Id("salary"), "Salary input");
        private Input departmentInput = new Input(By.Id("department"), "Department input");
        private Button submitButton = new Button(By.Id("submit"), "Submit button");

        public RegistrationForm()
        {
            base.elements = registationformLabel;
            base.name = registationformLabel.name;
        }

        public void SendUserData(User user)
        {
            LogUtils.log.Info("User data entry");
            firstnameInput.SendKey(user.FirstName);
            lastnametInput.SendKey(user.LastName);
            emailInput.SendKey(user.Email);
            ageInput.SendKey(user.Age);
            salaryInput.SendKey(user.Salary);
            departmentInput.SendKey(user.Department);
        }

        public void ClickSubmit() => submitButton.Click();
    }
}
