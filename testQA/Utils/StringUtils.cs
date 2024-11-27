using testQA.baseElement;


namespace testQA.Utils
{
    public static class StringUtils
    {
        private static readonly Random random = new Random();

        public static string GenerateRandomString(int length = 10)
        {
            LogUtils.log.Info("Generate random string");
            {
                char[] result = new char[length];
                for (int i = 0; i < length; i++)
                {
                    result[i] = (char)random.Next('A', 'Z' + 1);
                }
                return new string(result);
            }
        }

        public static int GenerateRandamInt()
        {
            LogUtils.log.Info("Generate random int");
            return random.Next(0, 101);
        }
    }
}
