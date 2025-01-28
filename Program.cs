using FormDesing.Helpers;
using FormDesing.Models.DB;
using FormDesing.Repositories.AuthRepository;
using FormDesing.Repositories.FormDataRepository;
using FormDesing.Repositories.FormInputRepository;
using FormDesing.Repositories.FormRepository;
using FormDesing.Repositories.InputRepository;
using FormDesing.Repositories.UserRepository;
using FormDesing.Services.AuthService;
using FormDesing.Services.FormInputService;
using FormDesing.Services.FormService;
using FormDesing.Services.InputService;
using FormDesing.Services.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configuración del DbContext con SQL Server
builder.Services.AddDbContext<FormDesingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuración de AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Configuración de JWT
builder.Services.AddScoped<IJwtHelper, JwtHelper>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

// Repositorios
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IInputRepository, InputRepository>();
builder.Services.AddScoped<IFormRepository, FormRepository>();
builder.Services.AddScoped<IFormInputRepository, FormInputRepository>();
builder.Services.AddScoped<IFormDataRepository, FormDataRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

// Servicios
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IInputService, InputService>();
builder.Services.AddScoped<IFormService, FormService>();
builder.Services.AddScoped<IFormInputService, FormInputService>();
builder.Services.AddScoped<IAuthService, AuthService>();

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("FormDesing", policy =>
    {
        policy.AllowAnyOrigin() // Cambia por el dominio de tu sitio web
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

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

//Habilitar Cors
app.UseCors("FormDesing");

// Middleware de autenticación
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
