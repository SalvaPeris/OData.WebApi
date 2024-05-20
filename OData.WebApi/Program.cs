using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi.Models;
using OData.WebApi.Entities;
using OData.WebApi.Persistence;
using OData.WebApi.Persistence.Filters;
using OData.WebApi.Persistence.Repositories.Concrete;
using OData.WebApi.Persistence.Repositories.Interfaces;
using OData.WebApi.Persistence.Seed;

static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new();
    builder.EntitySet<Company>("Companies");
    return builder.GetEdmModel();
}

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("CompaniesDB"));
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "OData API", Version = "v1" });
    c.DocInclusionPredicate((_, api) => !string.IsNullOrWhiteSpace(api.GroupName));
    c.TagActionsBy(api => new[] { api.GroupName });
    c.OperationFilter<ODataOperationFilter>();
});

builder.Services.AddControllers()
        .AddOData(options => options
        .AddRouteComponents("odata", GetEdmModel())
        .Select()
        .Filter()
        .OrderBy()
        .SetMaxTop(20)
        .Count()
        .Expand()
    ); ;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

Seeder.AddCompaniesData(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
