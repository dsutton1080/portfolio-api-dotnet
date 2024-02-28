namespace portfolio_api_dotnet.Models
{
    public class Section
    {
        public required string Id { get; set; }
        public int? Order { get; set; }
        public required string Title { get; set; }
        public string? Header { get; set; }
        public string? SubHeader { get; set; }
        public List<Contents>? Contents { get; set; }
    }
}
