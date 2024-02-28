using Microsoft.EntityFrameworkCore;
using OgrenciBilgi.Api.Data;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddDbContext<DataBaseContext>(options =>
{
    string? connectionString = builder.Configuration.GetConnectionString("DbStudents");

    if (connectionString is null)
    {
        throw new InvalidCastException("Connection String is not found");
    }

    options.UseSqlServer(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder =>
{
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
    builder.AllowAnyOrigin();

});

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    using (var dbContext = scope.ServiceProvider.GetRequiredService<DataBaseContext>())
    {
        await dbContext.Database.EnsureDeletedAsync();
        await dbContext.Database.EnsureCreatedAsync();

        await DbSeed.SeedAsync(dbContext);
    }
}

app.Run();
