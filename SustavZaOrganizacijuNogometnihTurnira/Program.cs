using SustavZaOrganizacijuNogometnihTurnira.Model.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<StadionMockRepository>();
builder.Services.AddSingleton<EkipaMockRepository>();
builder.Services.AddSingleton<IgracMockRepository>();
builder.Services.AddSingleton<SudacMockRepository>();
builder.Services.AddSingleton<TurnirMockRepository>();
builder.Services.AddSingleton<PrijavaEkipeMockRepository>();
builder.Services.AddSingleton<UtakmicaMockRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
