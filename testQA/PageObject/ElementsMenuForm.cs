using testQA.baseElement;
using OpenQA.Selenium;

namespace testQA.PageObject
{
    public class ElementsMenuForm : BaseForm
    {
        private Label elemenstMenuLabel = new Label(By.XPath("//div[@class = \"element-list collapse show\"]"), "Elemenst Menu label");
        private Button webTablesButton = new Button(By.XPath("//span[text()='Web Tables']"), " Web Tables button");
        private Button linksButton = new Button(By.XPath("//span[text()='Links']"), "Links button");
        private Button uploadingAndDownloadingButton = new Button(By.XPath("//span[text()='Upload and Download']"), "Uploading And Downloading button");

        public ElementsMenuForm()
        {
            base.elements = elemenstMenuLabel;
            base.name = elemenstMenuLabel.name;
        }

        public void ClickWebTables() => webTablesButton.Click();

        public void ClickLinks() => linksButton.Click();

        public void ClickUploadingAndDownloading() => uploadingAndDownloadingButton.Click();
    }
}