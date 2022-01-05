namespace MyFirstWeb
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.AspNetCore.Http;
    using MyFirstWeb.Data;
    using MyFirstWeb.ModelBinders;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using MyFirstWeb.Models;

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
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = new TimeSpan(365, 0, 0, 0);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;

            });

            // User & Identity

            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);



            })
                .AddRoles<IdentityRole>() // to use RoleManager
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllersWithViews(configure =>
            {
                configure.ModelBinderProviders.Insert(0, new ExtractYearModelBinderProvider());
                configure.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });
            
            //configure =>
            //{
            //    //global filter configuration
            //    
            //    configure.Filters.Add(new AddHeaderActionFilterAttribute());
            //    configure.Filters.Add(new MyAthorizationFilter());
            //    configure.Filters.Add(new MyExceptionFilterAttribute());
            //    configure.Filters.Add(new MyResourceFilter());
            //    configure.Filters.Add(new MyResultFilterAttirbute());
            //
            //});

            services.Configure<CookiePolicyOptions>(options => 
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddRazorPages();
        }

            
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePagesWithRedirects("/Home/StatusCodeError?errorCode={0}");
                //app.UseStatusCodePagesWithReExecute("/Home/StatusCodeError", "errorCode={0}");
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();
            app.UseRouting();
            
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:"areas", 
                    pattern:"{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
