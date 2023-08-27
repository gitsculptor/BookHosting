using BookHosting.Application.Exceptions;
using BookHosting.Application.Services.Authentication;
using BookHosting.Contracts.Authentication;
using BookHosting.Domain;
using BookHosting.Domain.Exceptions;
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
    public ActionResult<AuthenticationResult> Register(RegisterRequest request)
    {
        try
        {
            var authResult = _authenticationService.Register(request.Email, request.FirstName, request.LastName, request.Password);

            return Created("", new OkResponse<AuthenticationResult>()
            {
                Result = authResult,
                StatusCode=StatusCodes.Status201Created,
                Message="Account Created Successfully"
            });

        }
        catch (ResourceAlreadyExistsException ex)
        {
            return Conflict(new OkResponse<string>()
            {
                Result=ex.Message,
                StatusCode=StatusCodes.Status400BadRequest
            });

        }


    }


    [Route("login")]
    [HttpPost]
    public IActionResult Login(LoginRequest request)
    {

        try
        {
            var authResult = _authenticationService.Login(request.Email, request.Password);
            var authResponse = new AuthenticationResponse(authResult.user.Id,
                                                          authResult.user.Email,
                                                          authResult.user.FirstName,
                                                          authResult.user.LastName,
                                                          authResult.token);
            return Ok(new OkResponse<AuthenticationResponse>()
            {
                Result=authResponse,
                Message="Login Success",
                StatusCode=StatusCodes.Status200OK

            });

        }
        catch (ResourceNotFoundException ex)
        {
            return Conflict(new OkResponse<string>()
            {
                Result = ex.Message,
                StatusCode = StatusCodes.Status400BadRequest
            });

        }
        catch(AccessDeniedException ex)
        {
            return Conflict(new OkResponse<string>()
            {
                Result = ex.Message,
                StatusCode = StatusCodes.Status401Unauthorized
            });
        }
        

        

    }






}