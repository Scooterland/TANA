using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using TANA.Application.Interface;
using TANA.Application.Services;
using TANA.Domain.Interface;
using TANA.Infrastructure.Repositories;
using TANA.Infrastructure.Services;
using TANA.Persistence.Data;
using TANA.Persistence.Repositories;
using TANA.Web.Authentication;
using TANA.Web.Components;


var builder = WebApplication.CreateBuilder(args);


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
builder.Services.AddScoped<ITravelPlanService, TravelPlanService>();
var context = new CustomAssemblyLoadContext();
context.LoadUnmanagedLibrary(Path.Combine(Directory.GetCurrentDirectory(), "libwkhtmltox", "libwkhtmltox.dll"));
builder.Services.AddScoped<TemplateStateService>();
builder.Services.AddScoped<ITemplateRepository, TemplateRepository>();
builder.Services.AddScoped<TemplateLibraryService>();


// ✅ Database Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient("TanaApi", client =>
{
    client.BaseAddress = new Uri("http://localhost:5000/");
});

var app = builder.Build();

// ✅ Middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();