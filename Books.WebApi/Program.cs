using Books.CrossCutting.Config;
using Books.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowEverything", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddCrossCutting();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString =
    builder.Configuration.GetConnectionString("BooksConnection")
    ?? throw new InvalidOperationException(
        "Connection string 'BooksConnection' não configurada.");

builder.Services.AddDbContext<BooksDbContext>(options =>
    options.UseMySql(
        connectionString,
        new MySqlServerVersion(new Version(8, 4, 13))
        //mysqlOptions => mysqlOptions.EnableRetryOnFailure()
    ));

//var builderConnection = new MySql.Data.MySqlClient
//    .MySqlConnectionStringBuilder(connectionString);

//Console.WriteLine($"Host: [{builderConnection.Server}]");
//Console.WriteLine($"Porta: [{builderConnection.Port}]");
//Console.WriteLine($"Banco: [{builderConnection.Database}]");

var app = builder.Build();

app.UseCors("AllowEverything");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
