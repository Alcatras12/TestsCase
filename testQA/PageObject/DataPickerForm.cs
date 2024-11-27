using OpenQA.Selenium;
using System.Globalization;
using testQA.baseElement;
using OpenQA.Selenium.Support.UI;
using testQA.Utils;


namespace testQA.PageObject
{
    public class DataPickerForm : BaseForm
    {
        private Label dataPickerLabel = new Label(By.XPath("//h1[text()='Date Picker']"), "Data Picker Label");
        private Input selectDateInput = new Input(By.Id("datePickerMonthYearInput"), "Select Date input");
        private TextField dateAndTimeTextField = new TextField(By.Id("dateAndTimePickerInput"), "Data and Time text field");
        private DateTime dateNow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
        private DropDown MonthDropDown = new DropDown(By.CssSelector("select.react-datepicker__month-select"), "DropDown month");
        private DropDown YearsDropDown = new DropDown(By.CssSelector("select.react-datepicker__year-select"), "DropDown years");

        public DataPickerForm()
        {
            base.elements = dataPickerLabel;
            base.name = dataPickerLabel.name;
        }

        public DateTime GetSelectData()
        {
            string date = selectDateInput.GetAttribute("value");
            LogUtils.log.Info($"Parse string in DataTime");
            return DateTime.ParseExact(date, "MM/dd/yyyy", CultureInfo.InvariantCulture);
        }

        public DateTime GetDateAndTime()
        {
            string date = dateAndTimeTextField.GetAttribute("value");
            LogUtils.log.Info($"Parse string in DataTime");
            return DateTime.ParseExact(date, "MMMM d, yyyy h:mm tt", CultureInfo.InvariantCulture);
        }

        public bool EqualData()
        {
            LogUtils.log.Info($"Equal date with date PC");
            return GetSelectData().Date == GetDateAndTime().Date &&
                GetDateAndTime().Date == dateNow.Date &&
                GetDateAndTime().TimeOfDay == dateNow.TimeOfDay;
        }

        public void ClickSelectDate() => selectDateInput.Click();

        public void SetDate(string dateStr)
        {
            LogUtils.log.Info($"Set date \"{dateStr}\" in form");
            DateTime date = DateTime.Parse(dateStr);
            int month = date.Month;
            int day = date.Day;
            int year = date.Year;
            var selectElementMonth = new SelectElement(MonthDropDown.GetElement());
            selectElementMonth.SelectByIndex(month - 1);
            var textMonth = selectElementMonth.SelectedOption.Text;
            var selectElementYear = new SelectElement(YearsDropDown.GetElement());
            selectElementYear.SelectByText($"{year}");
            var days = DriverWebUtils.GetWebDriver().FindElement(By.XPath($"//div[contains(@aria-label, '{textMonth}') and text()='{day}']"));
            DriverWebUtils.ScrollToElement(days);
            days.Click();
        }

        public bool EqualSelectData(string dateStr)
        {
            LogUtils.log.Info($"Equal SelectData \"{dateStr}\" ");
            DateTime selectdata = GetSelectData();
            DateTime date = DateTime.Parse(dateStr);
            return selectdata == date;
        }
    }
}
