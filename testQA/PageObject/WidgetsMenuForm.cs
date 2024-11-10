using OpenQA.Selenium;
using testQA.baseElement;


namespace testQA.PageObject
{
    public class WidgetsMenuForm : BaseForm
    {
        private Label widgetsMenuLabel = new Label(By.XPath("//div[contains(@class,'collapse show')]"), "Widgets menu lable");
        private Button sliderButton = new Button(By.XPath("//span[text()='Slider']"), "Slider button");
        private Button progressBarButton = new Button(By.XPath("//span[text()='Progress Bar']"), "Progress Bar button");
        private Button dataPickerButton = new Button(By.XPath("//span[text()='Date Picker']"), "Data Picker button");

        public WidgetsMenuForm()
        {
            base.elements = widgetsMenuLabel;
            base.name = widgetsMenuLabel.name;
        }

        public void ClickSlider() => sliderButton.Click();

        public void ClickProgressBar() => progressBarButton.Click();

        public void ClickDataPicker() => dataPickerButton.Click();
    }
}
