namespace Pos.Auth.Api.Models.ViewModels
{
    public class AuthViewModel
    {
        public required string AccessToken {  get; set; }
        public required string ExpireAt {  get; set; }
    }
}
