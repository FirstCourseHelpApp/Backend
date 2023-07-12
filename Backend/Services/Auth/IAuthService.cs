using Backend.DAL.Auth;
using Backend.DAL.Entities;

namespace Backend.Services.Auth;

public interface IAuthService
{
    
    public string RegisterUser(UserInput input);

    public string AuthorizeUser(TokenInput tokenInput);
}