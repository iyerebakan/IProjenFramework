using Business.Abstract;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Concrete;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        [ValidationAspect(typeof(CustomerValidator), Priority = 1)]
        public IResult Add(Customer customer)
        {
            try
            {
                Repositories.RepositoryCustomer.Insert(customer);
                Repositories.RepositoryCustomer.Save();
                return new SuccessResult("Müşteri başarıyla kaydedildi.!");
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }
        }

        public IResult DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
