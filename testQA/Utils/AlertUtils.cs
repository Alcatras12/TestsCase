using OpenQA.Selenium;


namespace testQA.Utils
{
    public static class AlertUtils
    {
        private static IAlert alert;

        public static void SwitchAlert()
        {
            alert = DriverWebUtils.GetWebDriver().SwitchTo().Alert();
        }

        public static void AcceptAlert()
        {
            LogUtils.log.Info("Alert click 'OK'");
            alert.Accept();
        }

        public static void SendKeysAlert(string value)
        {
            LogUtils.log.Info($"Input text - {value}");
            alert.SendKeys(value);
        }

        public static bool IsAlertClosed()
        {
            try
            {
                AlertUtils.SwitchAlert();
            }
            catch (NoAlertPresentException)
            {
                return true;
            }
            return false;
        }

        public static string TakeTextAlert() => alert.Text;
    }
}
