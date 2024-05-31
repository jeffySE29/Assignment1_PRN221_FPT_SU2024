using BusinessObjects;
using DataAccess;
using DataAccessObjects;

namespace Repositories
{
    public class CustomerRepo : ICustomerRepo
    {
        public Customer? CheckLogin(string email, string password)
            => CustomerDAO.Instance.CheckLogin(email, password);

        public List<Customer> GetAllCustomers()
            => CustomerDAO.Instance.GetAllCustomers();

        public Customer? GetCustomerById(int id)
            => CustomerDAO.Instance.GetCustomerById(id);

        public Customer? GetCustomerByName(string cusName)
            => CustomerDAO.Instance.GetCustomerByName(cusName);

        public void SaveCustomer(Customer c)
            => CustomerDAO.Instance.SaveCustomer(c);

        public void UpdateCustomer(Customer c)
            => CustomerDAO.Instance.UpdateCustomer(c);

        public void DeleteCustomer(Customer c)
            => CustomerDAO.Instance.DeleteCustomer(c);

        public Boolean CheckDupEmail(string email)
            => CustomerDAO.Instance.CheckDupEmail(email);

        public Boolean CheckDupPhone(string phone)
            => CustomerDAO.Instance.CheckDupPhone(phone);
    }
}
