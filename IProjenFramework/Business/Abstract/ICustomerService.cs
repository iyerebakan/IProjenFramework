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
        Task<IResult> Add(Customer customer);
        Task<IResult> Update(Customer customer);
        Task<IResult> DeleteById(int id);
        Task<IDataResult<List<Customer>>> GetCustomers();
        Task<IDataResult<Customer>> GetById(int id);
    }
} 
