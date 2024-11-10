using testQA.PageObject;
using testQA.Utils;


namespace testQA.Test
{
    public class HandlesTest : BaseTest
    {
        private AlertsFrameWindowMenuForm alertsFrameWindowMenuForm = new AlertsFrameWindowMenuForm();
        private BrowserWindowForm browserWindowForm = new BrowserWindowForm();
        private SamplePageForm samplePageForm = new SamplePageForm();
        private ElementsMenuForm elementsMenuForm = new ElementsMenuForm();
        private LinksForm linksForm = new LinksForm();

        [Test]

        public void HandlesTesting()
        {
            LogUtils.LogNewTest("HandlesTest");

            Assert.IsTrue(mainPage.IsPageOpened(), "MainPage is not open");

            mainPage.ClickAlertsFrameWindow();
            Assert.IsTrue(alertsFrameWindowMenuForm.IsPageOpened(), "Menu Alerts&Frame&WindowMenu is not open");

            alertsFrameWindowMenuForm.ClickBrowserWindowButton();
            Assert.IsTrue(browserWindowForm.IsPageOpened(), "Browser window is not open");

            browserWindowForm.ClickNewTab();
            DriverWebUtils.SwitchToNextWindow();
            Assert.IsTrue(samplePageForm.IsPageOpened(), "Sample page is not open");
            DriverWebUtils.CloseWindow();
            DriverWebUtils.SwitchToParentWindow();
            Assert.IsTrue(browserWindowForm.IsPageOpened(), "Browser window is not open or driver did not switch to the parent window");

            browserWindowForm.ClickElements();
            Assert.IsTrue(elementsMenuForm.IsPageOpened(), "Elements menu is not open");
            elementsMenuForm.ClickLinks();
            Assert.IsTrue(linksForm.IsPageOpened(), "Links is not open");
            linksForm.ClickHome();
            DriverWebUtils.SwitchToNextWindow();
            Assert.IsTrue(mainPage.IsPageOpened(), "MainPage is not open or driver did not switch to mainpage");
            DriverWebUtils.SwitchToParentWindow();
            Assert.IsTrue(linksForm.IsPageOpened(), "Links is not open or driver did not switch to parent window");
        }
    }
}
