using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelBinding.Models
{
    public interface IRepository
    {
        List<Customer> Customers {get;}
        Customer Get(int customerId);
    }

    public class Repository : IRepository
    {
        private List<Customer> _customers;
        public Repository()
        {
            _customers = new List<Customer>()
            {
                new Customer() { CustomerId=1, FirstName="Ali", LastName="Yılmaz", Role=Role.Admin},
                new Customer() { CustomerId=2, FirstName="Ahmet", LastName="Bahçe", Role=Role.Member},
                new Customer() { CustomerId=3, FirstName="Ayşe", LastName="Bahçıvan", Role=Role.User},
                new Customer() { CustomerId=4, FirstName="Fatma", LastName="Tekin", Role=Role.User}
            };
        }

        public List<Customer> Customers => _customers;

        public Customer Get(int customerId)
        {
            return _customers.FirstOrDefault(i=>i.CustomerId==customerId);
        }
    }
}