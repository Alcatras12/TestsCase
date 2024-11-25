using DotNetEnv;


namespace TestApiVk.Utils
{
    public static class DataUtils
    {
        public static string username { get; set; }
        public static string password { get; set; }
        public static string apiKey { get; set; }


        static DataUtils()
        {
            Env.Load();
            apiKey = Environment.GetEnvironmentVariable("API_KEY");
            username = Environment.GetEnvironmentVariable("USERNAME");
            password = Environment.GetEnvironmentVariable("PASSWORD");
        }
    }
}
