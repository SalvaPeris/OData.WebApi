using OData.WebApi.Entities;

namespace OData.WebApi.Persistence.Seed
{
    public class Seeder
    {
        public static void AddCompaniesData(WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetService<ApplicationDbContext>();
            var guid1 = Guid.NewGuid();
            var guid2 = Guid.NewGuid();
            db.Companies.Add(
                new Company()
                {
                    Id = guid1,
                    Name = "Company A",
                    Size = 25
                });

            db.Products.Add(
                new Product()
                {
                    Id = Guid.NewGuid(),
                    CompanyId = guid1,
                    Name = "Product A",
                    Price = 10
                });

            db.Companies.Add(
                new Company()
                {
                    Id = guid2,
                    Name = "Company B",
                    Size = 25
                });

            db.Products.Add(
                new Product()
                {
                    Id = Guid.NewGuid(),
                    CompanyId = guid2,
                    Name = "Product B",
                    Price = 14
                });
            db.Products.Add(
                new Product()
                {
                    Id = Guid.NewGuid(),
                    CompanyId = guid2,
                    Name = "Product C",
                    Price = 30
                });
            db.Products.Add(
                new Product()
                {
                    Id = Guid.NewGuid(),
                    CompanyId = guid2,
                    Name = "Product D",
                    Price = 20
                });

            db.SaveChanges();
        }
    }
}
