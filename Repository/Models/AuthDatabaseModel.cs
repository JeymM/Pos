namespace Pos.Auth.Api.Repository.Models
{
    public class AuthDatabaseModel
    {
        public long Id { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public required string Email {  get; set; }
        public string Identification {  get; set; }
        public int Age {  get; set; }
        public required string Password {  get; set; }
        public DateTime CreatedAt {  get; set; }
        public DateTime UpdatedAt {  get; set; }
    }
}
