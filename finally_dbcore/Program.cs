using finally_dbcore.Models.Road;
using finally_dbcore.Models.test;
using finally_dbcore.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 記得加在AddControllers  之後 啟動服務

builder.Services.AddControllers();

builder.Services.AddDbContext<testContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("TodoDatabase")));

builder.Services.AddDbContext<RoadContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddScoped<TodoService>();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder
             .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
