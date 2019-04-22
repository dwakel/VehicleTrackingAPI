using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Gps.Core;
using Gps.Core.EF;
using Microsoft.EntityFrameworkCore;
using Gps.Core.Filters;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Gps.Api.Settings;
using Gps.Core.Services;
using AutoMapper;
using Gps.Api.Service;
using SendGrid;

namespace Gps.Api
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
            //services.AddCors();
            services.AddDbContext<GpsContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("GpsConnection")));
            //services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            //{
            //    builder
            //    .AllowAnyMethod()
            //    .AllowAnyHeader()
            //    .WithOrigins("http://localhost:4200");
            //}));

            services.AddSignalR();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAutoMapper();
            //Add database seeding task
            services.AddStartupTask<SeedStartupFilter>();

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            services.AddTransient<ITokenService, TokenService>();

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            //var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            // services.AddAuthentication(x =>
            // {
            //     x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //     x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            // })
            // .AddJwtBearer(x =>
            // {
            //     x.Events = new JwtBearerEvents
            //     {
            //         OnTokenValidated = context =>
            //         {
            //             var userService = context.HttpContext.RequestServices.GetRequiredService<GpsContext>();
            //             var userId = int.Parse(context.Principal.Identity.Name);
            //             var user = userService.Users.FindAsync(userId);
            //             if (user == null)
            //             {
            //                 // return unauthorized if user no longer exists
            //                 context.Fail("Unauthorized");
            //             }
            //             return Task.CompletedTask;
            //         }
            //     };
            //     x.RequireHttpsMetadata = false;
            //     x.SaveToken = true;
            //     x.TokenValidationParameters = new TokenValidationParameters
            //     {
            //         ValidateIssuerSigningKey = true,
            //         IssuerSigningKey = new SymmetricSecurityKey(key),
            //         ValidateIssuer = false,
            //         ValidateAudience = false
            //     };
            // });

            // configure DI for application services
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            var client = new SendGridClient(Configuration["SendGrid:ApiKey"]);
            services.AddSingleton<SendGridClient>(client);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseCors(x => x
            //    .AllowAnyOrigin()
            //    .AllowAnyMethod()
            //    .AllowAnyHeader());

            app.UseCors(builder => builder
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
            );

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseSignalR(routes =>
                routes.MapHub<LocationHub>("/location")
            );
            app.UseMvc();
        }
    }
}