using EjercicioEvaluacion1.Client.Pages;
using EjercicioEvaluacion1.Components;
using EjercicioEvaluacion1.Data;
using EjercicioEvaluacion1.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensibility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddDbContextFactory<EjercicioDbContext>(options =>
    options.UseSqlServer(@"Data Source=(localdb)\\mssqllocaldb;Initial Catalog=EjercicioEval;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True"));

builder.Services.AddSingleton<ITareaService, TareaService>();

var app = builder.Build();

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

using (var scope = app.Services.CreateScope()){
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<EjercicioDbContext>();
    context.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(EjercicioEvaluacion1.Client._Imports).Assembly);

app.Run();