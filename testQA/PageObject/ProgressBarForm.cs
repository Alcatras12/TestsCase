using testQA.baseElement;
using OpenQA.Selenium;
using testQA.Utils;


namespace testQA.PageObject
{
    public class ProgressBarForm : BaseForm
    {
        private Label progressBarLabel = new Label(By.XPath("//h1[text()='Progress Bar']"), "Progress bar label");
        private Button startStopButton = new Button(By.Id("startStopButton"), "Start&Stop button");
        private Button resetButton = new Button(By.Id("resetButton"), "Reset button");
        private TextField progressBarValue = new TextField(By.XPath("//div[@role=\"progressbar\"]"), "Progress bar value");

        public ProgressBarForm()
        {
            base.elements = progressBarLabel;
            base.name = progressBarLabel.name;
        }

        public void ClickStartStopButton() => startStopButton.Click();

        public void ClickResetButton() => resetButton.Click();
        public void StopProgressBar(int targetValue)
        {
            LogUtils.log.Info($"Stop progress bar when value \"{targetValue}\" ");
            int timeout = 50;
            while (true)
            {
                if (targetValue == int.Parse(progressBarValue.GetAttribute("aria-valuenow")))
                {
                    ClickStartStopButton();
                    break;
                }
                Thread.Sleep(100);
                timeout--;
                if (timeout == 0)
                {
                    LogUtils.log.Info($"cycle time has expired");
                    throw new Exception("Timeout");
                }
            }
        }

        public bool CheckValueProgressBar(int age)
        {
            LogUtils.log.Info($"Сomparison of values progress bar: Age and current value");
            int curentvalue = int.Parse(progressBarValue.GetAttribute("aria-valuenow"));
            if (curentvalue == age || curentvalue == age + 1 || curentvalue == age + 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
