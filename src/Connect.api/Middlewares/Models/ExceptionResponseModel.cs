using System.Net;

namespace Connect.api.Middlewares.Models
{
    public struct ExceptionResponseModel
    {
        public string LogMessage { get; set; }
        public string ReponseMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
