using EfCodeFirst.Config.Encyript;
using EfCodeFirst.Share.Api.Helpers;
using EfCodeFirst.Share.Api.Interfaces.Helpers;
using EfCodeFirst.Share.Attributes;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EfCodeFirst
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

            services.AddAuthentication(opt =>
            {
                opt.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                opt.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }
            )
                .AddCookie(options =>
                    {
                        // options.LoginPath = "/login";
                        //options.Cookie.HttpOnly = true;
                        //options.Cookie.Name = "refreshToken";
                        //options.Cookie.IsEssential = true;
                        options.LogoutPath = "/logout";


                        options.AccessDeniedPath = "/accessdenied";
                        options.Events.OnRedirectToLogin = opt =>
                        {
                            opt.HttpContext.Response.Redirect("/login");
                            return Task.FromResult(0);
                        };
                    });
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            #region singleton
            services.AddSingleton<TokenAttribute>();
            services.AddMvcCore().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<IHelperLogin, HelperLogin>();
            services.AddSingleton<IHelperGet, HelperGet>();
            services.AddSingleton<IHelperGetDatas, HelperGetDatas>();
            services.AddSingleton<IHelperGetTable, HelperGetTable>();
            services.AddSingleton<IHelperRefreshToken, HelperRefreshToken>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IHelperHttpClient, HelperHttpClient>();
            services.AddSingleton<IEncyript, Encyript>();
            #endregion
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
                app.UseExceptionHandler("/Error");
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
