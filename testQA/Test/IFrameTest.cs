using testQA.PageObject;
using testQA.Utils;


namespace testQA.Test
{
    public class IFrameTest : BaseTest
    {
        private NestedFramesForm nestedFramesForm = new NestedFramesForm();
        private FramesForm framesform = new FramesForm();
        private AlertsFrameWindowMenuForm alertsFrameWindowMenuForm = new AlertsFrameWindowMenuForm();

        [Test]
        public void Test1()
        {
            LogUtils.LogNewTest("IframeTest");

            Assert.IsTrue(mainPage.IsPageOpened(), "MainPage is not open");
            mainPage.ClickAlertsFrameWindow();
            alertsFrameWindowMenuForm.ClickNestedFarmeButton();
            Assert.IsTrue(nestedFramesForm.IsPageOpened(), "nestedFramesForm is not open");

            nestedFramesForm.GoToParentFrame();
            string parentText = nestedFramesForm.GetTextParentTextField().ToLower();
            string comparisonTextParent = testData["ParentFrameText"].ToLower();
            Assert.That(parentText, Is.EqualTo(comparisonTextParent), "Wrong text in parent frame");

            nestedFramesForm.GoToChildFrame();
            string childText = nestedFramesForm.GetTextChildTextField().ToLower();
            string comparisonTextChild = testData["ChildFrameText"].ToLower();
            Assert.AreEqual(childText, comparisonTextChild, "Wrong text in child frame");

            FrameUtils.SwitchDefaultFrame();

            //Second Part

            alertsFrameWindowMenuForm.ClickFramesButton();
            Assert.IsTrue(framesform.IsPageOpened(), "FramesForm is not open");

            framesform.GoToBigFarme();
            string textBigFrame = framesform.GetTextBigFrameTextField();

            FrameUtils.SwitchDefaultFrame();

            framesform.GoToSmallFrame();
            string textSmallFrame = framesform.GetTextSmallFrameTextField();

            Assert.AreEqual(textSmallFrame, textBigFrame, "Text in the small and large frames don't equal");
        }
    }
}