//Esta clase abarca todo

using Microsoft.EntityFrameworkCore;
using Shopping.Data.Entities;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(o =>//se configuro la base de datos 
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); //el cual se definio en appsetting.json
});

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
