using System.Net;
using System.Text.Json.Serialization;

namespace MongoDbNetcoreApp.Helpers
{

    public class GenericResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        [JsonIgnore]
        public HttpStatusCode StatusCode { get; set; }
    }

}
