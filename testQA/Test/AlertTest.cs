using testQA.PageObject;
using testQA.Utils;


namespace testQA.Test
{
    public class AlertTest : BaseTest
    {
        private AlertsForm alertsForm = new AlertsForm();
        private AlertsFrameWindowMenuForm alertsFrameWindowMenuForm = new AlertsFrameWindowMenuForm();

        [Test]
        public void AlertFormTest()
        {
            LogUtils.LogNewTest("AlertTest");

            Assert.IsTrue(mainPage.IsPageOpened(), "MainPage is not open");

            mainPage.ClickAlertsFrameWindow();
            alertsFrameWindowMenuForm.ClickAlerts();
            Assert.IsTrue(alertsForm.IsPageOpened(), "AlertsForm is not open");

            alertsForm.ClickSeeAlert();
            AlertUtils.SwitchAlert();
            string expectedAlertText = testData["AlertText"].ToLower();
            string alertText = AlertUtils.TakeTextAlert().ToLower();
            Assert.AreEqual(alertText, expectedAlertText, "Wrong text alert or alert didn't open");
            AlertUtils.AcceptAlert();

            alertsForm.ClickConfirmationWindow();
            string confirmAlertText = AlertUtils.TakeTextAlert().ToLower();
            string expectedConfirmAlertText = testData["ConfirmAlertText"].ToLower();
            Assert.AreEqual(expectedConfirmAlertText, confirmAlertText, "Wrong text confirm alert or alert didn't open");
            AlertUtils.AcceptAlert();
            Assert.IsTrue(AlertUtils.IsAlertClosed(), "Confirm alert didn't close");

            alertsForm.ClickPromtButton();
            string promptAlertText = AlertUtils.TakeTextAlert().ToLower();
            string expectedPromptAlertText = testData["PromptAlertText"].ToLower();
            Assert.AreEqual(expectedPromptAlertText, promptAlertText, "Wrong text confirm alert or alert didn't open");
            AlertUtils.SendKeysAlert(StringUtils.GenerateRandomString());
            AlertUtils.AcceptAlert();
            Assert.IsTrue(AlertUtils.IsAlertClosed(), "Confirm alert didn't close");
        }
    }
}