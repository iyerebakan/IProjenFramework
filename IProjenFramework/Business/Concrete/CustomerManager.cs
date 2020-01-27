using Business.Abstract;
using Business.BusinessAspects;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Concrete;
using EntityCustomer.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [SecuredOperation("Customer.List,Admin")]
        public IDataResult<List<Customer>> GetCustomers()
        {
            try
            {
                return new SuccessDataResult<List<Customer>>
                    (Repositories.RepositoryCustomer.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Customer>>(ex.Message);
            }
        }

    }
}
