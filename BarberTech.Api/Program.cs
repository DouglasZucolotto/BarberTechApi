using BarberTech.Application.Commands.Haircuts.Create;
using BarberTech.Infraestructure;
using BarberTech.Infraestructure.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BarberTech.Infraestructure.Repositories;
using BarberTech.Domain;
using BarberTech.Domain.Authentication;
using BarberTech.Domain.Repositories;
using BarberTech.Domain.Notifications;
using BarberTech.Infraestructure.Notifications;
using BarberTech.Api.Filters;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblies(new[] {
    typeof(CreateHaircutCommandHandler).Assembly
}));

builder.Services.AddDbContext<DataContext>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000")
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials();
    });
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IHttpContext, BarberTech.Infraestructure.Authentication.HttpContext>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<INotificationContext, NotificationContext>();

builder.Services.AddTransient<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IHaircutRepository, HaircutRepository>();
builder.Services.AddTransient<IBarberRepository, BarberRepository>();
builder.Services.AddTransient<IEstablishmentRepository, EstablishmentRepository>();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));
builder.Services.Configure<ConnectionOptions>(builder.Configuration.GetSection("ConnectionString"));

builder.Services.AddMvc(options =>
{
    options.Filters.Add<NotificationFilter>();
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtOptions = builder.Configuration.GetSection("JwtOptions").Get<JwtOptions>();
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtOptions.Issuer,
            ValidAudience = jwtOptions.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),
        };
    });

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Barber Tech", Version = "v1" });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("haircuts:view", policy => policy.RequireClaim("permissions", "haircuts:view"));
    options.AddPolicy("haircuts:edit", policy => policy.RequireClaim("permissions", "haircuts:edit"));
    options.AddPolicy("feedbacks:view", policy => policy.RequireClaim("permissions", "feedbacks:view"));
    options.AddPolicy("feedbacks:edit", policy => policy.RequireClaim("permissions", "feedbacks:edit"));
    options.AddPolicy("establishments:view", policy => policy.RequireClaim("permissions", "establishments:view"));
    options.AddPolicy("establishments:edit", policy => policy.RequireClaim("permissions", "establishments:edit"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();