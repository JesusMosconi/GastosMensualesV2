using GastosMensuales.BD.Datos;
using GastosMensuales.BD.Datos.Entity;
using GastosMensuales.Repositorio;
using GastosMensuales.Server.Client.Pages;
using GastosMensuales.Server.Components;
using Microsoft.EntityFrameworkCore;
using GastosMensuales.Server.Controllers;

var builder = WebApplication.CreateBuilder(args);


#region Construccion

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var stringConexion = builder.Configuration.GetConnectionString("ConexionBD");

builder.Services.AddDbContext<MiDBcontext>(options => options.UseSqlServer(stringConexion));

builder.Services.AddScoped<IRepositorio<GastoDiario>, Repositorio<GastoDiario>>();
builder.Services.AddScoped<IRepositorio<Usuario>, Repositorio<Usuario>>();
builder.Services.AddScoped<IRepositorio<Ingreso>, Repositorio<Ingreso>>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();


#endregion
var app = builder.Build();

#region configuracion
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(GastosMensuales.Server.Client._Imports).Assembly);

app.MapControllers();
#endregion

app.Run();
