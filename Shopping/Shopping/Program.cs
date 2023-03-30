//Esta clase abarca todo

using Microsoft.EntityFrameworkCore;
using Shopping.Data;
using Shopping.Helpers;
using Microsoft.AspNetCore.Identity;
using Shooping.Data.Entities;
using Shooping.Helpers;
using Shooping.Common;
using Shooping.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(o =>//se configuro la base de datos 
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));//aqui se hace una inyeccion de datos //el cual se definio en appsetting.json
});

//TODO: Make strongest password
builder.Services.AddIdentity<User, IdentityRole>(cfg =>
{
    cfg.Tokens.AuthenticatorTokenProvider = TokenOptions.DefaultAuthenticatorProvider;//Es para validar en email(generador de token
    cfg.SignIn.RequireConfirmedEmail = true;
    cfg.User.RequireUniqueEmail = true;
    cfg.Password.RequireDigit = false;//change
    cfg.Password.RequiredUniqueChars = 0;
    cfg.Password.RequireLowercase = false;//change
    cfg.Password.RequireNonAlphanumeric = false;//change
    cfg.Password.RequireUppercase = false;//change
    //cfg.Password.RequiredLength = 6;//minimo 6 caracteres
    cfg.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    cfg.Lockout.MaxFailedAccessAttempts = 3;//al equivocarse 3 veces
    cfg.Lockout.AllowedForNewUsers = true;
}).AddDefaultTokenProviders().AddEntityFrameworkStores<DataContext>();
//Se agrega servicios: Para que haga cambios en las vistas sin nesecidad de volver a cambiar el codigo

//TODO: ACTIVAR Aqui se muestra la vista de pagina no autorizada
//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.LoginPath = "/Account/NotAuthorized";
//    options.AccessDeniedPath = "/Account/NotAuthorized";//se manda a esta vista
//});



builder.Services.AddTransient<SeedDb>();//Se usa una sola vez 
builder.Services.AddScoped<IUserHelper, UserHelper>();
//builder.Services.AddScoped<SeedDb>();//la inyecta cada que lo nesecita y la destruye cuando la deja de usar
//builder.Services.AddSingleton<SeedDb>();//Lo inyecta una vez y no lo destruye lo deja en memoria
builder.Services.AddScoped<ICombosHelper, CombosHelper>();//se inyectan los datos del combo
builder.Services.AddScoped<IBlobHelper, BlobHelper>();//inyeccion para correo
builder.Services.AddScoped<IMailHelper, MailHelper>();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
var app = builder.Build();
SeedData();
void SeedData()
{
    //Para hacer inyecciones a mano
    IServiceScopeFactory? scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (IServiceScope? scope = scopedFactory.CreateScope())
    {
        SeedDb? service = scope.ServiceProvider.GetService<SeedDb>();
        service.SeedAsync().Wait();
    }
}
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/error/{0}");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
