using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using TANA.Application.Services;
using TANA.Domain.Interface;
using TANA.Infrastructure.Services;
using TANA.Persistence.Data;
using TANA.Persistence.Repositories;
using TANA.Web.Authentication;
using TANA.Web.Components;

var builder = WebApplication.CreateBuilder(args);

// ✅ Razor components & Blazor Server
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// ✅ Authentication & Authorization
builder.Services.AddAuthorizationCore(); // for [Authorize] and <AuthorizeView>
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, SessionAuthenticationStateProvider>();

// ✅ Application Services
builder.Services.AddScoped<IBrugerRepository, BrugerRepository>();
builder.Services.AddScoped<IKundeRepository, KundeRepository>();
builder.Services.AddScoped<IRejseRepository, RejseRepository>();

builder.Services.AddScoped<BrugerService>();
builder.Services.AddScoped<KundeService>();
builder.Services.AddScoped<RejseService>();
builder.Services.AddScoped<RejseplanService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IPdfService, PdfService>();
builder.Services.AddScoped<IEmailSettingsService, EmailSettingsService>();

// ✅ Database Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
