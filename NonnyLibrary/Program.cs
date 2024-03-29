using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nonny.DataAccess.Data;
using Nonny.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("MyConnection")));


builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    var allowed = options.User.AllowedUserNameCharacters
      + "/-@.";
    options.User.AllowedUserNameCharacters = allowed;
    options.Password.RequiredLength = 3;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(3);
    options.Cookie.IsEssential = true;

});
builder.Services.ConfigureApplicationCookie(options =>
          {
              // Cookie settings
              options.Cookie.HttpOnly = true;
              options.ExpireTimeSpan = TimeSpan.FromDays(150);
              options.LoginPath = "/Account/Login";
              options.LogoutPath = "/Account/Logout";
              options.AccessDeniedPath = new PathString("/Administration/AccessDenied");
              options.SlidingExpiration = true;
          });

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
