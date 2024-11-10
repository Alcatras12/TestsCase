using testQA.baseElement;
using testQA.Utils;
using OpenQA.Selenium;


namespace testQA.PageObject
{
    public class NestedFramesForm : BaseForm
    {
        private Label nestedFramesLabel = new Label(By.XPath("//h1[text()='Nested Frames']"), "NestedFrames");
        private TextField parentTextField = new TextField(By.XPath("//body[text()='Parent frame']"), "ParentTextField");
        private TextField childTextField = new TextField(By.XPath("//p[text()='Child Iframe']"), "ChildTextField");
        private Frame parentFrame = new Frame(By.XPath("//iframe[@src=\"/sampleiframe\"]"), "ParentFrame");
        private Frame childFrame = new Frame(By.XPath("//iframe[@srcdoc=\"<p>Child Iframe</p>\"]"), "ChildFrame");

        public NestedFramesForm()
        {
            base.elements = nestedFramesLabel;
            base.name = nestedFramesLabel.name;
        }

        public void GoToParentFrame() => FrameUtils.SwitchToFrame(parentFrame);

        public void GoToChildFrame() => FrameUtils.SwitchToFrame(childFrame);

        public string GetTextParentTextField() => parentTextField.GetText();

        public string GetTextChildTextField() => childTextField.GetText();
    }
}
