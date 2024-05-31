using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;

namespace LaiNguyenMinhQuanWPF.ViewModels
{ 
    public class CustomerListViewModel : INotifyPropertyChanged
    {
        ICustomerRepo customerRepo = new CustomerRepo();
        private ObservableCollection<Customer> customerList;

        public ObservableCollection<Customer> CustomerList
        {
            get { return customerList; }
            set
            {

                customerList = value;
                OnPropertyChanged(nameof(CustomerList));
            }
        }

        public CustomerListViewModel()
        {

            CustomerList = new ObservableCollection<Customer>(customerRepo.GetAllCustomers());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
