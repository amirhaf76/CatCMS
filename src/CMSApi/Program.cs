using Autofac;
using Autofac.Extensions.DependencyInjection;
using CMSApi;
using CMSApi.Abstraction.Services;
using CMSApi.Services;
using CMSRepository;
using CMSRepository.Abstractions;
using CMSRepository.Models;
using CMSRepository.Repositories;
using Infrastructure;
using Infrastructure.JWTService;
using Infrastructure.JWTService.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Preparing Configs.
var connectionString = builder.Configuration.GetConnectionString($"CatCMSDB")
    ?? throw new InvalidOperationException($"Connection string 'CatCMSDB' not found.");

builder.Services.AddDbContext<CMSDBContext>(opt => opt.UseSqlServer(connectionString));


var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Services.AddExceptionHandler<DBExceptionHandler>();
// Adding Logger Service.
builder.Host.UseSerilog(logger);

// Injecting Dependency.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterType<CMSDBContext>().As<DbContext>().SingleInstance();
    builder.RegisterGeneric(typeof(PasswordHasher<>)).As(typeof(IPasswordHasher<>)).InstancePerLifetimeScope();
    builder.RegisterType<SymmetricJWTTokenService>().As<IJWTTokenService>().InstancePerLifetimeScope();
    builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
    builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();



});
//var jwtKeyRepository = new JWTKeyRepository();

//builder.Services.AddSingleton(_ => RSA.Create());
//builder.Services.AddSingleton(sp =>
//{
//    var rsa = sp.GetRequiredService<RSA>();

//    jwtKeyRepository.Purpose = "Auth";
//    jwtKeyRepository.PublicKey = Convert.ToBase64String(rsa.ExportRSAPublicKey());
//    jwtKeyRepository.PrivateKey = Convert.ToBase64String(rsa.ExportRSAPrivateKey());

//    return jwtKeyRepository;
//});

// Setting Authentication.
builder.Services
    .AddAuthentication()
    .AddJwtBearer(jwtOptions =>
    {
        var key = builder.Configuration["JWT:Key"] ?? throw new ArgumentNullException();

        jwtOptions.SaveToken = true;
        jwtOptions.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JWT:Audience"],
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(key)),
        };
    });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
