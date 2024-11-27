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
                {"access_token", Credentials.apiKey },
                {"v", $"{configApi["v"]}" }
            };
            var response = ApiUtils.GetRequest("/method/wall.post", parameters);

            Assert.That((int)response.StatusCode, Is.EqualTo((int)HttpStatusCode.OK), 
                $"Status code response {(int)response.StatusCode}");

            Assert.IsNotNull(response.Content, "Response of request is empty");
            return JsonConvert.DeserializeObject<VkResponse>(response.Content);
        }

        public static void EditPostWall(VkResponse responce, string massage, string attachments)
        {
            LogUtils.log.Info($"Creating a request to edit a post(id_{responce.Response.Post_id}) on the wall");
            var parameters = new Dictionary<string, string>
            {
                { "post_id", $"{responce.Response.Post_id}"},
                {"attachments", $"{attachments}"},
                {"owner_id", $"{configApi["owner_id"]}"},
                {"message", $"{massage}"},
                {"access_token", Credentials.apiKey },
                {"v", $"{configApi["v"]}" }
            };
            var postImageResponse = ApiUtils.GetRequest("/method/wall.edit", parameters);

            Assert.That((int)postImageResponse.StatusCode, Is.EqualTo((int)HttpStatusCode.OK), 
                $"Status code response {(int)postImageResponse.StatusCode}");

            Assert.IsNotNull(postImageResponse.Content, "Response of request is empty");
        }

        public static string UploadImageToServer(string pathFile)
        {
            LogUtils.log.Info($"Loading a file from '{pathFile}'");
            var serverUploadResponse = GetPhotoUploadUrlResponse();
            var uploadImageResponse = UploadImageInServer(serverUploadResponse, pathFile);
            return SaveImageInServer(uploadImageResponse);
        }

        private static VkResponse GetPhotoUploadUrlResponse()
        {
            var parameters = new Dictionary<string, string>
            {
                {"access_token", Credentials.apiKey},
                {"v", $"{configApi["v"]}"}
            };
            var getUrl = ApiUtils.GetRequest("/method/photos.getWallUploadServer", parameters);

            Assert.That((int)getUrl.StatusCode, Is.EqualTo((int)HttpStatusCode.OK),
                $"Status code response {(int)getUrl.StatusCode}");

            Assert.IsNotNull(getUrl.Content, "Response of request is empty");

            return JsonConvert.DeserializeObject<VkResponse>(getUrl.Content);
        }

        private static VkResponse UploadImageInServer(VkResponse response, string pathFile)
        {
            var uploudserver = new RestClient($"{response.Response.Upload_url}");
            var requestuploudserver = new RestRequest("", Method.Post);
            requestuploudserver.AddFile("photo", pathFile);
            var uploadImage = uploudserver.Execute(requestuploudserver);

            Assert.That((int)uploadImage.StatusCode, Is.EqualTo((int)HttpStatusCode.OK), 
                $"Status code response {(int)uploadImage.StatusCode}");

            Assert.IsNotNull(uploadImage.Content, "Response of request is empty");

            return JsonConvert.DeserializeObject<VkResponse>(uploadImage.Content);
        }

        private static string SaveImageInServer(VkResponse response)
        {
            var parameters = new Dictionary<string, string>
            {
                {"photo", $"{response.Photo}"},
                {"server", $"{response.Server}"},
                {"hash", $"{response.Hash}" },
                {"access_token", Credentials.apiKey },
                {"v", $"{configApi["v"]}" }
            };
            var saveImageResponse = ApiUtils.GetRequest("/method/photos.saveWallPhoto", parameters);

            Assert.That((int)saveImageResponse.StatusCode, Is.EqualTo((int)HttpStatusCode.OK),
                $"Status code response {(int)saveImageResponse.StatusCode}");

            Assert.IsNotNull(saveImageResponse.Content, "Response of request is empty");

            var responseList = JsonConvert.DeserializeObject<VkResponseList>(saveImageResponse.Content);
            var itemResponse = responseList.Response[0];
            string attachments = $"photo{itemResponse.Owner_id}_{itemResponse.Id}";
            return attachments;
        }

        public static void CreatCommentWall(VkResponse response, string message)
        {
            LogUtils.log.Info($"Creating a request to creat comment in post(id_{response.Response.Post_id}) on the wall");
            var parameters = new Dictionary<string, string>
            {
                {"owner_id", $"{response.Response.Owner_id}"},
                {"message", $"{message}"},
                {"post_id", $"{response.Response.Post_id}"},
                {"access_token", Credentials.apiKey},
                {"v", $"{configApi["v"]}"}
            };
            var createCommentResponse = ApiUtils.GetRequest("/method/wall.createComment", parameters);

            Assert.That((int)createCommentResponse.StatusCode, Is.EqualTo((int)HttpStatusCode.OK),
                $"Status code response {(int)createCommentResponse.StatusCode}");

            Assert.IsNotNull(createCommentResponse.Content, "Response of request is empty");
        }

        public static bool IsLikeUser(VkResponse responce)
        {
            LogUtils.log.Info($"Checking if the user liked it in post(id_{responce.Response.Post_id}) on the wall");
            var parameters = new Dictionary<string, string>
            {
                {"owner_id", $"{responce.Response.Owner_id}"},
                {"type", $"{configApi["type"]}" },
                {"item_id", $"{responce.Response.Post_id}" },
                {"access_token", Credentials.apiKey },
                {"v", $"{configApi["v"]}" }
            };
            var likesListResponse = ApiUtils.GetRequest("/method/likes.getList", parameters);

            Assert.That((int)likesListResponse.StatusCode, Is.EqualTo((int)HttpStatusCode.OK),
                $"Status code response {(int)likesListResponse.StatusCode}");

            Assert.IsNotNull(likesListResponse.Content, "Response of request is empty");

            var itemResponse = JsonConvert.DeserializeObject<VkResponse>(likesListResponse.Content);
            var items = itemResponse.Response.Items;
            foreach (var item in items)
            {
                if (item == responce.Response.Owner_id)
                {
                    return true;
                }
            }
            return false;
        }

        public static void DeletePostWall(VkResponse response)
        {
            LogUtils.log.Info($"Delete post(id_{response.Response.Post_id}) on the wall");
            var parameters = new Dictionary<string, string>
            {
                  { "owner_id", response.Response.Owner_id.ToString()},
                  { "post_id", response.Response.Post_id.ToString()},
                  { "access_token", Credentials.apiKey},
                  { "v", configApi["v"]}
            };
            var deletePostResponse = ApiUtils.GetRequest("/method/wall.delete", parameters);

            Assert.That((int)deletePostResponse.StatusCode, Is.EqualTo((int)HttpStatusCode.OK), 
                $"Status code response {(int)deletePostResponse.StatusCode}");

            Assert.IsNotNull(deletePostResponse.Content, "Response of request is empty");
        }
    }
}