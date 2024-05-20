using Microsoft.AspNetCore.Mvc;
using OData.WebApi.Entities;
using OData.WebApi.Persistence.Repositories.Interfaces;
using System.Web.Http.OData;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace OData.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;

        public CompaniesController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [EnableQuery(PageSize = 3)]
        [HttpGet]
        public IQueryable<Company> Get()
        {
            return _companyRepository.GetAll();
        }

        [EnableQuery]
        [HttpGet("{id}")]
        public System.Web.Http.SingleResult<Company> Get([FromODataUri] Guid key)
        {
            return System.Web.Http.SingleResult.Create(_companyRepository.GetById(key));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Company company)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _companyRepository.Create(company);
            return Created("companies", company);
        }

        [HttpPut]
        public IActionResult Put([FromODataUri] Guid key, [FromBody] Company company)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (key != company.Id)
                return BadRequest();

            _companyRepository.Update(company);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete([FromODataUri] Guid key)
        {
            var company = _companyRepository.GetById(key);
            if (company is null)
                return BadRequest();
            
            _companyRepository.Delete(company.First());
            return NoContent();
        }
    }
}
