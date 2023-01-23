using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Machine.Data.api.Extension
{
    public static class WebBuilderExtension
    {
        public static void AddFilters(this WebApplicationBuilder webBuilder)
        {
            var builder = webBuilder.Services.AddMvc(setupAction =>
            {

                setupAction.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
                setupAction.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));
                setupAction.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));
                setupAction.Filters.Add(new ProducesDefaultResponseTypeAttribute());
                setupAction.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status401Unauthorized));

                setupAction.Filters.Add(new AuthorizeFilter());
            });

        }
    }
}
