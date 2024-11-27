using OpenQA.Selenium;
using testQA.baseElement;


namespace testQA.PageObject
{
    public class UploadingForm : BaseForm
    {
        private Label uploadAndDownloadLabel = new Label(By.XPath("//h1[text()='Upload and Download']"), "Upload And Download label");
        private Button downloadButton = new Button(By.Id("downloadButton"), "Download button");
        private Input uploadButton = new Input(By.Id("uploadFile"), "Upload Input");
        private TextField uploadedFilePath = new TextField(By.Id("uploadedFilePath"), "Uploaded file path text field");

        public UploadingForm()
        {
            base.elements = uploadAndDownloadLabel;
            base.name = uploadAndDownloadLabel.name;
        }

        public void ClickDownload() => downloadButton.Click();

        public void UploadFile(string path) => uploadButton.SendKey(path);

        public bool IsUploadFile() => uploadedFilePath.IsVisible();
    }
}
