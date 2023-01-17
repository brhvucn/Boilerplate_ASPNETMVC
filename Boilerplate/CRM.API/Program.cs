using CRM.API.Utilities;
using CRM.BLL;
using CRM.DAL;
using CRM.Domain;
using Microsoft.Extensions.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//add own Dependency injected services
builder.Services.AddDataAccessServices(); //this is our own implementation from the CRM.DAL, instead of writing everything here. Extension method.
builder.Services.AddBusinessLogicServices(); // The same as above, please refer to the crm.api.readme.md file for further explanation
builder.Services.AddDomainServices();
//add the logging provider
string sequrl = builder.Configuration.GetValue<string>("Settings:SeqLogAddress");
var logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Application", "CRM.API") //enrich with the tag "service" and the name of this service
                .WriteTo.Seq(sequrl)
                .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//middleware to handle errors
app.UseMiddleware<ExceptionHandler>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
