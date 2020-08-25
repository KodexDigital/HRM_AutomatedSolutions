using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace HRM_Automated.Services
{
	public class JwtService
	{
		private readonly string SecretKey;
		private readonly string ExpiringDate;
		public JwtService(IConfiguration configuration)
		{
			SecretKey = configuration.GetSection("JwtBearerConfig").GetSection("SecretKey").Value;
			ExpiringDate = configuration.GetSection("JwtBearerConfig").GetSection("ExpirationInMinutes").Value;
		}

		public string GenerateSecurityToken(string email)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var _key = Encoding.UTF8.GetBytes(SecretKey);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[]
				{
					new Claim(ClaimTypes.Email, email),
				}),
				Expires = DateTime.UtcNow.AddMinutes(double.Parse(ExpiringDate)),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha256Signature),
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}


//I am passing in an email to the function, GenerateSecurityToken(string email) and storing that email in the token. 
//You could pass in some a user object GenerateSecurityToken(User user) for example and store a lot more information by adding new claims. 
//This way you don't need to take trips to the DB to get that data, when the user makes a call into the system.
//public string GenerateSecurityToken(User user)
//{
//	...    
//		Subject = new ClaimsIdentity(new[]
//		{
//			new Claim(ClaimTypes.Email, user.Email),
//			new Claim(ClaimTypes.Name, user.Name),
//			new Claim(ClaimTypes.Role, user.Role),
//			new Claim(ClaimTypes.DateOfBirth, user.DOB),
//		})...    
//}