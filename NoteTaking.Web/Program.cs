using Microsoft.EntityFrameworkCore;
using NoteTaking.Data;
using NoteTaking.Services;
using NoteTaking.Services.Interfaces;
using NoteTaking.Services.Mapping;

namespace NoteTaking.Web;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<NoteTakingContext>(opt =>
            opt.UseSqlServer(connectionString));

        builder.Services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile<NoteTakingProfile>();
        });

        builder.Services.AddTransient<INoteService, NoteService>();

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
    }
}