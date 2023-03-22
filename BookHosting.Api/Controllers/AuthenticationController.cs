using BookHosting.Application.Services.Authentication;
using BookHosting.Contracts.Authentication;

using Microsoft.AspNetCore.Mvc;

namespace BookHosting.Api.Controllers;

[ApiController]
[Route("[Controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [Route("register")]
    [HttpPost]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authenticationService.Register(request.Email, request.FirstName, request.LastName, request.Password);

        if (authResult.IsSuccess)
        {
            var authResponse = new AuthenticationResponse(authResult.Value.user.Id,
                                                    authResult.Value.user.Email,
                                                    authResult.Value.user.FirstName,
                                                    authResult.Value.user.LastName,
                                                    authResult.Value.token);
            return Ok(authResponse);

        }

        return Problem(statusCode: StatusCodes.Status409Conflict, detail: "adfsgfdgh");

    }


    [Route("login")]
    [HttpPost]
    public IActionResult Login(LoginRequest request)
    {

        var authResult = _authenticationService.Login(request.Email, request.Password);

        if (authResult.IsSuccess)
        {
            var authResponse = new AuthenticationResponse(authResult.Value.user.Id,
                                                          authResult.Value.user.Email,
                                                          authResult.Value.user.FirstName,
                                                          authResult.Value.user.LastName,
                                                          authResult.Value.token);

        }

        return Problem(statusCode: StatusCodes.Status401Unauthorized, detail: "fuck off not allowed");

    }






}