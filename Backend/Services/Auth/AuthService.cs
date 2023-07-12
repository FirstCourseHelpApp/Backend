using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Backend.DAL.Auth;
using Backend.DAL.Entities;
using Backend.Services.Context;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Services.Auth;

public class AuthService : IAuthService
{
	private AuthOptions AuthOptions { get; }
	private ITimeLimitedDataProtector TimeLimitedDataProtector { get; }
	private FirstCusrHelpAppContext DbContext { get; }
	private HttpClient _httpClient;

	public AuthService(IOptions<AuthOptions> authOptions,
		IDataProtectionProvider dataProtectionProvider,
		FirstCusrHelpAppContext dbContext,
		HttpClient httpClient)
	{
		AuthOptions = authOptions.Value;
		TimeLimitedDataProtector = dataProtectionProvider
			.CreateProtector("auth")
			.ToTimeLimitedDataProtector();

		_httpClient = httpClient;

		DbContext = dbContext;
	}

	public string RegisterUser(UserInput input)
	{
		var user = DbContext.Users?.FirstOrDefault(u => u.Email == input.Email);
		if (user == null)
		{
			user = DbContext.Users?.Add(new User 
			{
				Id = Guid.NewGuid(),
				Email = input.Email,
				Password = input.Password,
				IsActive = true
			}).Entity;
			DbContext.SaveChanges();
		}
		else
			throw new Exception(message: "user with such Email is already exists");

		return AuthorizeUser(new TokenInput()
		{
			Email = input.Email,
			Password = input.Password,
			EncryptedCode = string.Empty
		});
	}

	public string AuthorizeUser(TokenInput tokenInput)
	{
		var user = DbContext.Users?.FirstOrDefault(u => u.Email == tokenInput.Email);
		if (user == null)
		{
			throw new Exception(message:"wrong Password or Email/User is not registrated");
		}

		var claims = new List<Claim>
		{
			new Claim(ClaimTypes.Email, user.Email),
			new Claim(ClaimTypes.Hash, user.Password),
			new Claim(ClaimTypes.Name, user.Id.ToString())
		};

		var jwt = new JwtSecurityToken(
			issuer: AuthOptions.Issuer,
			audience: AuthOptions.Audience,
			claims: claims,
			expires:DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
			signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
				SecurityAlgorithms.HmacSha256)
		);

		return new JwtSecurityTokenHandler().WriteToken(jwt);
	}
}