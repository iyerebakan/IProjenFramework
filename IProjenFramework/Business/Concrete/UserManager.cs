using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly RepositoryUser _repositoryUser;
        public UserManager(RepositoryUser repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }
        public void Add(User user)
        {
            _repositoryUser.Insert(user);
        }

        public User GetByMail(string email)
        {
            return _repositoryUser.Get(k => k.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _repositoryUser.GetClaims(user);
        }
    }
}
