namespace ASP_Meeting_7.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string ModelName { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;

        public double Price { get; set; }
    }
}
