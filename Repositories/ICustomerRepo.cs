using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICustomerRepo
    {
        public Customer? CheckLogin(string email, string password);

        public List<Customer> GetAllCustomers();

        public Customer? GetCustomerById(int id);

        public Customer? GetCustomerByName(string cusName);

        public void SaveCustomer(Customer c);

        public void UpdateCustomer(Customer c);

        public void DeleteCustomer(Customer c);

        public Boolean CheckDupEmail(string email);

        public Boolean CheckDupPhone(string phone);
    }
}
