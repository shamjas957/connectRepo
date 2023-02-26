using System.Text.Json;

namespace Connect.api.Middlewares.Models
{
    public struct ErrorDetails
    {
        public string Message { get; set; }

        public string Serialize() => JsonSerializer.Serialize(this);
    }
}
