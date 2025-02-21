using System.Text.Json.Serialization;

namespace Pos.Auth.Api.Models
{
    public class RegisterCommand
    {
        [JsonPropertyName("email")]
        public required string Email { get; set; }
        [JsonPropertyName("password")]
        public required string Password {  get; set; }
        [JsonPropertyName("first_name")]
        public required string FirstName {  get; set; }
        [JsonPropertyName("last_name")]
        public required string LastName {  get; set; }
        [JsonPropertyName("identification")]
        public required string Identification {  get; set; }
        [JsonPropertyName("age")]
        public required int  Age {  get; set; }
    }
}
