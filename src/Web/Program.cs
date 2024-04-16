using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// przeniesienie definiowania scopow do poszczególnych projektów za pomocą depedency injection extension
builder.Services.AddWebServices();
builder.Services.AddAppServices();

builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

app.EnsureMigrationOfContext();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();