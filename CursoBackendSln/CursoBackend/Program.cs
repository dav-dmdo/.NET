using CursoBackend.Services;
using CursoBackend.Services.Interfaces;
using CursoBackend.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddKeyedSingleton<IPeopleService, PeopleService>("peopleService");
builder.Services.AddKeyedSingleton<IPeopleService, People2Service>("people2Service");

builder.Services.AddKeyedSingleton<IRandomService, RandomService>("randomSingleton");
builder.Services.AddKeyedScoped<IRandomService, RandomService>("randomScoped");
builder.Services.AddKeyedTransient<IRandomService, RandomService>("randomTransient");

builder.Services.AddScoped<IPostsService, PostsService>();

// Add HTTP Client Factory
builder.Services.AddHttpClient<IPostsService, PostsService>(
    client => 
    {
        var baseUrl = builder.Configuration["BaseUrlPosts"];
        if (!string.IsNullOrEmpty(baseUrl))
        {
            client.BaseAddress = new Uri(baseUrl);
        }
        else
        {
            throw new ArgumentNullException("BaseUrlPosts", "BaseUrlPosts configuration value is missing or empty.");
        }
    }
);

// Context DB Connection · EF Core
builder.Services.AddDbContext<TiendaDotnetContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TiendaDotnetConnection"));
});

System.Console.WriteLine(builder.Configuration["OtherKey:Prueba:TiendaDotnetConnection1"]);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
