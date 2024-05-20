namespace OData.WebApi.Entities
{
    public class Company
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Size { get; set; }
        public List<Product>? Products { get; set; }
    }
}
