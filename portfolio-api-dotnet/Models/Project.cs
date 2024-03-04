namespace portfolio_api_dotnet.Models
{
    public class ProjectClass
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Link { get; set; }
        public required string Label { get; set; }
        public int? Order { get; set; }
        public string? Logo { get; set; }
    }
}
