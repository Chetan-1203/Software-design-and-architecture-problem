using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Machine.Data.api.Services;

namespace Machine.Data.api.Extension;

public static class ProgramExtension
{
    public static void AddFilters(this WebApplicationBuilder webBuilder)
    {
        webBuilder.Services.AddMvc(setupAction =>
        {
            setupAction.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
            setupAction.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));
            setupAction.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));
            setupAction.Filters.Add(new ProducesDefaultResponseTypeAttribute());
            setupAction.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status401Unauthorized));

            
        });
    }

    public static void SwaggerXmlComments(this WebApplicationBuilder webBuilder)
    {
        webBuilder.Services.AddSwaggerGen(setupAction =>
        {
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            setupAction.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });
    }

    public static void AddScoped(this WebApplicationBuilder webBuilder)
    {
        webBuilder.Services.AddScoped<IMachineDataFromFile, MachineDataFromFile>();
        webBuilder.Services.AddScoped<IMachineDataFromDatabase, MachineDataFromDatabase>();
    }
}

