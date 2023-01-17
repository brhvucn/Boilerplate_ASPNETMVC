using CRM.API.Utilities;
using CRM.BLL;
using CRM.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//add own Dependency injected services
builder.Services.AddDataAccessServices(); //this is our own implementation from the CRM.DAL, instead of writing everything here. Extension method.
builder.Services.AddBusinessLogicServices(); // The same as above, please refer to the crm.api.readme.md file for further explanation

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
