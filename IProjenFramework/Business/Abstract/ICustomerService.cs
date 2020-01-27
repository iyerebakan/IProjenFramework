using Core.Utilities.Results;
using EntityCustomer.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult DeleteById(int id);
        IDataResult<List<Customer>> GetCustomers();
    }
} 
