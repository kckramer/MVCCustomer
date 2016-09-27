using MVCCustomer.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MVCCustomer.Services
{
    public interface ICustomerData
    {
        IEnumerable<Customer> GetAll();
        Customer Get(int id);
        bool Add(Customer newCustomer);
        int Commit();
    }

    public class CustomerData : ICustomerData
    {
        private CustomerDbContext _context;

        public CustomerData(CustomerDbContext context)
        {
            _context = context;
        }

        public bool Add(Customer newCustomer)
        {
            if (_context.Customers.Any(x => x.Email == newCustomer.Email))
            {
                return false;
            }

            _context.Add(newCustomer);

            return true;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public Customer Get(int id)
        {
            return _context.Customers.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }
    }
}
