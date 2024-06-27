using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrakingOreder.Areas.Identity.Data;
using TrakingOreder.Models;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("TrakingOrederContextConnection") ?? throw new InvalidOperationException("Connection string 'TrakingOrederContextConnection' not found.");

builder.Services.AddDbContext<TrakingOrederContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<TrakingUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<TrakingOrederContext>();
builder.Services.Configure<List<Url>>(builder.Configuration.GetSection("Controllers"));
// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.MapRazorPages();
app.Run();
