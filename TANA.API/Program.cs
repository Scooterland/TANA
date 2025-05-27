using Microsoft.EntityFrameworkCore;
using TANA.Application.Interface;
using TANA.Application.Services;
using TANA.Domain.Entities;
using TANA.Infrastructure.Services;
using TANA.Persistence.Data;
using TANA.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);


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

app.UseAuthorization();
app.MapControllers();
app.Run();
static bool IsRunningInDocker()
{
    return Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true";
}
