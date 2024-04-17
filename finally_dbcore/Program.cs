using finally_dbcore.common;
using finally_dbcore.Models.Road;
using finally_dbcore.Models.test;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// �O�o�[�bAddControllers  ���� �ҰʪA��

builder.Services.AddControllers();

builder.Services.AddDbContext<testContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("TodoDatabase")));

builder.Services.AddDbContext<RoadContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

builder.Services.�\��();

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

app.���~�d�I();
app.UseAuthorization();

app.MapControllers();

app.Run();
