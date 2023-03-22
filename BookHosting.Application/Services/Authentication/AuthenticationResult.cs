using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHosting.Domain.Entities;

namespace BookHosting.Application.Services.Authentication
{
    public record AuthenticationResult
    (User user,
        string token
        
        );

}
