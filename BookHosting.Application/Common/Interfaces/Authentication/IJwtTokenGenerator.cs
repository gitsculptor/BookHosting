using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHosting.Domain.Entities;

namespace BookHosting.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
