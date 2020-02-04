using Business.Abstract;
using Business.BusinessAspects;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityRepositories;
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
        private readonly RepositoryCustomer _repositoryCustomer;
        private readonly RepositoryCountry _repositoryCountry;
        public CustomerManager(RepositoryCustomer repositoryCustomer
            ,RepositoryCountry repositoryCountry)
        {
            _repositoryCustomer = repositoryCustomer;
            _repositoryCountry = repositoryCountry;
        }

        [ValidationAspect(typeof(CustomerValidator), Priority = 1)]
        public async Task<IResult> Add(Customer customer)
        {
            try
            {
                await _repositoryCustomer.Insert(customer);
                return new SuccessResult("Müşteri başarıyla kaydedildi.!");
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }
        }

        public async Task<IResult> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> Update(Customer customer)
        {
            throw new NotImplementedException();
        }

        [SecuredOperation("Customer.List,Admin")]
        public async Task<IDataResult<List<Customer>>> GetCustomers()
        {
            try
            {
                return new SuccessDataResult<List<Customer>>
                    (await _repositoryCustomer.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Customer>>(ex.Message);
            }
        }

    }
}
