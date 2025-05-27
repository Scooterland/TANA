using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using TANA.Application.Services;
using TANA.Infrastructure.Services;
using TANA.Persistence.Data;
using TANA.Persistence.Repositories;
using TANA.Web.Authentication;
using TANA.Web.Components;
using System.Globalization;
using TANA.Application.Interface;
using QuestPDF.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

// ------------------------------
// Localization Configuration
// ------------------------------
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en-GB"),
        new CultureInfo("da-DK")
    };

    options.DefaultRequestCulture = new RequestCulture("en-GB");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;

    // 👇 Add both query and cookie providers
    options.RequestCultureProviders = new RequestCultureProvider[]
    {
        new QueryStringRequestCultureProvider
        {
            QueryStringKey = "culture",
            UIQueryStringKey = "culture"
        },
        new CookieRequestCultureProvider()
    };
});


// ✅ Razor components & Blazor Server
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Configure the HTTP request pipeline.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// ✅ Authentication & Authorization
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider,
                           SessionAuthenticationStateProvider>();

// ✅ Application Services
builder.Services.AddScoped<IBrugerRepository, BrugerRepository>();
builder.Services.AddScoped<IKundeRepository, KundeRepository>();
builder.Services.AddScoped<IRejseRepository, RejseRepository>();
builder.Services.AddScoped<ITurRepository, TurRepository>();

builder.Services.AddScoped<IBrugerService, BrugerService>();
builder.Services.AddScoped<ITurService, TurService>();
builder.Services.AddScoped<IKundeService, KundeService>();
builder.Services.AddScoped<IRejseService, RejseService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IEmailSettingsService, EmailSettingsService>();
builder.Services.AddScoped<TemplatePdfService>();
builder.Services.AddScoped<ITravelPlanService, TravelPlanService>();
builder.Services.AddScoped<TemplateStateService>();
builder.Services.AddScoped<ITemplateRepository, TemplateRepository>();
builder.Services.AddScoped<TemplateLibraryService>();
builder.Services.AddScoped<TemplatePdfService>();

// ✅ Database Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient("TanaApi", client =>
{
    client.BaseAddress = new Uri("http://tana-api:8080/");
});
QuestPDF.Settings.License = LicenseType.Community;

var app = builder.Build();

// ------------------------------
// Enable Localization Middleware
// ------------------------------
var locOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(locOptions.Value);

// ✅ Middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

if (!IsRunningInDocker())
{
    app.UseHttpsRedirection();
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
static bool IsRunningInDocker()
{
    return Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true";
}
