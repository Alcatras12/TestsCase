using OpenQA.Selenium;
using UserInterface.Utils;


namespace UserInterface.BaseElement
{
    public class Input : BaseElement
    {
        public Input(By locator, string name) : base(locator, name) { }

        public Input SendKey(string key)
        {
            LogUtils.log.Info($"Text input - {key} in {name}");
            GetElement().SendKeys(key);
            return this;
        }

        public Input ClearInputField()
        {
            GetElement().Clear();
            return this;
        }
    }
}
