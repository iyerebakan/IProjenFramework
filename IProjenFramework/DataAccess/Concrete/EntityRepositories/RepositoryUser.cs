using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityRepositories
{
    public class RepositoryUser : RepositoryBase<int, User>
    {
        public Task<List<OperationClaim>> GetClaims(User user)
        {
            return this.Context.UserOperationClaims.Where(k => k.UserId == user.Id)
                .Select(g => new OperationClaim
            {
                Id = g.OperationClaimId,
                Name = g.OperationClaim.Name
            }).ToListAsync();

        }
    }
}
