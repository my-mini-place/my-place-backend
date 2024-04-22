using Infrastructure;
using Infrastructure.Identity;

var builder = WebApplication.CreateBuilder(args);

// przeniesienie definiowania scopow do poszczeg�lnych projekt�w za pomoc� depedency injection extension
builder.Services.AddWebServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddAppServices();

var app = builder.Build();

await app.EnsureMigrationOfContext();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthorization();
app.MapControllers();

app.Run();