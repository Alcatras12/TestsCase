using testQA.baseElement;
using OpenQA.Selenium;


namespace testQA.PageObject
{
    public class SamplePageForm : BaseForm
    {
        private Label samplepageLabel = new Label(By.Id("sampleHeading"), "Sample page title");

        public SamplePageForm()
        {
            base.elements = samplepageLabel;
            base.name = samplepageLabel.name;
        }
    }
}
