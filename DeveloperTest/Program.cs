using Application;
using Carter;
using DeveloperTest;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCarter();

builder.Services.AddWebServices(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddInfrastucture(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapCarter();

app.Run();