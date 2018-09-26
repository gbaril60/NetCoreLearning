using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StandardLib.Extensions
{
    public static class HttpExtensions
    {
        public static async Task<object> ProcessHttpMessageBody(this HttpRequestMessage message)
        {
            var bodyString = await message.Content.ReadAsStringAsync();
            var body = JsonConvert.DeserializeObject<HttpBody>(bodyString);
            object json = null;

            if (body.Body == null)
            {
                json = JsonConvert.DeserializeObject(bodyString);    
            }
            else
            {
                json = JsonConvert.DeserializeObject(body.Body);
            }

            return json;
        }
        public static async Task<T> ProcessHttpMessageBody<T>(this HttpRequestMessage message)
        {
            var bodyString = await message.Content.ReadAsStringAsync();
            var body = JsonConvert.DeserializeObject<HttpBody>(bodyString);
            T json = default(T);

            if (body.Body == null)
            {
                json = JsonConvert.DeserializeObject<T>(bodyString);
            }
            else
            {
                json = JsonConvert.DeserializeObject<T>(body.Body);
            }
            return json;
        }
    }
    public class HttpBody
    {
        [JsonProperty("body")]
        public string Body { get; set; }
    }
}
