using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Estoque.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar a string de conexão para o Entity Framework
builder.Services.AddDbContext<EstoqueContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EstoqueContext") ?? throw new InvalidOperationException("Connection string 'EstoqueContext' not found.")));

// Adicionar serviços para o contêiner
builder.Services.AddControllersWithViews()
    .AddDataAnnotationsLocalization(); // Adiciona suporte à localização para validações

var app = builder.Build();

// Configure o pipeline de requisições HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Configurar a localização
var defaultCulture = new CultureInfo("pt-BR"); // Ajuste para a cultura desejada
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(defaultCulture),
    SupportedCultures = new List<CultureInfo> { defaultCulture },
    SupportedUICultures = new List<CultureInfo> { defaultCulture }
};

app.UseRequestLocalization(localizationOptions);

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
