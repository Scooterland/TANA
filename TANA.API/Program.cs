using Microsoft.EntityFrameworkCore;
using TANA.Application.Interface;
using TANA.Application.Services;
using TANA.Infrastructure.Services;
using TANA.Persistence.Data;
using TANA.Persistence.Repositories;
using QuestPDF.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

QuestPDF.Settings.License = LicenseType.Community;

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBrugerRepository, BrugerRepository>();
builder.Services.AddScoped<IKundeRepository, KundeRepository>();
builder.Services.AddScoped<IRejseRepository, RejseRepository>();
builder.Services.AddScoped<ITurRepository, TurRepository>();
builder.Services.AddScoped<ITemplateRepository, TemplateRepository>();

builder.Services.AddScoped<IBrugerService, BrugerService>();
builder.Services.AddScoped<ITurService, TurService>();
builder.Services.AddScoped<IKundeService, KundeService>();
builder.Services.AddScoped<IRejseService, RejseService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IEmailSettingsService, EmailSettingsService>();
builder.Services.AddScoped<TravelPlanService, TravelPlanService>();
builder.Services.AddScoped<TemplateStateService>();
builder.Services.AddScoped<TemplateLibraryService>();

builder.Services.AddHttpClient("TanaApi", client =>
{
    client.BaseAddress = new Uri("http://tana-api:8080/");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!IsRunningInDocker())
{
    app.UseHttpsRedirection();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    // resolve DbContext (for checking DbSet<Bruger>) and BrugerService
    var context = services.GetRequiredService<AppDbContext>();
    var brugerService = services.GetRequiredService<IBrugerService>();

    // Make sure the database is up-to-date (migrations, etc.),
    // optionally uncomment if you use Migrations at runtime:
    // await context.Database.MigrateAsync();

    // Check & create admin if missing
    if (!await context.Brugere
                      .AsNoTracking()
                      .AnyAsync(u => u.Email == "admin@admin.dk"))
    {
        // If you prefer you can just call brugerService.EnsureAdminExistsAsync();
        // but we already know there’s no “admin@admin.dk”, so just call directly:
        await brugerService.EnsureAdminExistsAsync();
    }
}

app.UseAuthorization();
app.MapControllers();
app.Run();
static bool IsRunningInDocker()
{
    return Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true";
}
