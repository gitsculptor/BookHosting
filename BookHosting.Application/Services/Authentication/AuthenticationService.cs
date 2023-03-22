using BookHosting.Application.Common.Interfaces.Authentication;
using BookHosting.Application.Common.Interfaces.Persistence;
using BookHosting.Application.Exceptions;
using BookHosting.Domain.Entities;
using BookHosting.Domain.Exceptions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookHosting.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenrator;
        private readonly IUserRepository _userRepository;


        public AuthenticationService(IJwtTokenGenerator jwtTokenGenrator, IUserRepository userRepository)
        {
            _jwtTokenGenrator = jwtTokenGenrator;
            _userRepository = userRepository;
        }

        public AuthenticationResult Login(string email, string password)
        {
            User? user = _userRepository.GetUserByEmail(email);

            if(user is null)
            {
                // return Result.Fail<AuthenticationResult>(errorMessage:"User does not Exists");
                throw new ResourceNotFoundException("User Not Found");
            }

            if(user.Password !=password)
            {
                // return Result.Fail<AuthenticationResult>(errorMessage:"Invalid password");
                throw new AccessDeniedException("Invalid Passowrd");
            }

            var token = _jwtTokenGenrator.GenerateToken(user);

            return new AuthenticationResult(user,token);

        }

        public AuthenticationResult Register(string email, string firstName, string lastName, string password)
        {

            //check if already exist
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                throw new ResourceAlreadyExistsException("User already Exists");
            }

            //Create User in database (userId)

            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            _userRepository.Add(user);


            //Generate Token 

            var token = _jwtTokenGenrator.GenerateToken(user);


            return new AuthenticationResult(user, token);
        }

       
    }

    
}
