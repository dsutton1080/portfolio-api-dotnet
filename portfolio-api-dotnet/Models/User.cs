namespace portfolio_api_dotnet.Models
{
    public class User
    {
        public required string Id { get; set; }
        public required string Email { get; set; }
        public string? FirstName { get; set; }
        public bool IsAdmin { get; set; }
        public string? LastName { get; set; }
        public required string Password { get; set; }
    }
}
