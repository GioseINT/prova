using Microsoft.EntityFrameworkCore;
using Prova.BLL.Interfaces;
using Prova.BLL.Services;
using Prova.DAL;
using Prova.DAL.Interfaces;
using Prova.DAL.Repositories;
using Prova.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IVeterinaryService, VeterinaryService>();
builder.Services.AddScoped<IAppointmentService,Appointmentervice >();
builder.Services.AddScoped<IPetService, PetService>();  

builder.Services.AddDbContext<AppDbConext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// AutoMapper
builder.Services.AddAutoMapper(opt=>opt.AddProfile(typeof(AutoMapperConfiguration)));
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
