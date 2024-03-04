namespace portfolio_api_dotnet.Models
{
    public class Experience
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required string Date { get; set; }
    }
}
