using Autofac;
using Autofac.Extensions.DependencyInjection;
using CMSRepository;
using Microsoft.EntityFrameworkCore;
using Serilog;

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

// Adding Logger Service.
builder.Host.UseSerilog(logger);

// Injecting Dependency.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{



});



// Setting Authentication.
//builder.Services
//    .AddAuthentication(authenticationOptions =>
//    {
//        authenticationOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//        authenticationOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    }).AddJwtBearer(jwtOptions =>
//    {
//        var secretKey = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);

//        jwtOptions.SaveToken = true;
//        jwtOptions.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = false,
//            ValidateAudience = false,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = builder.Configuration["JWT:Issuer"],
//            ValidAudience = builder.Configuration["JWT:Audience"],
//            IssuerSigningKey = new SymmetricSecurityKey(secretKey)
//        };
//    });


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
