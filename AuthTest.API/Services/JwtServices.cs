using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AuthTest.API.Services
{
	public class JwtServices
	{
		private readonly string _secret;
		private readonly string _expDate;

		public JwtServices(IConfiguration configuration)
		{
			_secret = configuration.GetSection("JwtConfig").GetSection("secret").Value;
			_expDate = configuration.GetSection("JwtConfig").GetSection("expirationInMinutes").Value;
		}

		public string GenerateSecurityToken(string email)
		{
			var tokenHanlder = new JwtSecurityTokenHandler();
			var key = Encoding.UTF8.GetBytes(_secret);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[]
				{
					new Claim(ClaimTypes.Email, email)
				}),
				Expires = DateTime.UtcNow.AddMinutes(double.Parse(_expDate)),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHanlder.CreateToken(tokenDescriptor);
			return tokenHanlder.WriteToken(token);
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
	}
}
