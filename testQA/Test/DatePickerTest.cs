using testQA.PageObject;
using testQA.Utils;


namespace testQA.Test
{
    public class DatePickerTest:BaseTest
    {
        private WidgetsMenuForm widgetsMenuForm = new WidgetsMenuForm();
        private DataPickerForm dataPickerForm = new DataPickerForm();

        [Test]
        public void DateTest()
        {
            LogUtils.LogNewTest("DatePickerTest");

            Assert.IsTrue(mainPage.IsPageOpened(), "MainPage is not open");
            mainPage.ClickWidgets();
            Assert.IsTrue(widgetsMenuForm.IsPageOpened(), "The widgets menu is not open");
            widgetsMenuForm.ClickDataPicker();
            Assert.IsTrue(dataPickerForm.IsPageOpened(), "Date picker is not open");

            Assert.IsTrue(dataPickerForm.EqualData(), "Select date or DateAndTime or Date in PC do not match");

            dataPickerForm.ClickSelectDate();
            dataPickerForm.SetDate(testData["Date"]);
            Assert.IsTrue(dataPickerForm.EqualSelectData(testData["Date"]), "Select Date and ValueDate is not match");
        }
    }
}
