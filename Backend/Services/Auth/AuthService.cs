using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Backend.DAL.Auth;
using Backend.DAL.Entities;
using Backend.Services.Context;
using Backend.Services.Repositories;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace Backend.Services.Auth;

public class AuthService : IAuthService
{
	private AuthOptions AuthOptions { get; }
	private ITimeLimitedDataProtector TimeLimitedDataProtector { get; }
	private FirstCusrHelpAppContext DbContext { get; }
	private IUserRepository _userRepository { get; }

	public AuthService(IOptions<AuthOptions> authOptions,
		IDataProtectionProvider dataProtectionProvider,
		IUserRepository userRepository,
		FirstCusrHelpAppContext dbContext)
	{
		AuthOptions = authOptions.Value;
		TimeLimitedDataProtector = dataProtectionProvider
			.CreateProtector("auth")
			.ToTimeLimitedDataProtector();

		_userRepository = userRepository;
		DbContext = dbContext;
	}

	public string RegisterUser(UserInput input)
	{
		var user = DbContext.Users?.FirstOrDefault(u => u.Email == input.Email);
		if (user == null)
		{
			_userRepository.CreateUser(DbContext, input.Email, input.Password);
		}
		else
			throw new Exception(message: "user with such Email is already exists");

		return AuthorizeUser(new UserInput()
		{
			Email = input.Email,
			Password = input.Password
		});
	}

	public string AuthorizeUser(UserInput input)
	{
		var user = DbContext.Users?.FirstOrDefault(u => u.Email == input.Email);
		
		if (user == null) throw new Exception(message:"User is not registrated");
		if(user.Password != input.Password) throw new Exception(message:"wrong Password or Email");
		
		var handler = new JsonWebTokenHandler();
		var accessToken = handler.CreateToken(new SecurityTokenDescriptor
		{
			Claims = new Dictionary<string, object>
			{
				[JwtRegisteredClaimNames.Email] = input.Email,
				[JwtRegisteredClaimNames.CHash] = input.Password,
				[JwtRegisteredClaimNames.Sub] = user?.Id ?? throw new InvalidDataException()
			},
			Issuer = AuthOptions.Issuer,
			Audience = AuthOptions.Audience,
			Expires = DateTime.Now.AddMinutes(15),
			TokenType = "Bearer",
			SigningCredentials = new SigningCredentials(
				AuthOptions.GetSymmetricSecurityKey(),
				SecurityAlgorithms.HmacSha256)
		});

		return accessToken;
	}
}