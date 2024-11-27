using OpenQA.Selenium;
using TestApiVk.Utils;


namespace TestApiVk.Elements
{
    public class Input : BaseElement
    {
        public Input(By locator, string name) : base(locator, name) { }

        public Input SendKey(string key)
        {
            LogUtils.log.Info($"Input key in {name}");
            GetElement().SendKeys(key);
            return this;
        }

        public Input ClearInputField()
        {
            LogUtils.log.Info($"Clear in {name}");
            GetElement().Clear();
            return this;
        }
    }
}
