namespace OData.WebApi.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
    }
}
