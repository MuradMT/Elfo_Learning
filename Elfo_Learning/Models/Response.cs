using System.Net;

namespace Elfo_Learning.Models
{
    public class Response
    {
        public HttpStatusCode  StatusCode { get; set; }
        public object Data { get; set; }
        public bool Success { get; set; }
        public object Message { get; set; }
    }
}
