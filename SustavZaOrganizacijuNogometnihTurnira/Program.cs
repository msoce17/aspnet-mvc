using Microsoft.EntityFrameworkCore;
using SustavZaOrganizacijuNogometnihTurnira.Model.Data;
using SustavZaOrganizacijuNogometnihTurnira.Model.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TournamentDb")));
builder.Services.AddScoped<StadionRepository>();
builder.Services.AddScoped<EkipaRepository>();
builder.Services.AddScoped<IgracRepository>();
builder.Services.AddScoped<SudacRepository>();
builder.Services.AddScoped<TurnirRepository>();
builder.Services.AddScoped<PrijavaEkipeRepository>();
builder.Services.AddScoped<UtakmicaRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
