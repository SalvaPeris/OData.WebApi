namespace OData.WebApi.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Size { get; set; }
        public List<Product>? Products { get; set; }
    }
}
