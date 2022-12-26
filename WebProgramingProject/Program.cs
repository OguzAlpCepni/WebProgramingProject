using Microsoft.EntityFrameworkCore;
using WebProgramingProject.Data;
using Microsoft.AspNetCore.Identity;
using WebProgramingProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<MovieDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    //opts.UseLazyLoadingProxies();
});


builder.Services.AddDbContext<ApplicationDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    //opts.UseLazyLoadingProxies();
});
builder.Services.AddIdentity<MovieUser,AppRole>(options=>
{
    options.Password.RequiredLength = 2;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultUI()
.AddTokenProvider<DataProtectorTokenProvider<MovieUser>>(TokenOptions.DefaultProvider);


builder.Services.AddControllersWithViews();
// Add services to the container.


var app = builder.Build();
app.UseAuthentication();
app.MapRazorPages();
IdentitySeed.Initialize(app.Services);


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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
