using TechTalk.SpecFlow;
using UserInterface.Utils;


namespace UserInterface.SpecFlow.Hooks
{
    [Binding]

    public class BeforeAfterScenario
    {
        [AfterScenario()]
        public static void BeforeScenario()
        {
            DriverWebUtils.CloseWebDriver();
        }
    }
}
