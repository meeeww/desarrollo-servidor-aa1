using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using BankAPI.Data;
using BankAPI.Data.Repositories;
using BankAPI.Data.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var secretKey = new byte[32]; // 256 bits

var rng = new RNGCryptoServiceProvider();
rng.GetBytes(secretKey);
var secretKeyBase64 = Convert.ToBase64String(secretKey);

// Usa la clave secreta para firmar el token
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKeyBase64));
var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
var token = new JwtSecurityToken(
    issuer: builder.Configuration["Jwt:Issuer"],
    audience: builder.Configuration["Jwt:Audience"],
    expires: DateTime.Now.AddYears(1),
    signingCredentials: creds);

var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

// Guarda la clave secreta y el token en la configuración
builder.Configuration["Jwt:Key"] = secretKeyBase64;
builder.Configuration["Jwt:Token"] = tokenString;

System.Console.WriteLine($"Secret Key: {secretKeyBase64}");
System.Console.WriteLine($"Token: {tokenString}");

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // Configura Swagger para usar el esquema de seguridad JWT
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token in the text input below.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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

builder.Services.AddSingleton(new MySQLConfiguration(builder.Configuration.GetConnectionString("MySqlConnection")));

// Agrega servicios al contenedor.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
            // Asegura que el token de la solicitud coincida con el token estático
            LifetimeValidator = (before, expires, token, parameters) =>
            {
                var jwtToken = token as JwtSecurityToken;
                return jwtToken != null && jwtToken.RawData.Equals(builder.Configuration["Jwt:Token"]);
            }
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddScoped<IClientesRepository, ClientesRepository>();
builder.Services.AddScoped<IPedidosRepository, PedidosRepository>();
builder.Services.AddScoped<IProductosRepository, ProductosRepository>();
builder.Services.AddScoped<IRegistroVentasRepository, RegistroVentasRepository>();
builder.Services.AddScoped<IDetallePedidosRepository, DetallePedidosRepository>();
builder.Services.AddScoped<IEmpleadosRepository, EmpleadosRepository>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
}

app.UseRouting();

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();