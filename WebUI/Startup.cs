using Business.Abstract;
using Business.Concrete;
using Core.DataAccess.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Context;
using Entities.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI
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
            services.AddControllersWithViews();

            services.AddDbContext<WofranDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("WofranConnectionString")));

            services.AddIdentity<AppUser, AppRole>(x =>
            {
                x.Password.RequireDigit = true;
                x.Password.RequiredLength = 6;
                x.Password.RequireLowercase = true;
                x.Password.RequireNonAlphanumeric = true;
                x.Password.RequireUppercase = true;
            }).AddEntityFrameworkStores<WofranDbContext>();

            services.AddScoped<IJobSeekerDAL, JobSeekerDAL>();
            services.AddScoped<IEducationDAL, EducationDAL>();
            services.AddScoped<IJobSeekerService, JobSeekerManager>();
            services.AddScoped<IEducationService, EducationManager>();

            services.ConfigureApplicationCookie(x =>
            {
                //Login olacağım url path
                x.LoginPath = new PathString("/User/Login");

                //cookie tutulma süresi
                x.ExpireTimeSpan = TimeSpan.FromDays(1);
                x.SlidingExpiration = true;

                x.Cookie = new CookieBuilder
                {
                    Name = "UserCookie",
                    SecurePolicy = CookieSecurePolicy.Always,
                    HttpOnly = true
                };
            });

            services.AddAuthentication();

            services.AddControllers().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
