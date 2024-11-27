using TestApiVk.PageObject;
using TestApiVk.Utils;


namespace TestApiVk.Test
{
    public class TestVK : BaseTest
    {
        private AutorizationPageForm autorizationPageForm = new AutorizationPageForm();
        private HomePageForm homePageForm = new HomePageForm();
        private MyPageForm myPageForm = new MyPageForm();
        
        [Test]
        public void ApiTestVK()
        {
            mainPageForm.EntryLogin(Credentials.username)
                        .ClickSaveLoginCheckBox()
                        .ClickSignInButton();

            Assert.IsTrue(autorizationPageForm.IsPageOpened(), "Autorization page is not opened");
            autorizationPageForm.EntryPassword(Credentials.password)
                                .ClickSignIn();

            Assert.IsTrue(homePageForm.IsPageOpened(), "Home page is not opened");
            homePageForm.ClickMyPage();

            Assert.IsTrue(myPageForm.IsPageOpened(), "My page is not opened");

            string postDescription = StringUtils.GenerateRandomString();
            var newPost = VkApiUtils.CreatePostWall(postDescription);
            Assert.IsTrue(myPageForm.IsDisplayedPost(newPost), "Wall post is not displayed");
            Assert.That(myPageForm.GetTextPost(newPost), Is.EqualTo(postDescription), "The displayed message and the sent message do not match");

            string editPostTitle = StringUtils.GenerateRandomString();
            VkApiUtils.EditPostWall(newPost, editPostTitle, VkApiUtils.UploadImageToServer(testData["photo"]));
            Assert.IsTrue(myPageForm.IsVisibleImage(newPost), "The image didn't load");
            Assert.That(myPageForm.GetTextPost(newPost), Is.EqualTo(editPostTitle), "The displayed message and the sent message do not match");

            string comment = StringUtils.GenerateRandomString();
            VkApiUtils.CreatCommentWall(newPost, comment);
            myPageForm.ClickShowComment();
            Assert.IsTrue(myPageForm.IsDisplayedComment(newPost, comment), "Comment is not displayed");

            myPageForm.ClickLikePost(newPost);
            Assert.IsTrue(VkApiUtils.IsLikeUser(newPost), "The user did not like ");

            VkApiUtils.DeletePostWall(newPost);
            DriverWebUtils.GetWebDriver().Navigate().Refresh();
            Assert.IsTrue(myPageForm.IsDisplayedPost(newPost, ElementState.NotVisible), "Wall post is not deleted");
        }
    }
}