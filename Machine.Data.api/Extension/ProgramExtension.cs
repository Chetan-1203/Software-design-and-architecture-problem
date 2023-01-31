using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Machine.Data.api.Services;
using Microsoft.OpenApi.Models;

using Microsoft.AspNetCore.Authentication;
using Machine.Data.api.Entity;

namespace Machine.Data.api.Extension;

public static class ProgramExtension
{
    public static void AddFilters(this WebApplicationBuilder webBuilder)
    {
        webBuilder.Services.AddMvc(setupAction =>
        {
            setupAction.Filters.Add(new ProducesResponseTypeAttribute(typeof(Asset), StatusCodes.Status400BadRequest));
            setupAction.Filters.Add(new ProducesResponseTypeAttribute(typeof(Asset),StatusCodes.Status406NotAcceptable));
            setupAction.Filters.Add(new ProducesResponseTypeAttribute(typeof(Asset),StatusCodes.Status500InternalServerError));
            setupAction.Filters.Add(new ProducesResponseTypeAttribute(typeof(Asset),StatusCodes.Status200OK));
            setupAction.Filters.Add(new ProducesDefaultResponseTypeAttribute(typeof(Asset)));
            
         

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

    public static void LifeCycleMethods(this WebApplicationBuilder webBuilder)
    {   
   
        webBuilder.Services.AddScoped<IMachineDataFromDatabase, MachineDataFromDatabase>();
     

    }

   
}

