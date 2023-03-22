using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHosting.Contracts.Authentication
{
    public record AuthenticationResponse
    (Guid id ,String Email,String FirstName,
        String LastName
        ,
        String Token);

}
