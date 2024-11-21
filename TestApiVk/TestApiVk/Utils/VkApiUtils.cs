using Newtonsoft.Json;
using RestSharp;
using TestApiVk.Data.DynamicData;


namespace TestApiVk.Utils
{
    public static class VkApiUtils
    {
        private static Dictionary<string, string> configApi = ConfigUtils.GetConfigData();

        public static VkResponse CreatePostWall(string massage)
        {
            LogUtils.log.Info("Creating a request to create a post on the wall");
            var parameters = new Dictionary<string, string>
            {
                {"owner_id", $"{configApi["owner_id"]}"},
                {"message", $"{massage}"},
                {"access_token", DataUtils.apiKey },
                {"v", $"{configApi["v"]}" }
            };
            var response = ApiUtils.GetRequest("/method/wall.post", parameters);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));
            Assert.IsNotNull(response.Content);
            return JsonConvert.DeserializeObject<VkResponse>(response.Content);
        }

        public static void EditPostWall(VkResponse responce, string massage, string attachments)
        {
            LogUtils.log.Info($"Creating a request to edit a post(id_{responce.Response.post_id}) on the wall");
            var parameters = new Dictionary<string, string>
            {
                { "post_id", $"{responce.Response.post_id}"},
                {"attachments", $"{attachments}"},
                {"owner_id", $"{configApi["owner_id"]}"},
                {"message", $"{massage}"},
                {"access_token", DataUtils.apiKey },
                {"v", $"{configApi["v"]}" }
            };
            var postimage = ApiUtils.GetRequest("/method/wall.edit", parameters);

            Assert.That((int)postimage.StatusCode, Is.EqualTo(200));
            Assert.IsNotNull(postimage.Content);
        }

        public static string UploudImageServer(string pathFile)
        {
            LogUtils.log.Info($"Loading a file from '{pathFile}'");
            var geturl = GetUrlUploud();
            var uploudimage = UploudImageInServer(geturl, pathFile);
            return SaveImageInServer(uploudimage);
        }

        private static VkResponse GetUrlUploud()
        {
            var parameters = new Dictionary<string, string>
            {
                {"access_token", DataUtils.apiKey},
                {"v", $"{configApi["v"]}"}
            };
            var getUrl = ApiUtils.GetRequest("/method/photos.getWallUploadServer", parameters);
            Assert.That((int)getUrl.StatusCode, Is.EqualTo(200));
            Assert.IsNotNull(getUrl.Content);
            return JsonConvert.DeserializeObject<VkResponse>(getUrl.Content);
        }

        private static VkResponse UploudImageInServer(VkResponse response, string pathFile)
        {
            var uploudserver = new RestClient($"{response.Response.upload_url}");
            var requestuploudserver = new RestRequest("", Method.Post);
            requestuploudserver.AddFile("photo", $"{pathFile}");
            var uploudimage = uploudserver.Execute(requestuploudserver);

            Assert.That((int)uploudimage.StatusCode, Is.EqualTo(200));
            Assert.IsNotNull(uploudimage.Content);
            return JsonConvert.DeserializeObject<VkResponse>(uploudimage.Content);
        }

        private static string SaveImageInServer(VkResponse response)
        {
            var parameters = new Dictionary<string, string>
            {
                {"photo", $"{response.photo}"},
                {"server", $"{response.server}"},
                {"hash", $"{response.hash}" },
                {"access_token", DataUtils.apiKey },
                {"v", $"{configApi["v"]}" }
            };
            var saveimage = ApiUtils.GetRequest("/method/photos.saveWallPhoto", parameters);

            Assert.That((int)saveimage.StatusCode, Is.EqualTo(200));
            Assert.IsNotNull(saveimage.Content);
            var idphoto = JsonConvert.DeserializeObject<VkResponseList>(saveimage.Content);
            var listresponce = idphoto.response[0];
            string attachments = $"photo{listresponce.owner_id}_{listresponce.id}";
            return attachments;
        }

        public static void CreatCommentWall(VkResponse response, string message)
        {
            LogUtils.log.Info($"Creating a request to creat comment in post(id_{response.Response.post_id}) on the wall");
            var parameters = new Dictionary<string, string>
            {
                {"owner_id", $"{response.Response.owner_id}"},
                {"message", $"{message}"},
                {"post_id", $"{response.Response.post_id}"},
                {"access_token", DataUtils.apiKey},
                {"v", $"{configApi["v"]}"}
            };
            var createcommentrequest = ApiUtils.GetRequest("/method/wall.createComment", parameters);

            Assert.That((int)createcommentrequest.StatusCode, Is.EqualTo(200));
            Assert.IsNotNull(createcommentrequest.Content);
        }

        public static bool IsLikeUser(VkResponse responce)
        {
            LogUtils.log.Info($"Checking if the user liked it in post(id_{responce.Response.post_id}) on the wall");
            var parameters = new Dictionary<string, string>
            {
                {"owner_id", $"{responce.Response.owner_id}"},
                {"type", $"{configApi["type"]}" },
                {"item_id", $"{responce.Response.post_id}" },
                {"access_token", DataUtils.apiKey },
                {"v", $"{configApi["v"]}" }
            };
            var getlist = ApiUtils.GetRequest("/method/likes.getList", parameters);

            Assert.That((int)getlist.StatusCode, Is.EqualTo(200));
            Assert.IsNotNull(getlist.Content);

            var lostuserlike = JsonConvert.DeserializeObject<VkResponse>(getlist.Content);
            var items = lostuserlike.Response.items;
            foreach (var item in items)
            {
                if (item == responce.Response.owner_id)
                {
                    return true;
                }
            }
            return false;
        }

        public static void DeletePostWall(VkResponse response)
        {
            LogUtils.log.Info($"Delete post(id_{response.Response.post_id}) on the wall");
            var parameters = new Dictionary<string, string>
            {
                  { "owner_id", response.Response.owner_id.ToString() },
                  { "post_id", response.Response.post_id.ToString() },
                  { "access_token", configApi["access_token"] },
                  { "v", configApi["v"] }
            };
            var deletePost = ApiUtils.GetRequest("/method/wall.delete", parameters);

            Assert.That((int)deletePost.StatusCode, Is.EqualTo(200));
            Assert.IsNotNull(deletePost.Content);
        }
    }
}
