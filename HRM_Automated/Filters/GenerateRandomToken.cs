using HRM_Automated.Services;
using Microsoft.Extensions.Configuration;

namespace HRM_Automated.Filters
{
	public static class GenerateRandomToken
	{
		private static readonly IConfiguration configuration;
		public static string  RandomToken()
		{
			var jwt = new JwtService(configuration);
			var token = jwt.GenerateSecurityToken("digitalKenth@gmail.com"); // this to be changed to the user's
			return token;
		}
	}
}
