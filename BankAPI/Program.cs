using BankAPI;
using BankAPI.Data;
using BankAPI.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "BancoAPI", Version = "v1" });
});

var databaseType = Environment.GetEnvironmentVariable("TIPO_CONEXION");
if (databaseType == "MYSQL")
{
    //var connectionString = Environment.GetEnvironmentVariable("STRING_CONEXION_MYSQL");
    //builder.Services.AddDbContext<BankAPIContext>(options =>
    //options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
}
else if (databaseType == "SQLSERVER")
{
    var connectionString = Environment.GetEnvironmentVariable("STRING_CONEXION_SQLSERVER");
    builder.Services.AddDbContext<BankAPIContext>(options =>
        options.UseSqlServer(connectionString));
}
else
{
    throw new InvalidOperationException("No se ha configurado un tipo de base de datos válido.");
}

builder.Services.AddScoped<ClientesService>();
builder.Services.AddScoped<DetallePedidosService>();
builder.Services.AddScoped<IClientesRepository, EfClientesRepository>();
builder.Services.AddScoped<IDetallePedidosRepository, EfDetallePedidos>();

var app = builder.Build();

// Eliminar en produccion
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("Pol�ticaCORS");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
