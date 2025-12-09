namespace PostalSearchApi.Models
{
    public class Settlement
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string County { get; set; } = string.Empty;
    }
}
