using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Standard.DAL.Admin.IRepos;
using System.Standard.DAL.Admin.Repos;
using System.Standard.DAL.APIRepos;
using System.Standard.DAL.Data;
using System.Threading.Tasks;
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
			services.AddControllers(options =>
			{
				options.RespectBrowserAcceptHeader = true;
				options.EnableEndpointRouting = true;
			})
				.AddNewtonsoftJson(options =>
				{
					options.SerializerSettings.ContractResolver = new DefaultContractResolver();
					options.SerializerSettings.Formatting = Formatting.Indented;
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
			services.AddSwaggerGen();
			services.AddSwaggerGenNewtonsoftSupport();
			services.AddScoped(typeof(IAdminRepository<>), typeof(AdminRepository<>));
			services.AddScoped(typeof(IWrapper), typeof(Wrapper));
			services.AddScoped<EmployeeRepo>();
			services.AddScoped<ApplicationDBContext>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseExceptionHandler("/error-local-development");
			}
			//else
			//{
			//	app.UseExceptionHandler("/error");
			//}

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "GSNetwork Info Bank");
			});

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
