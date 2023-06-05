namespace Paperboy.Api.Data.Models
{
    public class Token
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Symbol { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Chain { get; set; } = null!;
        public string Price { get; set; } = null!;
        public string Price_USD { get; set; } = null!;

    }
}
