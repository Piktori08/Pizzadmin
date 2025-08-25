using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Pizzadmin.Data;
using Pizzadmin.Repositories;
using Pizzadmin.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PizzadminContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("PizzadminContext") ??
    throw new InvalidOperationException("Connection string not found")));


// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});
builder.Services.AddControllersWithViews()
.AddNewtonsoftJson(options =>
 {
     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
     options.SerializerSettings.MaxDepth = 32; // Adjust as needed
 });

#region Repositories

builder.Services.AddScoped<ProductRepository, ProductRepository>();
builder.Services.AddScoped<OrderRepository, OrderRepository>();
builder.Services.AddScoped<OrderProductsRepository, OrderProductsRepository>();

#endregion


#region Services

builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderProductsService, OrderProductsService>();
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
app.UseCors("AllowAll");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();