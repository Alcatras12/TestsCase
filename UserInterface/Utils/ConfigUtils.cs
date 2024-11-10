using Newtonsoft.Json;


namespace UserInterface.Utils
{
    public static class ConfigUtils
    {
        private const string TEST_CONFIG_PATH = @"C:\Users\sahon\OneDrive\Рабочий стол\hm1\UserInterface\Data\Config.json";

        public static Dictionary<string, string> GetConfig()
        {
            var config = File.ReadAllText(TEST_CONFIG_PATH);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(config);
        }
    }
}
