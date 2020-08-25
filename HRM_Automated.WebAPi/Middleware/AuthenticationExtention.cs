using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HRM_Automated.WebAPi.Middleware
{
	public static class AuthenticationExtention
	{
		public static IServiceCollection AddTokenAuthentication(this IServiceCollection services, IConfiguration configuration)
		{
			var _secretKey = configuration.GetSection("JwtBearerConfig").GetSection("SecretKey").Value;
			var _key = Encoding.UTF8.GetBytes(_secretKey);
			services.AddAuthentication(auth =>
			{
				auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(bearer => {
				bearer.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidIssuer = configuration.GetSection("Auth_APi").GetSection("Issuer").Value,
					ValidAudience = configuration.GetSection("Auth_APi").GetSection("Audience").Value,
					IssuerSigningKey = new SymmetricSecurityKey(_key)
				};
			});

			return services;
		}
	}
}
