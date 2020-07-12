using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace WebApplication2
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
            //Step1 :-Plugging the check in to pipeline
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {

                        options.TokenValidationParameters = new TokenValidationParameters
                        {

                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = "finishingschool",
                            ValidAudience = "finishingschool",
                            IssuerSigningKey = new
                            SymmetricSecurityKey(Encoding.UTF8.GetBytes("238420983409284098230949"))

                        };
                });


            services.AddSession(options =>
            {
                options.Cookie.Name = ".Praful";
                options.IdleTimeout = TimeSpan.FromMinutes(1);
                options.Cookie.IsEssential = true;
            });
            //add services
           

            services.AddMvc();
           
            services.AddCors(o=>o.AddPolicy("AllowOriginRule",Builder =>{
                Builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
             }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Step 2:- Put here as well. use that service
            app.UseAuthentication();
            //configure the services
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
           
            app.UseHttpsRedirection();
            app.UseStaticFiles();
     
            app.UseCookiePolicy();
            app.UseCors("AllowOriginRule");
            
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                name: "ufurl1",
                template: "company/register",
                defaults: new {controller="Home" ,action="Index"});

                

            });
            
        }
    }
}
