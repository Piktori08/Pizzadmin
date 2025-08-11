using Microsoft.EntityFrameworkCore;
using Pizzadmin.Data;
using Pizzadmin.Repositories;
using Pizzadmin.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PizzadminContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("PizzadminContext") ??
    throw new InvalidOperationException("Connection string not found")));


// Add services to the container.
builder.Services.AddControllersWithViews();

#region Repositories

builder.Services.AddScoped<ProductRepository, ProductRepository>();

#endregion


#region Services

builder.Services.AddTransient<IProductService, ProductService>();

#endregion


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
