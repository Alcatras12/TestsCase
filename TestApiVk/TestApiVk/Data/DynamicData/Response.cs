using TestApiVk.Utils;


namespace TestApiVk.Data.DynamicData
{
    public class Response
    {
        public int post_id { get; set; }
        public string upload_url { get; set; }
        public int id { get; set; }
        public int owner_id { get; set; }
        public int[] items { get; set; }


        public Response()
        {
            Dictionary<string, string> testData = ConfigUtils.GetUserData();
            owner_id = int.Parse(testData["owner_id"]);
        }
    }
}
