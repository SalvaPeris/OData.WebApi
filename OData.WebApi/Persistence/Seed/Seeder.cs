using OData.WebApi.Entities;

namespace OData.WebApi.Persistence.Seed
{
    public class Seeder
    {
        public static void AddCompaniesData(WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetService<ApplicationDbContext>();

            db.Companies.Add(
                new Company()
                {
                    Id = 1,
                    Name = "Company A",
                    Size = 25
                });

            db.Products.Add(
                new Product()
                {
                    Id = 10,
                    CompanyId = 1,
                    Name = "Product A",
                    Price = 10
                });

            db.Companies.Add(
                new Company()
                {
                    Id = 2,
                    Name = "Company B",
                    Size = 25
                });

            db.Products.Add(
                new Product()
                {
                    Id = 11,
                    CompanyId = 2,
                    Name = "Product B",
                    Price = 14
                });
            db.Products.Add(
                new Product()
                {
                    Id = 12,
                    CompanyId = 2,
                    Name = "Product C",
                    Price = 30
                });
            db.Products.Add(
                new Product()
                {
                    Id = 13,
                    CompanyId = 2,
                    Name = "Product D",
                    Price = 20
                });

            db.SaveChanges();
        }
    }
}
