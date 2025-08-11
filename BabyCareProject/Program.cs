using BabyCareProject.DataAccess.Settings;
using BabyCareProject.Services.AboutServices;
using BabyCareProject.Services.EventServices;
using BabyCareProject.Services.FooterServices;
using BabyCareProject.Services.HeroServices;
using BabyCareProject.Services.InstructorServices;
using BabyCareProject.Services.NavbarServices;
using BabyCareProject.Services.ProductSerrvices;
using BabyCareProject.Services.ServiceServices;
using BabyCareProject.Services.SocialMediaServices;
using BabyCareProject.Services.TeamServices;
using BabyCareProject.Services.TestimonialServices;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); // Þuan içerisinde bulunduðumuz assembly'deki tüm profilleri tarar ve AutoMapper'a ekler.

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection(nameof(DatabaseSettings)));

builder.Services.AddSingleton<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

builder.Services.AddScoped<IInstructorService, InstructorService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<INavbarService, NavbarService>();
builder.Services.AddScoped<IFooterService, FooterService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IHeroService, HeroService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<ISocialMediaService, SocialMediaService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<ITestimonialService, TestimonialService>();

builder.Services.AddControllersWithViews();

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
           name: "areas",
           pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
         );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
