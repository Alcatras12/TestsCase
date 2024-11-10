using testQA.PageObject;
using testQA.Utils;


namespace testQA.Test
{
    public class UploadingTest : BaseTest
    {
        private ElementsMenuForm elementsMenuForm = new ElementsMenuForm();
        private UploadingForm uploadingForm = new UploadingForm();

        [Test]

        public void UploadingAndDownloading()
        {
            LogUtils.LogNewTest("UploadingTest");

            Assert.IsTrue(mainPage.IsPageOpened(), "The main page is not open");
            mainPage.ClickElementsButton();
            Assert.IsTrue(elementsMenuForm.IsPageOpened(), "Elements menu is not open");
            elementsMenuForm.ClickUploadingAndDownloading();
            Assert.IsTrue(uploadingForm.IsPageOpened(), "Upload and Download form is not open");

            uploadingForm.ClickDownload();
            string filePath = Path.Combine(config["DownloadPath"], config["FileName"]);
            Assert.IsTrue(FileUtils.IsVisibleFile(filePath), "File is not dowland or road for path is not correct");
            uploadingForm.UploadFile(filePath);
            Assert.IsTrue(uploadingForm.IsUploadFile(), "File is not upload");
        }

        [TearDown]
        public void TearDown1()
        {
            string filePath = Path.Combine(config["DownloadPath"], config["FileName"]);
            File.Delete(filePath);
            Assert.IsFalse(File.Exists(filePath), "File is not delete");
        }
    }
}
