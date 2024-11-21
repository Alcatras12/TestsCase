using RestSharp;


namespace TestApiVk.Utils
{
    public static class ApiUtils
    {
        private static Dictionary<string, string> configApi = ConfigUtils.GetConfigData();

      
        public static RestResponse GetRequest(string url, Dictionary<string ,string> paramentrs)
        {
            LogUtils.log.Info("Sending a request");
            var request = new RestRequest(url, Method.Post);
            foreach (var param in paramentrs)
            {
                request.AddParameter(param.Key, param.Value);
            }
            var client = new RestClient($"{configApi["clientApi"]}");
            return client.Execute(request);
           
        }
    }
}
