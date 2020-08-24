using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Standard.DAL.Admin.IRepos;
using System.Standard.DAL.Admin.Repos;
using System.Standard.DAL.APIRepos;
using System.Standard.DAL.Data;
using System.Standard.DAL.IAPIRepos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HRM_Automated.WebAPi
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
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(blocker => 
			{
				blocker.Authority = $"https://{Configuration["Auth0:Domain"]}";
				blocker.Audience = Configuration["Auth0:Audience"];
			});
			services.AddControllers(options =>
			{
				options.RespectBrowserAcceptHeader = true;
				options.EnableEndpointRouting = true;
			})
				.AddNewtonsoftJson(options =>
				{
					options.SerializerSettings.ContractResolver = new DefaultContractResolver();
					options.SerializerSettings.Formatting = Formatting.Indented;
					//options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.
				})
				.AddJsonOptions(options =>
				{
					options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
				}).ConfigureApiBehaviorOptions(cfg => // handlying model validation failures
				{
					cfg.InvalidModelStateResponseFactory = context =>
					{
						var result = new BadRequestObjectResult(context.ModelState);
						result.ContentTypes.Add(MediaTypeNames.Application.Json);
						result.ContentTypes.Add(MediaTypeNames.Application.Xml);

						return result;
					};

				});
			services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDBContext>()
					 .AddDefaultTokenProviders();
			services.AddDbContextPool<ApplicationDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ApplicationAPIDB")));
			services.AddScoped(typeof(IWrapper), typeof(Wrapper));
			services.AddScoped<EmployeeRepo>();
			services.AddScoped<ApplicationDBContext>();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",
					Title = "Human resource managment - Automated System",
					Description = "A full packed Web API for HRMS Automation",
					TermsOfService = new Uri("https://twitter.com/"),
					Contact = new OpenApiContact
					{
						Name = "Kenneth Otoro",
						Email = "kodexkenth@gmail.com",
						Url = new Uri("https://twitter.com/codexkenth"),
					},
					License = new OpenApiLicense
					{
						Name = "MIT Licensed",
						Url = new Uri("https://mit.com/license"),
					}
				});

				// Set the comments path for the Swagger JSON and UI.
				//var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				//var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				//c.IncludeXmlComments(xmlPath);
			});
		}


		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				//app.UseExceptionHandler("/error-local-development");
			}
			//else
			//{
			//	app.UseExceptionHandler("/error");
			//}

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Human resource managment - Automated System");
			});

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();
			app.UseAuthentication();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
