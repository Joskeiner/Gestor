using Gestor.APP.Utilidades;
using Gestor.BLL.Implementaciones;
using Gestor.BLL.Interfaces;
using Gestor.DAL;
using Gestor.DAL.Implementaciones;
using Gestor.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DbBitwiseTraining2Context>(opt =>
                                    opt.UseNpgsql(builder.Configuration.GetConnectionString("CadenaSQL")));

builder.Services.AddTransient(typeof(IGenericRepository<>) , typeof(GenericRepository<>));

builder.Services.AddScoped<ICategoriaService, CategoriaService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
