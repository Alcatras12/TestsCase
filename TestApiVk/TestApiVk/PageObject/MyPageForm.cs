using TestApiVk.Elements;
using OpenQA.Selenium;
using TestApiVk.Data.DynamicData;
using TestApiVk.Utils;


namespace TestApiVk.PageObject
{
    public class MyPageForm : BaseForm
    {
        private Label myPageLabel = new Label(By.XPath("//div[@class='ProfileInfo']"), "My page label");
        private Button showСommentButton = new Button(By.XPath("//span[@class='js-replies_next_label replies_next_label']"), 
            "Show comment button");

        public MyPageForm()
        {
            base.elements = myPageLabel;
            base.name = myPageLabel.name;
        }

        public void ClickLikePost(VkResponse responce)
        {
            var likePostButton = new Button(By.XPath($"//div[@class='like_wrap _like_wall" +
                $"{responce.Response.Owner_id}_{responce.Response.Post_id} ']" +
                $"//div[@class='PostBottomActionContainer PostButtonReactionsContainer']"), "Like Button");

            likePostButton.Click();
        }

        public void ClickShowComment()
        {
            if (showСommentButton.IsVisible())
            {
                showСommentButton.Click();
            }
        }

        public bool IsDisplayedComment(VkResponse responce, string massege)
        {
            var comment = new Label(By.XPath($"//div[@id='wpt{responce.Response.Owner_id}_{responce.Response.Post_id + 1}' " +
                $"and contains(., '{massege}')]"), 
                $"Label comment from user '{responce.Response.Owner_id}' in post id'{responce.Response.Post_id}'");

            return comment.IsVisible();
        }

        public bool IsDisplayedPost(VkResponse responce, ElementState visible = ElementState.Visible)
        {
            var post = new Label(By.Id($"post{responce.Response.Owner_id}_{responce.Response.Post_id}"),
                $"Label post from user '{responce.Response.Owner_id}' and post id'{responce.Response.Post_id}'");

            return post.IsVisible(visible);
        }

        public bool IsVisibleImage(VkResponse responce)
        {
            var imageLabel = new Label(By.XPath($"//div[@id='post{responce.Response.Owner_id}_{responce.Response.Post_id}']//img"), 
                $"Image label in post id'{responce.Response.Post_id}'");

            return imageLabel.IsVisible(ElementState.Visible);
        }

        public string GetTextPost(VkResponse responce)
        {
            var textPost = new TextField(By.XPath($"//div[@id='wpt{responce.Response.Owner_id}_{responce.Response.Post_id}']"), 
                $"Text field from post id'{responce.Response.Post_id}'");

            return textPost.GetText();
        }
    }
}