using Microsoft.EntityFrameworkCore;
using NoteTaking.Data;
using NoteTaking.Services;
using NoteTaking.Services.Interfaces;
using NoteTaking.Services.Mapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using NoteTaking.Web.Common;
using Microsoft.AspNetCore.Authentication.Facebook;

namespace NoteTaking.Web;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();

        var connectionString = builder.Configuration.GetConnectionString("DockerConnection");
        builder.Services.AddDbContext<NoteTakingContext>(opt =>
            opt.UseSqlServer(connectionString));
        
        builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders()
                .AddEntityFrameworkStores<NoteTakingContext>();

        builder.Services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile<NoteTakingProfile>();
        });

        builder.Services.AddTransient<INoteService, NoteService>();
        builder.Services.AddTransient<IUserService, UserService>();
        builder.Services.AddSingleton<IEmailSender, EmailSender>();

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
        app.UseAuthentication();

        app.UseAuthorization();
        app.MapRazorPages();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=index}/{id?}");

        app.Run();
    }
}