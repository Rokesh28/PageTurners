using Microsoft.EntityFrameworkCore;
using PageTurners.DataAccess.Data;
using PageTurners.DataAccess.Repository;
using PageTurners.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using PageTurners.Utility;
using Stripe;
using PageTurners.DataAccess.DbInitializer;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();
//test
// Add services to the container.
builder.Services.AddControllersWithViews();


//for development use in mac - mysql
//var connectionString = Environment.GetEnvironmentVariable("DEFAULT_CONNECTION_DEV");
//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString , new MySqlServerVersion(new Version(8, 0, 37))));


////for production use - using sqlserver:
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer("Server=tcp:rokzsql.database.windows.net,1433;Initial Catalog=PageTurner;Persist Security Info=False;User ID=sqladmin;Password=Rokzsql@28;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));

builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));
builder.Services.ConfigureApplicationCookie(options => {
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});

builder.Services.AddAuthentication().AddFacebook(option => {
    option.AppId = Environment.GetEnvironmentVariable("FACEBOOK_API_ID");
    option.AppSecret = Environment.GetEnvironmentVariable("FACEBOOK_APP_SECRET");
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


builder.Services.AddRazorPages();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();

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
StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<String>();
app.UseRouting();

app.UseAuthentication(); 
app.UseAuthorization();
app.UseSession();
SeedDatabase();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();

void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInitializer.Initialize();
    }
}

