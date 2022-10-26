using FigureTask.Data;
using FigureTask.Data.Interfaces;
using FigureTask.Data.Storage;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAllGeometricFigures, AllGeometricFigures>();
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DbConnect");
builder.Services.AddDbContext<ApplicationDB>(c => c.UseNpgsql(connectionString));


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
   
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Figure}/{action=ShowFigure}/{id?}");

app.Run();
