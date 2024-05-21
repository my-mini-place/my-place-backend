using Infrastructure;
using Infrastructure.Identity;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddAppServices();

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

await app.EnsureMigrationOfContext();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseSerilogRequestLogging();

app.UseCors(builder =>
       builder.WithOrigins("http://localhost:1234")
              .AllowAnyHeader()
              .AllowAnyMethod());
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program
{ }