namespace portfolio_api_dotnet.Models
{
    public class Contents
    {
        public int Id { get; set; }
        public required string Content { get; set; }
        public int? Order { get; set; }
        public required string Section_id { get; set; }
    }
}
