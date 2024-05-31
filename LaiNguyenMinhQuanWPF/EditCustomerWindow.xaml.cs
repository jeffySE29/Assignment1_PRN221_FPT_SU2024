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
using BusinessObjects;
using Repositories;

namespace LaiNguyenMinhQuanWPF
{
    /// <summary>
    /// Interaction logic for EditCustomerWindow.xaml
    /// </summary>
    public partial class EditCustomerWindow : Window
    {
        ICustomerRepo customerRepo = new CustomerRepo();
        private Customer? customer;
        public EditCustomerWindow()
        {
            InitializeComponent();
        }

        public EditCustomerWindow(Customer customer)
        {
            this.customer = customer;
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminWindow w = new AdminWindow();
            w.Show();
            this.Close();
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            try
            {
                if(customer != null)
                {
                    txtStatus.IsEnabled = true;
                    txtPassword.IsEnabled = false;
                    txtEmail.IsEnabled = false;
                    txtPhone.IsEnabled = false;
                    txtName.Text = customer.CustomerFullName;
                    txtEmail.Text = customer.EmailAddress;
                    txtPhone.Text = customer.Telephone;
                    txtStatus.Text = customer.CustomerStatus.ToString();
                    txtPassword.Text = "******";
                    dpBirth.SelectedDate = customer.CustomerBirthday;
                }
                else
                {
                    txtStatus.IsEnabled = false;
                    txtStatus.Text = "1";
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Error when load edit customer window: " + ex.Message, "Edit Customer Window");
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Regex regex = new Regex(@"^\d{10}$");
                Regex emailRegex = new Regex(@"^[a-zA-Z0-9]");

                if (txtName.Text.Trim() == "")
                {
                    MessageBox.Show("Full Name is required!");
                }
                else if (txtPhone.Text.Trim() == "" || !regex.IsMatch(txtPhone.Text))
                {
                    MessageBox.Show("Phone is required and contains 10 digits!");
                }
                else if (customerRepo.CheckDupPhone(txtPhone.Text.Trim()) == true && customer == null)
                {
                    MessageBox.Show("Phone number is obtained by other people, please choose other");
                }
                else if (!txtEmail.Text.EndsWith("@FUMiniHotel.org") || !emailRegex.IsMatch(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Email must begin with character or digits and must end with \"@FUMiniHotel.org\"!");
                }
                else if (customerRepo.CheckDupEmail(txtEmail.Text.Trim()) == true && customer == null)
                {
                    MessageBox.Show("Email is obtained by other people, please choose other");
                }
                else if (txtPassword.Text.Trim() == "")
                {
                    MessageBox.Show("Password is required!");
                }
                else if (dpBirth.Text.Trim() == "" || dpBirth.SelectedDate >= DateTime.Now)
                {
                    MessageBox.Show("BirthDate is required and cannot exceed the present time");
                }
                else if (txtStatus.Text.Trim() != "1" && txtStatus.Text.Trim() != "2")
                {
                    MessageBox.Show("Status must be 1 (Active) or 2 (Unactive)!");
                }
                else
                {                  
                    if(customer != null)
                    {
                        var customerUpdate = customerRepo.GetCustomerById(customer.CustomerId);
                        customerUpdate.CustomerFullName = txtName.Text;
                        customerUpdate.CustomerBirthday = DateTime.Parse(dpBirth.Text);
                        customerUpdate.CustomerStatus = byte.Parse(txtStatus.Text);
                        customerUpdate.EmailAddress = txtEmail.Text;
                        customerUpdate.Telephone = txtPhone.Text;                       
                        customerRepo.UpdateCustomer(customerUpdate);
                    }
                    else
                    {
                        var cusInfo = new Customer
                        {
                            CustomerFullName = txtName.Text,
                            CustomerBirthday = DateTime.Parse(dpBirth.Text),
                            CustomerStatus = 1,
                            Telephone = txtPhone.Text,
                            EmailAddress = txtEmail.Text,
                            Password = txtPassword.Text
                        };
                        customerRepo.SaveCustomer(cusInfo);
                    }
                    this.Hide();
                    AdminWindow w = new AdminWindow();
                    w.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when save customer: " + ex.Message, "Edit Customer Window");
            }
        }
    }
}
