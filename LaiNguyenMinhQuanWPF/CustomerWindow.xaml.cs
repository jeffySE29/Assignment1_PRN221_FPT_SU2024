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
using LaiNguyenMinhQuanWPF.ViewModels;
using BusinessObjects;

namespace LaiNguyenMinhQuanWPF
{
    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    /// 
    
    public partial class CustomerWindow : Window
    {
        private int customerId;
        ICustomerRepo customerRepo = new CustomerRepo();
        IBookingReservationRepo bookingReservationRepo = new BookingReservationRepo();
        IRoomInfoRepo roomInfoRepo = new RoomInfoRepo();
       
        private List<RoomInformation> roomToRent = new List<RoomInformation>();

        public CustomerWindow(int customerId)
        {
            this.customerId = customerId;
            InitializeComponent();
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            try
            {
                string customerName = customerRepo.GetCustomerById(customerId).CustomerFullName;
                lbHello.Content = "Welcome back! " + customerName;
                LoadRentHistory();
                LoadRoomList();
            }catch(Exception ex)
            {
                MessageBox.Show("Error when load customer window: " + ex.Message, "Customer Window");
            }
        }

        public void LoadRentHistory()
        {
            try
            {
                //customer status 1 = active | 2 = deleted
                //booking status không mô tả rõ thế thì quy định 1 là xong | 2 là chưa xong
                //1 = active | 2 = deleted
                BookingHistoryViewModel bookingHistory = new BookingHistoryViewModel(customerId);
                if (bookingHistory.BookingHistoryList == null || bookingHistory.BookingHistoryList.Count == 0)
                {
                    MessageBox.Show("Booking list is empty", "Customer Window");
                }

                lvRentHistory.DataContext = bookingHistory;
                lvRentHistory.ItemsSource = bookingHistory.BookingHistoryList;
                lvRentHistory.IsManipulationEnabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error when load rent history: " + ex.Message, "Customer Window");
            }
        }

        public void LoadRoomList()
        {
            try
            {
             
                //room status 1 = active | 2 = deleted
                RoomListViewModel roomList = new RoomListViewModel("Customer");
                if (roomList.RoomInfoList == null || roomList.RoomInfoList.Count == 0)
                {
                    MessageBox.Show("Room list is empty", "Customer Window");
                }

                lvRoomList.DataContext = roomList;
                lvRoomList.ItemsSource = roomList.RoomInfoList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when load room list: " + ex.Message, "Customer Window");
            }
        }

        private void btnRentRoom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (roomToRent.Count == 0 || roomToRent == null)
                {
                    MessageBox.Show("Nothing to rent! Please pick a room");
                    return;
                }
                else
                {
                    this.Hide();
                    RentingRoomWindow w = new RentingRoomWindow(customerId, roomToRent);
                    w.Show();
                    this.Close();
                }                
            }catch(Exception ex)
            {
                MessageBox.Show("Error when renting process: " + ex.Message, "Customer Window");
            }
        }

        private void btnEditProfile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Hide();
                EditProfileWindow w = new EditProfileWindow(customerId);
                w.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when edit profile: " + ex.Message, "Customer Window");
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LoginWindow w = new LoginWindow();
            w.Show();
            this.Close();
        }

        private void lvRoomList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                roomToRent.Clear();

                //them cac row dc chon vao list
                foreach (var selectedItem in lvRoomList.SelectedItems)
                {
                    RoomInformation selectedRoom = selectedItem as RoomInformation;
                    if (selectedRoom != null)
                    {
                        roomToRent.Add(selectedRoom);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error when load data from selected rows: " + ex.Message, "Customer Window");
            }
        }
    }
}
