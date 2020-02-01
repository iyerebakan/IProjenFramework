using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Concrete;
using Entities.Entities.EntityUser;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        public void Add(User user)
        {
            Repositories.RepositoryUser.Insert(user);
        }

        public User GetByMail(string email)
        {
            return Repositories.RepositoryUser.Get(k => k.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return Repositories.RepositoryUser.GetClaims(user);
        }
    }
}
