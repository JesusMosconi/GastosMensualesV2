using GastosMensuales.BD.Datos;
using GastosMensuales.Server.Client.Pages;
using GastosMensuales.Server.Components;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


#region Construccion

var stringConexion = builder.Configuration.GetConnectionString("ConexionBD");

builder.Services.AddDbContext<MiDBcontext>(options => options.UseSqlServer(stringConexion));

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

#endregion

app.Run();
