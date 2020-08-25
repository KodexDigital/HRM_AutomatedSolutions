using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthTest.API.Middleware
{
	public static class AuthenticationExtention
	{
		public static IServiceCollection AddTokenAuthentication(this IServiceCollection services, IConfiguration config)
		{
			var _secret = config.GetSection("JwtConfig").GetSection("secret").Value;
			var _key = Encoding.UTF8.GetBytes(_secret);
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options => 
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					IssuerSigningKey = new SymmetricSecurityKey(_key),
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidIssuer = "localhost",
					ValidAudience = "localhost"
				};
			});

			return services;
		}
	}
}
