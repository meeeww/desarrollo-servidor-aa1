using BankAPI.Data;
using BankAPI.Repositories;
using BankAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "BancoAPI", Version = "v1" });
});

//var connectionString = Environment.GetEnvironmentVariable("STRING_CONEXION");
builder.Services.AddSingleton(new MySQLConfiguration(builder.Configuration.GetConnectionString("MySqlConnection")));


builder.Services.AddScoped<IClientesRepository, ClientesRepository>();
builder.Services.AddScoped<IPedidosRepository, PedidosRepository>();
builder.Services.AddScoped<IProductosRepository, ProductosRepository>();
builder.Services.AddScoped<IRegistroVentasRepository, RegistroVentasRepository>();
builder.Services.AddScoped<IDetallePedidosRepository, DetallePedidosRepository>();
builder.Services.AddScoped<IEmpleadosRepository, EmpleadosRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PoliticaCORS", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Eliminar en produccion
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("Pol�ticaCORS");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
