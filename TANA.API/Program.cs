using System.Runtime.InteropServices;
using TANA.Web;

var builder = WebApplication.CreateBuilder(args);

// Load wkhtmltox native library
var context = new CustomAssemblyLoadContext();
context.LoadUnmanagedLibrary(CustomAssemblyLoadContext.GetWkhtmltoxLibraryPath());


// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
