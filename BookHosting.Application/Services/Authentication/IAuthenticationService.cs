using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHosting.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        Result<AuthenticationResult> Login(string username, string password);
        Result<AuthenticationResult> Register(string email,string firstName,string lastName, string password);
    }
}
