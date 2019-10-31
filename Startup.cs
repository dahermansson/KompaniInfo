﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using KompaniInfo.Models;
using KompaniInfo.Repositories.Interfaces;
using KompaniInfo.Repositories;
using Microsoft.AspNetCore.Routing;
using System.Globalization;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace KompaniInfo
{
	public class Startup
	{
		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();

			Configuration = builder.Build();
		}

		public IConfigurationRoot Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
      services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(o => o.LoginPath = new PathString("/Login/Index/"));
			services.AddMvc(config =>
			{
				var policy = new AuthorizationPolicyBuilder()
				   .RequireAuthenticatedUser()
				   .Build();
				config.Filters.Add(new AuthorizeFilter(policy));
			});

			services.AddSingleton<IConfiguration>(Configuration);

			services.AddDbContext<KompaniInfoContext>(options =>
					options.UseSqlServer(Configuration["Data:KompaniInfoContext:ConnectionString"]));

			services.AddScoped<IPostRepository, PostRepository>();
			services.AddScoped<ISidaRepository, SidaRepository>();
			services.AddScoped<IFilRepository, FilRepository>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseBrowserLink();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				using (var context = new KompaniInfoContext(app.ApplicationServices.GetRequiredService<DbContextOptions<KompaniInfoContext>>()))
				{
					context.Database.Migrate();
				}
			}
            var supportedCultures = new[] { new CultureInfo("sv-SE") };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("sv-SE"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

			app.UseStaticFiles();
      		app.UseAuthentication();

			app.UseMvc(routes =>
				{
					routes.MapRoute(
						name: "sidor",
						template: "Sida/{id:int}",
						defaults: new { controller = "Sida", action = "Index" });
					routes.MapRoute(
						name: "poster",
						template: "Post/{id:int}",
						defaults: new { controller = "Post", action = "Index" });
					routes.MapRoute(
						name: "default",
						template: "{controller=Home}/{action=Index}/{id?}");
				});
		}
	}
}
