using HRM_Automated.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTest_HRM_Automated.API
{
	public class TokenTest
	{
		[Fact]
		public void Generate_Random_Token()
		{
			var token = GenerateRandomToken.RandomToken();
			Assert.NotNull(token);
		}


	}
}
