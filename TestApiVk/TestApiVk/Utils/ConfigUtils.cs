using Newtonsoft.Json;


namespace TestApiVk.Utils
{
    public static class ConfigUtils
    {
        private const string USER_DATA_PATH = "../../../Data/UserData.json";
        private const string CONFIG_DATA = "../../../Data/ConfigApi.json";

        public static Dictionary<string, string> GetUserData()
        {
            var config = File.ReadAllText(USER_DATA_PATH);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(config);
        }

        public static Dictionary<string, string> GetConfigData()
        {
            var config = File.ReadAllText(CONFIG_DATA);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(config);
        }
    }
}