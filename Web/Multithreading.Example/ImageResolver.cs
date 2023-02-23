using RestSharp;

namespace Multithreading.Example
{
    public class ImageResolver
    {
        private const string URL = "https://random.imagecdn.app/250/250";
        private readonly RestClient client;

        public ImageResolver()
        {
            this.client = new RestClient();
        }

        /// <summary>
        /// Gets image as byte array.
        /// </summary>
        /// <returns></returns>
        public async Task<byte[]> GetImageAsync()
        {
            var request = new RestRequest(URL, Method.Get);
            request.AddHeader("Accept", "image/webp,image/apng,image/*,*/*;q=0.8");
            var response = await client.ExecuteAsync(request);
            return response.RawBytes;
        }

    }
}
