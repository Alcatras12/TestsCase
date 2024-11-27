using testQA.baseElement;


namespace testQA.Utils
{
    public static class FrameUtils
    {
        public static void SwitchToFrame(Frame frame)
        {
            LogUtils.log.Info($"Switch to frame \"{frame.name}\"");
            var frameElement = frame.GetElement();
            DriverWebUtils.GetWebDriver().SwitchTo().Frame(frameElement);
        }

        public static void SwitchDefaultFrame()
        {
            LogUtils.log.Info($"Switch to default frame");
            DriverWebUtils.GetWebDriver().SwitchTo().DefaultContent();
        }
    }
}
