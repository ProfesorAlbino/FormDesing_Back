using FormDesing.Helpers;
using FormDesing.Models.DB;
using FormDesing.Repositories.FormDataRepository;
using FormDesing.Repositories.FormInputRepository;
using FormDesing.Repositories.FormRepository;
using FormDesing.Repositories.InputRepository;
using FormDesing.Repositories.UserRepository;
using FormDesing.Services.FormDataService;
using FormDesing.Services.FormInputService;
using FormDesing.Services.FormService;
using FormDesing.Services.InputService;
using FormDesing.Services.UserService;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Configuración del DbContext con SQL Server
builder.Services.AddDbContext<FormDesingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuración de AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Configuración de JWT
builder.Services.AddScoped<IJwtHelper, JwtHelper>();

// Repositorios
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IInputRepository, InputRepository>();
builder.Services.AddScoped<IFormRepository, FormRepository>();
builder.Services.AddScoped<IFormInputRepository, FormInputRepository>();
builder.Services.AddScoped<IFormDataRepository, FormDataRepository>();

// Servicios
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IInputService, InputService>();
builder.Services.AddScoped<IFormService, FormService>();
builder.Services.AddScoped<IFormInputService, FormInputService>();
builder.Services.AddScoped<IFormaDataService, FormDataService>();

// Add services to the container.

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

// Middleware de autenticación
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
