using Core.Entities.Concrete;
using Core.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public interface ITokenHelper<TUser, TClaim>
        where TUser : IUser
        where TClaim : IClaim
    {
        AccessToken CreateToken(TUser user, List<TClaim> operationClaims);
    }
}
