using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pizzadmin.Data;
using Pizzadmin.Hubs;
using Pizzadmin.Identity;
using Pizzadmin.Repositories;
using Pizzadmin.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PizzadminContext>(Options => Options.UseSqlServer(
    builder.Configuration.GetConnectionString("PizzadminContext") ??
    throw new InvalidOperationException("Connection string not found")));

// Identity
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<PizzadminContext>()
    .AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddAuthorization();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy
            .WithOrigins(
                "https://localhost:44365",
                "http://localhost:3000",
                "http://127.0.0.1:5500",    // Add this line
                "http://localhost:5500",    // Add this too
                "null"
            )
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
});

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        options.SerializerSettings.MaxDepth = 32;
    });

// Add SignalR service
builder.Services.AddSignalR();

#region Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ProductRepository, ProductRepository>();
builder.Services.AddScoped<OrderRepository, OrderRepository>();
builder.Services.AddScoped<OrderProductsRepository, OrderProductsRepository>();
builder.Services.AddScoped<NotificationRepository, NotificationRepository>();
#endregion

#region Services
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderProductsService, OrderProductsService>();
builder.Services.AddTransient<INotificationService, NotificationService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("AllowAll"); // Moved before UseRouting

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapHub<NotificationHub>("/notificationHub");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");


app.Run();