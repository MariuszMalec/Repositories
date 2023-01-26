using Microsoft.EntityFrameworkCore;
using Repositories.WebAppMvc.Context;
using Repositories.WebAppMvc.Models;
using Repositories.WebAppMvc.Repositories;
using Repositories.WebAppMvc.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//dodane
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseInMemoryDatabase("usersDb"));
builder.Services.AddTransient<IRepository<User>, UserService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

//dodane
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    SeedData.Seed(dataContext);
}

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
