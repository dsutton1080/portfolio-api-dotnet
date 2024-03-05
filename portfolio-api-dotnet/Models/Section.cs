namespace portfolio_api_dotnet.Models
{
    public class Section
    {
        public int Id { get; set; }
        public int? Order { get; set; }
        public required string Title { get; set; }
        public string? Header { get; set; }
        public string? SubHeader { get; set; }
        public ICollection<ContentClass>? Contents { get; set; }
    }

    public class ContentClass
    {
        public int Id { get; set; }
        public required string Content { get; set; }
        public int? Order { get; set; }
        public int SectionId { get; set; }
    }
}
