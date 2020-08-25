using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Automated.Authentication.JWT
{
	public static class GenerateJwtToken
	{
		private static IConfiguration Configuration { get; }

		public static string GetToken()
		{
			var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MynameisJamesBond007"));
			var credentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);
			var jwtToken = new JwtSecurityToken(
				issuer: Configuration["Auth_APi:Issuer"],
				audience: Configuration["Auth_APi:Audience"],
				expires: DateTime.Now.AddHours(3),
				signingCredentials: credentials
				);
			return new JwtSecurityTokenHandler().WriteToken(jwtToken);
		}
	}
}
