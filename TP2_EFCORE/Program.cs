using Microsoft.EntityFrameworkCore;
using TP2_EFCORE.Data;
using TP2_EFCORE.Services;
using TP2_EFCORE.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Configure DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<ApplicationDbContext>(x =>
{
    x.UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); }));
    if (builder.Environment.IsDevelopment())
    {
        // N'affichez les données sensibles qu'en mode développement uniquement.
        x.EnableSensitiveDataLogging();
    }

    x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<PiscinesServices>();
builder.Services.AddScoped<CoursService>();
builder.Services.AddScoped<UtilisateurService>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
