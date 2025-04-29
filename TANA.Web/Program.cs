using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using TANA.Persistence.Data;
using TANA.Web.Components;
using TANA.Domain.Interface;
using TANA.Application.Services;
using TANA.Persistence.Repositories;
using TANA.Infrastructure.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBrugerRepository, BrugerRepository>();
builder.Services.AddScoped<BrugerService>();

builder.Services.AddScoped<IPdfService, PdfService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<RejseplanService>();
builder.Services.AddScoped<IEmailSettingsService, EmailSettingsService>();

builder.Services.AddAuthorizationCore();  // Tilføj authorization core
builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();
builder.Services.AddAuthorization();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

await builder.Build().RunAsync();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
