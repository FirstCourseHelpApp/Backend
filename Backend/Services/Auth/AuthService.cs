using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Backend.DAL.Auth;
using Backend.DAL.Entities;
using Backend.Services.Context;
using Backend.Services.Repositories;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

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