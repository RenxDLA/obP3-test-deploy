using AccesoDeDatos.RepositoriosSQL;
using HotelDeCabañas.Interfaces;
using LogicaAplicacion.CU.TiposCU;
using LogicaAplicacion.CU.CabañaCU;
using LogicaAplicacion.InterfacesCU.ICabaña;
using LogicaAplicacion.InterfacesCU.ITipoCabaña;
using LogicaAplicacion.InterfacesCU.IFuncionario;
using LogicaAplicacion.InterfacesCU;
using LogicaAplicacion.CU.FuncionarioCU;
using LogicaAplicacion.InterfacesCU.IMantenimiento;
using LogicaAplicacion.CU.MantenimientoCU;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRepositorioFuncionario, SQLRepositorioFuncionario>();
builder.Services.AddScoped<IRepositorioCabaña, SQLRepositorioCabaña>();
builder.Services.AddScoped<IRepositorioMantenimiento, SQLRepositorioMantenimiento>();
builder.Services.AddScoped<IRepositorioTCabaña, SQLRepositorioTCabaña>();
builder.Services.AddScoped<IRepositorioConfiguracion, SQLRepositorioConfiguracion>();
//Scoped de CASOS DE USO
builder.Services.AddScoped<ILoginCU, LoginCU>();
//Scoped Tipo Cabaña
builder.Services.AddScoped<IAltaDeTCabañaCU, AltaTipoCU>();
builder.Services.AddScoped<IObtenerTiposCU, ObtenerTiposCU>();
builder.Services.AddScoped<IBuscarTiposPorNombreCU, BuscarTiposPorNombreCU>();
builder.Services.AddScoped<IObtenerTipoPorNombre, ObtenerTipoPorNombreCU>();
builder.Services.AddScoped<IBorrarTipoCU, BorrarTipoCU>();
builder.Services.AddScoped<IEditarTipoCU, EditarTipoCU>();
//Scoped Cabaña
builder.Services.AddScoped<IRegistroCabañaCU, RegistroCabañaCU>();
builder.Services.AddScoped<IObtenerTodasLasCabañasCU, ObtenerTodasLasCabañasCU>();
builder.Services.AddScoped<IBuscarCabañaPorNombreCU, BuscarCabañaPorNombreCU>();
builder.Services.AddScoped<IBuscarCabañaPorTipoCU, BuscarCabañaPorTipoCU>();
builder.Services.AddScoped<IBuscarCabañaPorCantidadCU, BuscarCabañaPorCantidadCU>();
builder.Services.AddScoped<IBuscarCabañasHabilitadasCU, BuscarCabañasHabilitadasCU>();
builder.Services.AddScoped<IBuscarCabañaPorIdCU, BuscarCabañaPorIdCU>();
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
