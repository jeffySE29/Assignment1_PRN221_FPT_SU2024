using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using BusinessObjects;

namespace LaiNguyenMinhQuanWPF
{
    /// <summary>
    /// Interaction logic for CustomerRegisterWindow.xaml
    /// </summary>
    public partial class CustomerRegisterWindow : Window
    {
        ICustomerRepo customerRepo = new CustomerRepo();
        public CustomerRegisterWindow()
        {
            InitializeComponent();
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
                }else if(txtPhone.Text.Trim() == "" || !regex.IsMatch(txtPhone.Text))
                {
                    MessageBox.Show("Phone is required and contains 10 digits!");
                }
                else if (customerRepo.CheckDupPhone(txtPhone.Text.Trim()) == true)
                {
                    MessageBox.Show("Phone number is obtained by other people, please choose other");
                }
                else if(!txtEmail.Text.EndsWith("@FUMiniHotel.org") || !emailRegex.IsMatch(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Email must begin with character or digits and must end with \"@FUMiniHotel.org\"!");
                }else if (customerRepo.CheckDupEmail(txtEmail.Text.Trim()) == true)
                {
                    MessageBox.Show("Email is obtained by other people, please choose other");
                }
                else if(txtPass.Text.Trim() == "")
                {
                    MessageBox.Show("Password is required!");
                }
                else if(dpBirthDate.Text.Trim() == "" || dpBirthDate.SelectedDate >= DateTime.Now)
                {
                    MessageBox.Show("BirthDate is required and cannot exceed the present time");
                }
                else
                {
                    var cusInfo = new Customer
                    {
                        CustomerFullName = txtName.Text,
                        CustomerBirthday = DateTime.Parse(dpBirthDate.Text),
                        CustomerStatus = 1,
                        Telephone = txtPhone.Text,
                        EmailAddress = txtEmail.Text,
                        Password = txtPass.Text
                    };
                    customerRepo.SaveCustomer(cusInfo);
                    this.Hide();
                    LoginWindow w = new LoginWindow();
                    w.Show();
                    this.Close();
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Error when save a new register: " + ex.Message, "Register Window");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LoginWindow w = new LoginWindow();
            w.Show();
            this.Close();
        }
    }
}
