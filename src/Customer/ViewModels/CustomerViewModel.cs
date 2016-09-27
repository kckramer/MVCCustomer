using MVCCustomer.Entities;
using System.Collections.Generic;

namespace MVCCustomer.ViewModels
{
    public class CustomerViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
    }
}
