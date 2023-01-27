using CRM.BLL;
using CRM.BLL.Contracts;
using CRM.DAL;
using Microsoft.Extensions.Configuration;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

string sequrl = builder.Configuration.GetValue<string>("Settings:SeqLogAddress");
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .Enrich.FromLogContext()
    .Enrich.WithProperty("Application", "UCN.CRM") //enrich with the tag "service" and the name of this service
    .WriteTo.Seq(sequrl)
    .CreateLogger();
//add the logger
builder.Logging.ClearProviders();
builder.Logging.AddSerilog();
//add the automapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
// Add services to the container.
builder.Services.AddControllersWithViews();
//add the bll di mappings
builder.Services.AddBusinessLogicServices();
//add the dal di mappings
builder.Services.AddDataAccessServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
