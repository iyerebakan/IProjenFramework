using Business.Abstract;
using Business.BusinessAspects;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Caching;
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
        public CustomerManager(RepositoryCustomer repositoryCustomer)
        {
            _repositoryCustomer = repositoryCustomer;
        }

        [ValidationAspect(typeof(CustomerValidator), Priority = 1)]
        [CacheRemoveAspect("getcustomers")]
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
        [CacheAspect(Priority = 1)]
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

        public async Task<IDataResult<Customer>> GetById(int id)
        {
            try
            {
                return new SuccessDataResult<Customer>
                    (await _repositoryCustomer.GetById(id));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Customer>(ex.Message);
            }
        }
    }
}
