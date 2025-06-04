using AccesoDeDatos.RepositoriosSQL;
using HotelDeCaba�as.Interfaces;
using LogicaAplicacion.CU.TiposCU;
using LogicaAplicacion.CU.Caba�aCU;
using LogicaAplicacion.InterfacesCU.ICaba�a;
using LogicaAplicacion.InterfacesCU.ITipoCaba�a;
using LogicaAplicacion.InterfacesCU.IFuncionario;
using LogicaAplicacion.InterfacesCU;
using LogicaAplicacion.CU.FuncionarioCU;
using LogicaAplicacion.InterfacesCU.IMantenimiento;
using LogicaAplicacion.CU.MantenimientoCU;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRepositorioFuncionario, SQLRepositorioFuncionario>();
builder.Services.AddScoped<IRepositorioCaba�a, SQLRepositorioCaba�a>();
builder.Services.AddScoped<IRepositorioMantenimiento, SQLRepositorioMantenimiento>();
builder.Services.AddScoped<IRepositorioTCaba�a, SQLRepositorioTCaba�a>();
builder.Services.AddScoped<IRepositorioConfiguracion, SQLRepositorioConfiguracion>();
//Scoped de CASOS DE USO
builder.Services.AddScoped<ILoginCU, LoginCU>();
//Scoped Tipo Caba�a
builder.Services.AddScoped<IAltaDeTCaba�aCU, AltaTipoCU>();
builder.Services.AddScoped<IObtenerTiposCU, ObtenerTiposCU>();
builder.Services.AddScoped<IBuscarTiposPorNombreCU, BuscarTiposPorNombreCU>();
builder.Services.AddScoped<IObtenerTipoPorNombre, ObtenerTipoPorNombreCU>();
builder.Services.AddScoped<IBorrarTipoCU, BorrarTipoCU>();
builder.Services.AddScoped<IEditarTipoCU, EditarTipoCU>();
//Scoped Caba�a
builder.Services.AddScoped<IRegistroCaba�aCU, RegistroCaba�aCU>();
builder.Services.AddScoped<IObtenerTodasLasCaba�asCU, ObtenerTodasLasCaba�asCU>();
builder.Services.AddScoped<IBuscarCaba�aPorNombreCU, BuscarCaba�aPorNombreCU>();
builder.Services.AddScoped<IBuscarCaba�aPorTipoCU, BuscarCaba�aPorTipoCU>();
builder.Services.AddScoped<IBuscarCaba�aPorCantidadCU, BuscarCaba�aPorCantidadCU>();
builder.Services.AddScoped<IBuscarCaba�asHabilitadasCU, BuscarCaba�asHabilitadasCU>();
builder.Services.AddScoped<IBuscarCaba�aPorIdCU, BuscarCaba�aPorIdCU>();
builder.Services.AddScoped<IBuscarPorTipoYMontoCU, BuscarPorTipoYMontoCU>();
//Scoped Mantenimiento
builder.Services.AddScoped<IRegistroMantenimientoCU, RegistroMantenimientoCU>();
builder.Services.AddScoped<IObtenerMantenimientosPorIdCU, ObtenerMantenimientosPorIdCU>();
builder.Services.AddScoped<IObtenerMantnimientosEntreFechasCU, ObtenerMantenimientosEntreFechasCU>();
builder.Services.AddScoped<IBuscarEntreValoresCU, BuscarEntreValoresCU>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
