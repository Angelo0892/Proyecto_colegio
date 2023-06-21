using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Usuario_control.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ColegioPruebaContext>(option=>
    option.UseSqlServer("Server:LAPTOP-HNTNC1IL;Database:COLEGIO_Prueba;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=True"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
