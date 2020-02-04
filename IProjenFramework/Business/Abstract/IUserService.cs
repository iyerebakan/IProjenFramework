using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<List<OperationClaim>> GetClaims(User user);
        Task Add(User user);
        Task<User> GetByMail(string email);
    }
}
