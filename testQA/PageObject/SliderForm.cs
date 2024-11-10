using OpenQA.Selenium;
using testQA.baseElement;
using testQA.Utils;


namespace testQA.PageObject
{
    public class SliderForm : BaseForm
    {
        private Label sliderLabel = new Label(By.XPath("//h1[text()='Slider']"), "Slider Label");
        private Slider sliderinput = new Slider(By.XPath("// input[@class=\"range-slider range-slider--primary\"]"), "Slider input");
        private TextField valueSlider = new TextField(By.Id("sliderValue"), "Value slidet");

        public SliderForm()
        {
            base.elements = sliderLabel;
            base.name = sliderLabel.name;
        }

        public int GetValueSlider()
        {
            return int.Parse(valueSlider.GetAttribute("value"));
        }

        public void MoveSliderInput(int value)
        {
            LogUtils.log.Info($"Move slider on {value}");
            IWebElement slider = sliderinput.GetElement();
            int valuefact = GetValueSlider();
            if (valuefact > value)
            {
                int stepmove = valuefact - value;
                for (int i = 0; i < stepmove; i++)
                {
                    slider.SendKeys(Keys.ArrowLeft);
                }
            }
            else if (valuefact < value)
            {
                int stepmove = value - valuefact;
                for (int i = 0; i < stepmove; i++)
                {
                    slider.SendKeys(Keys.ArrowRight);
                }
            }
            else { };
        }
    }
}
