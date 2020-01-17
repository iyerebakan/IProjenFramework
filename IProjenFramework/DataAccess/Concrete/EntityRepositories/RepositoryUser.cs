using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityRepositories
{
    public class RepositoryUser : RepositoryBase<int, User>
    {
        public List<OperationClaim> GetClaims(User user)
        {
            return this.Context.UserOperationClaims.Where(k => k.UserId == user.Id).Select(g => new OperationClaim
            {
                Id = g.OperationClaimId,
                Name = g.OperationClaim.Name
            }).ToList();
        }
    }
}
