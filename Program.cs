using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BOTCDatabase.Data;
using BOTCDatabase.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<BludContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BludContext") ?? throw new InvalidOperationException("Connection string 'BludContext' not found.")));

var app = builder.Build();
// Initialize and seed database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var webroot = builder.Environment;
    string Townsfolk = "txts/ListTownsfolk.txt";
    string Outsiders = "txts/ListOutsiders.txt";
    string Minions = "txts/ListMinions.txt";
    string Demons = "txts/ListDemons.txt";
    string Travellers = "txts/ListTravellers.txt";
    string Fabled = "txts/ListFabled.txt";

    string iconPath = "images/icons/";
    string descriptionPath = "txts/descriptions/";
    string tipsPath = "txts/tips/";
    if (SeedData.InitializeTownsfolk(services, webroot, Townsfolk, iconPath, descriptionPath, tipsPath) == 0)
    {
        SeedData.InitializeOutsiders(services, webroot, Outsiders, iconPath, descriptionPath, tipsPath);
        SeedData.InitializeMinions(services, webroot, Minions, iconPath, descriptionPath, tipsPath);
        SeedData.InitializeDemons(services, webroot, Demons, iconPath, descriptionPath, tipsPath);
        SeedData.InitializeTravellers(services, webroot, Travellers, iconPath, descriptionPath, tipsPath);
        SeedData.InitializeFabled(services, webroot, Fabled, iconPath, descriptionPath, tipsPath);
    }
    
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
