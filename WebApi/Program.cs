using AccesoDeDatos.RepositoriosSQL;
using HotelDeCabañas.Interfaces;
using LogicaAplicacion.CU.CabañaCU;
using LogicaAplicacion.CU.FuncionarioCU;
using LogicaAplicacion.CU.MantenimientoCU;
using LogicaAplicacion.CU.TiposCU;
using LogicaAplicacion.InterfacesCU.ICabaña;
using LogicaAplicacion.InterfacesCU.IFuncionario;
using LogicaAplicacion.InterfacesCU.IMantenimiento;
using LogicaAplicacion.InterfacesCU.ITipoCabaña;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IRepositorioFuncionario, SQLRepositorioFuncionario>();
builder.Services.AddScoped<IRepositorioCabaña, SQLRepositorioCabaña>();
builder.Services.AddScoped<IRepositorioMantenimiento, SQLRepositorioMantenimiento>();
builder.Services.AddScoped<IRepositorioTCabaña, SQLRepositorioTCabaña>();
builder.Services.AddScoped<IRepositorioConfiguracion, SQLRepositorioConfiguracion>();


builder.Services.AddScoped<IAltaDeTCabañaCU, AltaTipoCU>();
builder.Services.AddScoped<IObtenerTiposCU, ObtenerTiposCU>();
builder.Services.AddScoped<IBuscarTiposPorNombreCU, BuscarTiposPorNombreCU>();
builder.Services.AddScoped<IObtenerTipoPorNombre, ObtenerTipoPorNombreCU>();
builder.Services.AddScoped<IBorrarTipoCU, BorrarTipoCU>();
builder.Services.AddScoped<IEditarTipoCU, EditarTipoCU>();


builder.Services.AddScoped<IRegistroCabañaCU, RegistroCabañaCU>();
builder.Services.AddScoped<IObtenerTodasLasCabañasCU, ObtenerTodasLasCabañasCU>();
builder.Services.AddScoped<IBuscarCabañaPorNombreCU, BuscarCabañaPorNombreCU>();
builder.Services.AddScoped<IBuscarCabañaPorTipoCU, BuscarCabañaPorTipoCU>();
builder.Services.AddScoped<IBuscarCabañaPorCantidadCU, BuscarCabañaPorCantidadCU>();
builder.Services.AddScoped<IBuscarCabañasHabilitadasCU, BuscarCabañasHabilitadasCU>();
builder.Services.AddScoped<IBuscarCabañaPorIdCU, BuscarCabañaPorIdCU>();
builder.Services.AddScoped<IBuscarPorTipoYMontoCU, BuscarPorTipoYMontoCU>();

builder.Services.AddScoped<IRegistroMantenimientoCU, RegistroMantenimientoCU>();
builder.Services.AddScoped<IObtenerMantenimientosPorIdCU, ObtenerMantenimientosPorIdCU>();
builder.Services.AddScoped<IObtenerMantnimientosEntreFechasCU, ObtenerMantenimientosEntreFechasCU>();
builder.Services.AddScoped<IBuscarEntreValoresCU, BuscarEntreValoresCU>();

builder.Services.AddScoped<IObtenerFuncionarioCU, ObtenerFuncionarioCU>();


var rutaArchivo = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WebApi.xml");
builder.Services.AddSwaggerGen(opciones =>
{
    //Se agrega la opcion de autenticarse en Swagger
    opciones.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
    {
        Description = "Autorizacion estandar mediante esquema Bearer",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    opciones.OperationFilter<SecurityRequirementsOperationFilter>();
    opciones.IncludeXmlComments(rutaArchivo);
    opciones.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Documentacion del obligatorio 2 de P3",
        Description = "Aqui se encuentran todos los endpoint activos para utilizar los servicios del proyecto del Obligatorio 2 de P3",
        Contact = new OpenApiContact
        {
            Email = "renatamoremal@gmail.com renzodeleonps@gmail.com"
            
        },
        Version = "v1"
    }); 
});

// Configurar de la autenticacion
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opciones =>
{
    opciones.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("275371KADJGHYRBBK@SDGRHJKO290199ASEWAFWAERTGYJUKK#$%^%$#@$%HJBN")),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

// Configurar la autorización
builder.Services.AddAuthorization(opciones =>
{
    opciones.DefaultPolicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// autorization y authentication
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
