using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using prueba.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using prueba.Models;
using ZooLine;
using AutoMapper;
using ZooLine.Models;
using ZooLine.Services;
using ZooLine.Utilities;
using ZooLine.Hubs;
namespace prueba
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<Usuario>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            services.AddAuthentication()
                    .AddGoogle(options =>
                    {
                        options.ClientId = Configuration["App:GoogleClientId"];
                        options.ClientSecret = Configuration["App:GoogleClientSecret"];
                    })
                    .AddFacebook(options =>
                    {
                        options.AppId=Configuration["App:FacebookClientId"];
                        options.ClientSecret = Configuration["App:FacebookClientSecret"];
                    });
            services.AddSignalR();
            services.Configure<SmtpSettings>(Configuration.GetSection("SmtpSettings"));
            services.AddSingleton < IEmailSenderService, EmailSenderService>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddScoped<UserManager<Usuario>>();
            services.AddScoped(typeof(SignInManager<>));
            services.AddScoped(typeof(UserManager<>));
            services.AddAutoMapper(typeof(AutoMapperSetup));
            services.AddTransient<IMailHandler, MailHandler> ();  
            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Mision}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapHub<ChatHub>("/chatHub");
            });

        }
    }
}
