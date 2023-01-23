using Machine.Data.api.Extension;
using Machine.Data.api.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle



builder.Services.AddScoped<IMachineDataFromFile ,MachineDataFromFile>();
builder.Services.AddScoped<IMachineDataFromDatabase ,MachineDataFromDatabase>();
builder.Services.AddEndpointsApiExplorer();
builder.AddFilters();
builder.SwaggerXmlComments();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
