using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAllCustomers();
        IDataResult<List<Customer>> GetCustomerById(int id);
        IResult AddCustomer(Customer customer);
        IResult DeleteCustomer(Customer customer);
        IResult UpdateCustomer(Customer customer);
    }
}
