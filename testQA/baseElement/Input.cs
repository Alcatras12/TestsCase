using OpenQA.Selenium;
using testQA.Utils;

namespace testQA.baseElement
{
    public class Input:BaseElement
    {
        public Input(By locator, string name) : base(locator, name) { }

        public void SendKey(string key)
        {
           LogUtils.log.Info($"Text input - {key} in {name}");
           GetElement().SendKeys(key);
        }
    }
}
