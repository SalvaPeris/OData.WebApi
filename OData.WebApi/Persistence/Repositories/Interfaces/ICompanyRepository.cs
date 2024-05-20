using OData.WebApi.Entities;

namespace OData.WebApi.Persistence.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        public IQueryable<Company> GetAll();
        public IQueryable<Company> GetById(int id);
        public void Create(Company company);
        public void Update(Company company);
        public void Delete(Company company);
    }
}
