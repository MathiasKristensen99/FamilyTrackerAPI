using FamilyTrackerAPI.Core;
using FamilyTrackerAPI.Core.IServices;
using FamilyTrackerAPI.Domain.IRepositories;
using FamilyTrackerAPI.Domain.Services;
using FamilyTrackerAPI.MongoDB;
using FamilyTrackerAPI.MongoDB.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<FamilyTrackerDatabaseSettings>(builder.Configuration.GetSection("FamilyTrackerDatabase"));

builder.Services.AddScoped<IFamilyMemberService, FamilyMemberService>();
builder.Services.AddSingleton<IFamilyMemberRepository, FamilyMemberRepository>();

builder.Services.AddCors(options => options
    .AddPolicy("dev-policy", policyBuilder =>
        policyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("dev-policy");
}

app.UseCors("dev-policy");

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();