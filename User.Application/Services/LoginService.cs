using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Exceptions;
using User.Domain;

namespace User.Application.Services;

public class LoginService
{
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IUserRepository _userRepository;
    public LoginService(IJwtTokenService jwtTokenService, IUserRepository userRepository)
    {
        _jwtTokenService = jwtTokenService;
        _userRepository = userRepository;
    }
    public async Task<string> Login(LoginRequest request)
    {
        var user = await _userRepository.GetByUsernameAsync(request.Username);
        if (user == null || !user.VerifyPassword(request.Password))
        {
            throw new InvalidCredentialsException();
        }
        var token = _jwtTokenService.GenerateToken(user.Id, user.Roles);
        return token;
    }
}
