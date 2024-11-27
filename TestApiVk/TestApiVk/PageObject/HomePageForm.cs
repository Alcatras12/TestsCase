using TestApiVk.Elements;
using OpenQA.Selenium;


namespace TestApiVk.PageObject
{
    public class HomePageForm:BaseForm
    {
        private Label vkHomePageLabel = new Label(By.XPath("//a[@class='TopHomeLink ']"), "VKonakte label");
        private Button myPage = new Button(By.Id("l_pr"), "My page button");

        public HomePageForm()
        {
            base.elements = vkHomePageLabel;
            base.name = vkHomePageLabel.name;
        }

        public HomePageForm ClickMyPage()
        {
            myPage.Click();
            return this;
        }
    }
}
