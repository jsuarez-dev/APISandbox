using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BlogAPI.Data;
using BlogAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add DB configuration

var connectionString = builder.Configuration.GetConnectionString("BlogAPIDbConnection");

builder.Services.AddDbContext<BlogAPIContext>(options => options.UseSqlite(connectionString));

// Add services to the container.
builder.Services.AddScoped<IDemoService, DemoService>();
builder.Services.AddTransient<ITranService, TranService>();
builder.Services.AddSingleton<ISingService, SingService>();
builder.Services.AddScoped<IScopeService, ScopedService>();

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
