using BusinessObjects;
using DataAccessObjects;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System.Net.WebSockets;

namespace DataAccess
{
    public class CustomerDAO
    {
        private static CustomerDAO instance = null;
        private static object lockObject = new object();
        private FUMiniHotelManagementContext db = new FUMiniHotelManagementContext();

    private CustomerDAO() { }

        public static CustomerDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomerDAO();
                }
                return instance;
            }
        }
        public Customer? CheckLogin(string email, string password)
        {
            return db.Customers.SingleOrDefault(m => m.EmailAddress == email && m.Password == password);
        }

        public Boolean CheckDupEmail(string email) {
            if (db.Customers.SingleOrDefault(m => m.EmailAddress == email) != null)
            {
                return true;
            }
            else
                return false;
        }

        public Boolean CheckDupPhone(string phone)
        {
            if (db.Customers.SingleOrDefault(m => m.Telephone == phone) != null)
            {
                return true;
            }
            else
                return false;
        }

        public List<Customer> GetAllCustomers()
        {
            return db.Customers.ToList();
        }

        public Customer? GetCustomerById(int id)
        {
            var temp = GetAllCustomers().SingleOrDefault(m => m.CustomerId == id);
            return temp;
        }

        public Customer? GetCustomerByName(string cusName)
        {
            var temp = GetAllCustomers().SingleOrDefault(m => m.CustomerFullName == cusName);
            return temp;
        }

        //thêm customer
        public void SaveCustomer(Customer c)
        {
            db.Customers.Add(c);
            db.SaveChanges();
        }

        //Cập nhật thông tin customer
        public void UpdateCustomer(Customer c)
        {
            db.Customers.Update(c);
            db.SaveChanges();
        }

        //xóa Cus
        public void DeleteCustomer(Customer c)
        {
            var foundedCustomer = db.Customers.SingleOrDefault(m => m.CustomerId == c.CustomerId);
            db.Customers.Remove(foundedCustomer);
            db.SaveChanges();
        }
    }
}
