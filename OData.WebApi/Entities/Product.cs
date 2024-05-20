namespace OData.WebApi.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
    }
}
