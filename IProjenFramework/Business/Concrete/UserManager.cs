using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly RepositoryUser _repositoryUser;
        public UserManager(RepositoryUser repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }
        public async Task Add(User user)
        {
            await _repositoryUser.Insert(user);
        }

        public async Task<User> GetByMail(string email)
        {
            return await _repositoryUser.Get(k => k.Email == email);
        }

        public async Task<List<OperationClaim>> GetClaims(User user)
        {
            return await _repositoryUser.GetClaims(user);
        }
    }
}
