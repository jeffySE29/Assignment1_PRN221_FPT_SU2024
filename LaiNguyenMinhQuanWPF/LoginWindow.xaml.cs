using BusinessObjects;
using Microsoft.Extensions.Configuration;
using Repositories;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LaiNguyenMinhQuanWPF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        ICustomerRepo customerRepo = new CustomerRepo();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //admin
            //"Email": "admin@FUMiniHotelSystem.com",
            //"Password": "@@abc123@@"

            //cus
            //"Email": jeffy@FUMiniHotel.org
            //"Pass" : 123456@
            try
            {
                IConfiguration configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", true, true)
                            .Build();
                string adminEmail = configuration["Account:Email"];
                string adminPass = configuration["Account:Password"];

                string inputEmail = txtEmail.Text;
                string inputPass = pswPassword.Password;
                if (inputEmail == null || inputEmail == "")
                {
                    MessageBox.Show("Email is required!", "Login Window");
                }
                else if (inputPass == null || inputPass == "")
                {
                    MessageBox.Show("Password is required!", "Login Window");
                }
                else
                {
                    if (inputEmail == adminEmail && inputPass == adminPass)
                    {
                        this.Hide();
                        AdminWindow w = new AdminWindow();
                        w.Show();
                        this.Close();
                    }
                    else if (customerRepo.CheckLogin(inputEmail, inputPass) != null)
                    {
                        Customer curCustomer = customerRepo.CheckLogin(inputEmail, inputPass);
                        this.Hide();
                        CustomerWindow w = new CustomerWindow(curCustomer.CustomerId);
                        w.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Login failed. Incorrect email or password", "Login Window");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error when login: " + ex.Message, "Login");
            }

        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CustomerRegisterWindow w = new CustomerRegisterWindow();
            w.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}