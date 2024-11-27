using testQA.PageObject;
using testQA.Utils;


namespace testQA.Test
{
    public class SliderProgressBarTest : BaseTest
    {
        private WidgetsMenuForm widgetsmenuform = new WidgetsMenuForm();
        private SliderForm sliderForm = new SliderForm();
        private ProgressBarForm progressbarForm = new ProgressBarForm();

        [Test]

        public void BarTest()
        {
            LogUtils.LogNewTest("SliderProgressBarTest");
            Assert.IsTrue(mainPage.IsPageOpened(), "The main page is not open");

            mainPage.ClickWidgets();
            Assert.IsTrue(widgetsmenuform.IsPageOpened(), "The widgets menu is not open");
            widgetsmenuform.ClickSlider();
            Assert.IsTrue(sliderForm.IsPageOpened(), "The slider page is not open");

            int randomInt = StringUtils.GenerateRandamInt();
            sliderForm.MoveSliderInput(randomInt);
            Assert.AreEqual(randomInt, sliderForm.GetValueSlider(), "Random value and Slider value dont match");

            DriverWebUtils.ScrollWindowDown();
            widgetsmenuform.ClickProgressBar();
            Assert.IsTrue(progressbarForm.IsPageOpened(), "Progress Bar page is not open");
            progressbarForm.ClickStartStopButton();
            int age = int.Parse(testData["Age"]);
            progressbarForm.StopProgressBar(age);
            Assert.IsTrue(progressbarForm.CheckValueProgressBar(age), "Age and current value dont match");
        }
    }
}
