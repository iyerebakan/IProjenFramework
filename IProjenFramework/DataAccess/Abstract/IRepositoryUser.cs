using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRepositoryUser
    {
        List<OperationClaim> GetClaims(User user);
    }
}
