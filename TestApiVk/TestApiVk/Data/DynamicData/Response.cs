using TestApiVk.Utils;


namespace TestApiVk.Data.DynamicData
{
    public class Response
    {
        public int Post_id { get; set; }
        public string Upload_url { get; set; }
        public int Id { get; set; }
        public int Owner_id { get; set; }
        public int[] Items { get; set; }

        public Response()
        {
            Dictionary<string, string> testData = ConfigUtils.GetUserData();
            Owner_id = int.Parse(testData["owner_id"]);
        }
    }
}
