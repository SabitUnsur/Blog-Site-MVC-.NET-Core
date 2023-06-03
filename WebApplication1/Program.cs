using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

    config.Filters.Add(new AuthorizeFilter(policy));

});


builder.Services.AddSession();

builder.Services.AddMvc();

builder.Services.ConfigureApplicationCookie(opts =>
{
    //Cookie settings
    opts.Cookie.HttpOnly = true;
    opts.ExpireTimeSpan = TimeSpan.FromMinutes(100);
    opts.AccessDeniedPath = new PathString("/Login/AccessDenied/");
    opts.LoginPath = "/Login/Index/";
    opts.SlidingExpiration = true;
});


builder.Services.AddIdentity<AppUser, AppRole>()

    /* x.Password.RequireUppercase = false;
     x.Password.RequireNonAlphanumeric = false;*/ //Identity þifre girme zorunluluk kurallarý icin

    .AddEntityFrameworkStores<Context>()
    .AddDefaultTokenProviders();


builder.Services.AddAuthentication(

    CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
    {
        x.LoginPath = "/Login/Index/";

    });

/*
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<Context>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("Context")));*/

builder.Services.AddEntityFrameworkNpgsql()
  .AddDbContext<Context>()
  .BuildServiceProvider();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAuthentication();

AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
              );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
