using Core.CrossCuttingConcerns.Exceptions;
using RentACar.Application;
using RentACar.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationDependencies();
builder.Services.AddPersistenceServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
    app.ConfigureCustomExceptionMiddleware();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
