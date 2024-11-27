using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using testQA.model;


namespace testQA.Utils
{
    public static class ConfigUtils
    {
        private const string TEST_DATA_PATH = @"Data/testData.json";
        private const string TEST_CONFIG_PATH = @"Data/Config.json";
        private const string USER_DATA_PATH = @"Data/UserData.Json";

        public static Dictionary<string, string> GetTestData()
        {
            var text = File.ReadAllText(TEST_DATA_PATH);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(text);
        }

        public static Dictionary<string, string> GetConfig()
        {
            var config = File.ReadAllText(TEST_CONFIG_PATH);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(config);
        }

        public static List<User> GetUserData()
        {
            var data = File.ReadAllText(USER_DATA_PATH);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(data);
            return users;
        }
    }
}
