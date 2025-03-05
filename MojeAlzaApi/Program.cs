using Asp.Versioning.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

using Api.Configuration;
using Api.Middleware;
using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApiVersioning(ApiConfiguration.ApiVersioningSetup).AddApiExplorer(ApiConfiguration.ApiExplorerSetup);

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IProductsService, ProductsService>();

#if TEST
    builder.Services.AddScoped<IProductsRepository, MockProductsRepository>();
#else
    builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.MigrationsAssembly("Infrastructure")));

    builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
#endif

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwagerConfigureOptions>();

builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

IApiVersionDescriptionProvider versionDescProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(SwaggerUISetup);

// Use the custom exception handling middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void SwaggerUISetup(SwaggerUIOptions options)
{
    foreach (ApiVersionDescription versionDescription in versionDescProvider.ApiVersionDescriptions)
    {
        options.SwaggerEndpoint($"/swagger/{versionDescription.GroupName}/swagger.json", string.Concat("Moje Alza API", " ", versionDescription.GroupName));
    }
}