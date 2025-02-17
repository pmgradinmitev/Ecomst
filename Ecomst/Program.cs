using Ecomst.Data;
using Ecomst.Repositories.IRepositories;
using Ecomst.Repositories;
using Ecomst.Services.IServices;
using Ecomst.Services;
using Microsoft.EntityFrameworkCore;
using Ecomst.Seeds;
using Microsoft.AspNetCore.Identity;
using Ecomst.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<ApplicationUser>().AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>(); //identity ++
builder.Services.AddRazorPages();
//builder.Services.AddRazorPages().AddRazorPagesOptions(options => {
//    options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "");
//});
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedCategoryData.Initialize(services);
    SeedProductData.Initialize(services);
    SeedRoleData.Initialize(services);
    SeedUserData.Initialize(services);
}

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
app.UseAuthentication(); //identity authentication
app.UseAuthorization();
app.MapRazorPages(); //identity, routing to map razor pages

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Store}/{controller=Product}/{action=Index}/{id?}");

app.Run();
