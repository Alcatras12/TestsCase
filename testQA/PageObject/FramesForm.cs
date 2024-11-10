using testQA.baseElement;
using testQA.Utils;
using OpenQA.Selenium;


namespace testQA.PageObject
{
    public class FramesForm : BaseForm
    {
        private Label framesFormLabel = new Label(By.XPath("//h1[text()='Frames' and @class='text-center']"), "Frames label");
        private Frame bigFrame = new Frame(By.XPath("//iframe[@id=\"frame1\"]"), "Big Frame");
        private Frame smallFrame = new Frame(By.XPath("//iframe[@id=\"frame2\"]"), "Small Frame");
        private TextField BigframeTextField = new TextField(By.XPath("//*[@id=\"sampleHeading\"]"), "Text Big Frame");
        private TextField SmallFrameTextField = new TextField(By.XPath("//*[@id=\"sampleHeading\"]"), "Text Small Frame");

        public FramesForm()
        {
            base.elements = framesFormLabel;
            base.name = framesFormLabel.name;
        }

        public void GoToBigFarme() => FrameUtils.SwitchToFrame(bigFrame);

        public void GoToSmallFrame() => FrameUtils.SwitchToFrame(smallFrame);

        public string GetTextBigFrameTextField() => BigframeTextField.GetText();

        public string GetTextSmallFrameTextField() => SmallFrameTextField.GetText();
    }
}
