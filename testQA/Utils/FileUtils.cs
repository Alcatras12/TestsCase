namespace testQA.Utils
{
    public static class FileUtils
    {
        public static bool IsVisibleFile(string filePath, int timeout = 50)
        {
            LogUtils.log.Info($"Searh file in path \"{filePath}\"");
            while (timeout != 0)
            {
                if (File.Exists(filePath))
                {
                    return true;
                }
                Thread.Sleep(100);
                timeout--;
            }
            return false;
        }
    }
}
