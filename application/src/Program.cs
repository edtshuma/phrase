using Phrase.Services;
using Phrase.Helpers;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static Phrase.Controllers.PhraseController;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPalindromeService, PalindromeService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ReadinessCheckFilterAttribute>(provider =>
        {
            var startTime = DateTime.Now; // Initialize as needed
            return new ReadinessCheckFilterAttribute(startTime);
        });
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlSvrConn")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    Console.WriteLine("--> Using SqlSvr");
}

app.MapControllers();
app.Run();
