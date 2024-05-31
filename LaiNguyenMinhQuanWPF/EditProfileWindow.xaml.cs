using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace LaiNguyenMinhQuanWPF
{
    /// <summary>
    /// Interaction logic for EditProfileWindow.xaml
    /// </summary>
    public partial class EditProfileWindow : Window
    {
        private int customerId;
        ICustomerRepo customerRepo = new CustomerRepo();
        public EditProfileWindow(int customerId)
        {
            this.customerId = customerId;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Regex regex = new Regex(@"^\d{10}$");
                Regex emailRegex = new Regex(@"^[a-zA-Z0-9]");

                if (txtFullName.Text.Trim() == "")
                {
                    MessageBox.Show("Full Name is required!");
                }
                else if (txtPhone.Text.Trim() == "" || !regex.IsMatch(txtPhone.Text))
                {
                    MessageBox.Show("Phone is required and contains 10 digits!");
                }
                else if (txtPass.Text.Trim() == "")
                {
                    MessageBox.Show("Password is required!");
                }
                else if (dpBirthday.Text.Trim() == "" || dpBirthday.SelectedDate >= DateTime.Now)
                {
                    MessageBox.Show("BirthDate is required and cannot exceed the present time");
                }
                else
                {
                    var customerUpdate = customerRepo.GetCustomerById(customerId);
                    customerUpdate.CustomerFullName = txtFullName.Text;
                    customerUpdate.CustomerBirthday = dpBirthday.SelectedDate;
                    customerUpdate.Password = txtPass.Text;

                    customerRepo.UpdateCustomer(customerUpdate);
                    this.Hide();
                    CustomerWindow w = new CustomerWindow(customerId);
                    w.Show();
                    this.Close();
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Error when update profile: " + ex.Message, "Edit Profile Window");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CustomerWindow w = new CustomerWindow(customerId);
            w.Show();
            this.Close();
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            try
            {
                var customer = customerRepo.GetCustomerById(customerId);
                txtFullName.Text = customer.CustomerFullName;
                txtEmail.Text = customer.EmailAddress;
                txtPhone.Text = customer.Telephone;
                txtPass.Text = customer.Password;
                dpBirthday.SelectedDate = customer.CustomerBirthday;
                txtEmail.IsEnabled = false;
                txtPhone.IsEnabled = false;
            }catch(Exception ex)
            {
                MessageBox.Show("Error when load customer's profile: " + ex.Message, "Edit Profile Window");
            }
        }
    }
}
