using Core.Entities.Concrete;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager
    {
        public List<OperationClaim> GetClaims()
        {
            return Repositories.RepositoryUser.GetClaims(Repositories.Context.Users.Find(1));
        }
    }
}
