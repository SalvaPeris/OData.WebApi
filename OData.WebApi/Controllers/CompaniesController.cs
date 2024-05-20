using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using OData.WebApi.Entities;
using OData.WebApi.Persistence.Filters;
using OData.WebApi.Persistence.Repositories.Interfaces;

namespace OData.WebApi.Controllers
{
    [Route("odata/[controller]")]
    [ApiController]
    public class CompaniesController : ODataController
    {
        private readonly ICompanyRepository _companyRepository;

        public CompaniesController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpGet]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All | AllowedQueryOptions.Count)]
        public IQueryable<Company> Get()
        {
            return _companyRepository.GetAll();
        }

        [HttpGet("{key}")]
        [EnableQuery]
        public SingleResult<Company> Get([FromODataUri] int key)
        {
            return SingleResult.Create(_companyRepository.GetById(key));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Company company)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _companyRepository.Create(company);
            return Created("companies", company);
        }

        [HttpPut("{key}")]
        public IActionResult Put([FromODataUri] int key, [FromBody] Company company)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (key != company.Id)
                return BadRequest();

            _companyRepository.Update(company);
            return NoContent();
        }

        [HttpDelete("{key}")]
        public IActionResult Delete([FromODataUri] int key)
        {
            var company = _companyRepository.GetById(key);
            if (company is null)
                return BadRequest();
            
            _companyRepository.Delete(company.First());
            return NoContent();
        }
    }
}
