using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using AutoMapper;
using DevShop.Application;
using DevShop.Application.AutoMapper;
using DevShop.Persistance;
using DevShop.Persistance.Autofac;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(
    new AutofacBusinessModule()));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddPersistanceServices();
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.MapDefaultControllerRoute();


app.Run();
