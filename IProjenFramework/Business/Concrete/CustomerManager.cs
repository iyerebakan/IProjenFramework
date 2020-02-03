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
        public IResult Add(Customer customer)
        {
            try
            {
                string[] array = new string[] { "Türkiye", "Almanya", "Avusturya" };

                _repositoryCustomer.Insert(customer);
                _repositoryCustomer.Insert(customer);
                _repositoryCustomer.Insert(customer);
                
                foreach (var item in array)
                {
                    _repositoryCountry.Insert(new Country
                    {
                        Name = item
                    });
                }
                customer.Code = "lenovo";
                _repositoryCustomer.Update(customer);

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
                    (_repositoryCustomer.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Customer>>(ex.Message);
            }
        }

    }
}
