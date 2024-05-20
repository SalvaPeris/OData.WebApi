using Microsoft.EntityFrameworkCore;
using OData.WebApi.Entities;
using OData.WebApi.Persistence.Repositories.Interfaces;

namespace OData.WebApi.Persistence.Repositories.Concrete
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;
        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Company> GetAll()
        {
            return _context.Companies
                .Include(a => a.Products)
                .AsQueryable();
        }
        public IQueryable<Company> GetById(int id)
        {
            return _context.Companies
                .Include(a => a.Products)
                .AsQueryable()
                .Where(c => c.Id == id);
        }
        public void Create(Company company)
        {
            _context.Companies
                .Add(company);
            _context.SaveChanges();
        }
        public void Update(Company company)
        {
            _context.Companies
                .Update(company);
            _context.SaveChanges();
        }
        public void Delete(Company company)
        {
            _context.Companies
                .Remove(company);
            _context.SaveChanges();
        }
    }
}
