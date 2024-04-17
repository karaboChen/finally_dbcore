using finally_dbcore.common;
using finally_dbcore.Models.Road;
using finally_dbcore.Models.test;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 記得加在AddControllers  之後 啟動服務

builder.Services.AddControllers();

builder.Services.AddDbContext<testContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("TodoDatabase")));

builder.Services.AddDbContext<RoadContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

builder.Services.功能();

builder.Services.AddLogging(e => {
    e.AddConsole();
});



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

app.錯誤攔截();
app.UseAuthorization();

app.MapControllers();

app.Run();
