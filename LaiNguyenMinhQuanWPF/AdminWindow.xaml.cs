using BusinessObjects;
using LaiNguyenMinhQuanWPF.ViewModels;
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

namespace LaiNguyenMinhQuanWPF
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        ICustomerRepo customerRepo = new CustomerRepo();
        IBookingReservationRepo bookingReservationRepo = new BookingReservationRepo();
        IBookingDetailsRepo bookingDetailsRepo = new BookingDetailsRepo();
        IRoomInfoRepo roomInfoRepo = new RoomInfoRepo();

        private Customer? customerToUpdate = null;
        private RoomInformation? roomToUpdate = null;

        private decimal? finalTotal = 0;
        public AdminWindow()
        {
            InitializeComponent();
        }


        private void Load(object sender, RoutedEventArgs e)
        {
            try
            {
                lbTotal.Content = "Total: 0 $";
                LoadCusList();
                LoadRoomList();
                LoadBookingList();
            }catch(Exception ex)
            {
                MessageBox.Show("Error when load admin window: " + ex.Message, "Admin Window");
            }
        }

        private void LoadCusList()
        {
            try
            {
                CustomerListViewModel cusList = new CustomerListViewModel();
                if(cusList.CustomerList == null || cusList.CustomerList.Count == 0)
                {
                    MessageBox.Show("CustomerList is empty", "Admin Window");
                }
                lvCustomer.DataContext = cusList;
                lvCustomer.ItemsSource = cusList.CustomerList;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error when load customer list: " + ex.Message, "Admin Window");
            }
        }

        private void LoadRoomList()
        {
            try
            {
                RoomListViewModel roomList = new RoomListViewModel("Admin");
                if (roomList.RoomInfoList == null || roomList.RoomInfoList.Count == 0)
                {
                    MessageBox.Show("Room list is empty", "Admin Window");
                }
                lvRoomInfo.DataContext = roomList;
                lvRoomInfo.ItemsSource = roomList.RoomInfoList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when load room list: " + ex.Message, "Admin Window");
            }
        }

        private void LoadBookingList()
        {
            try
            {
                BookingHistoryViewModel bookingList = new BookingHistoryViewModel();
                if (bookingList.BookingHistoryList == null || bookingList.BookingHistoryList.Count == 0)
                {
                    MessageBox.Show("Booking list is empty", "Admin Window");
                }
                lvBookingStatistic.DataContext = bookingList;
                lvBookingStatistic.ItemsSource = bookingList.BookingHistoryList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when load booking reservation list: " + ex.Message, "Admin Window");
            }
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LoginWindow w = new LoginWindow();
            w.Show();
            this.Close();
        }

        private void dpStart_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dpStart.SelectedDate != null && dpEnd.SelectedDate != null)
                {
                    if (dpStart.SelectedDate > dpEnd.SelectedDate)
                    {
                        MessageBox.Show("Start day cannot after end day", "Admin Window");
                    }
                    else
                    {
                        UpdateTotal();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when select start date: " + ex.Message, "Admin Window");
            }
        }

        private void dpEnd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dpStart.SelectedDate != null && dpStart.SelectedDate != null)
                {
                    if (dpEnd.SelectedDate < dpStart.SelectedDate)
                    {
                        MessageBox.Show("End day cannot before start day", "Admin Window");
                    }
                    else
                    {
                        UpdateTotal();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when select start date: " + ex.Message, "Admin Window");
            }
        }

        private void UpdateTotal()
        {
            try
            {
                finalTotal = 0;
                HashSet<BookingReservation> reservationsStatistic = new HashSet<BookingReservation>();
                DateTime start;
                DateTime end;
                if (dpStart.SelectedDate != null && dpEnd.SelectedDate != null)
                {
                    start = (DateTime)dpStart.SelectedDate;
                    end = (DateTime)dpEnd.SelectedDate;
                    if (start <= end)
                    {
                        List<BookingDetail> details = bookingDetailsRepo.BookingReservationIDListInDuration(start, end);
                        if (details == null || details.Count == 0)
                        {
                            MessageBox.Show("There are no booking reservations from " + start + " to " + end, "Admin Window");
                        }
                        else
                        {
                            for (int i = 0; i < details.Count; i++)
                            {
                                //nhớ đổi lại appsetting trước khi nộp
                                BookingReservation temp = bookingReservationRepo.GetBookingReservationsByID(details[i].BookingReservationId);
                                if (!reservationsStatistic.Contains(temp))
                                {
                                    reservationsStatistic.Add(temp);
                                    finalTotal += temp.TotalPrice;
                                }
                            }
                            lvBookingStatistic.ItemsSource = null;
                            lvBookingStatistic.ItemsSource = reservationsStatistic.OrderByDescending(reservation => reservation.TotalPrice).ToList();
                            lbTotal.Content = "Total: " + finalTotal + " $";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Start day cannot be after end day", "Admin Window");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when updating total price: " + ex.Message, "Admin Window");
            }
        }


        //Customer
        private void btnCreateCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Hide();
                EditCustomerWindow w = new EditCustomerWindow();
                w.Show();
                this.Close();
            }catch(Exception ex)
            {
                MessageBox.Show("Error in creating customer process: " + ex.Message, "Admin Window");
            }
        }

        private void btnUpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(customerToUpdate == null)
                {
                    MessageBox.Show("Choose a customer you want to update first", "Admin Window");
                }
                else
                {
                    this.Hide();
                    EditCustomerWindow w = new EditCustomerWindow(customerToUpdate);
                    w.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in updating customer process: " + ex.Message, "Admin Window");
            }
        }

        private void btnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(customerToUpdate == null)
                {
                    MessageBox.Show("Choose a customer you want to delete first", "Admin Window");
                }
                else
                {
                    List<BookingReservation> bookedList = bookingReservationRepo.GetBookingReservationsByCusID(customerToUpdate.CustomerId);
                    if(bookedList.Count != 0)
                    {
                        bool isDeletable = false;
                        for (int i = 0; i < bookedList.Count; i++)
                        {
                            if(bookingDetailsRepo.IsDeletable(bookedList[i].BookingReservationId) == true)
                            {
                                isDeletable = true;
                                break;
                            }                           
                        }
                        if(isDeletable == true)
                        {
                            //nhớ thêm confirm box
                            MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete the customer for {customerToUpdate.CustomerFullName}?",
                                                              "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

                            if (result == MessageBoxResult.Yes)
                            {
                                customerRepo.DeleteCustomer(customerToUpdate);
                            }
                            LoadCusList();
                        }
                        else
                        {
                            MessageBox.Show("Cannot delete customer " + customerToUpdate.CustomerFullName + " , because he/she has booking in the future", "Admin Window");
                        }
                    }
                    else
                    {
                        //nhớ thêm confirm box
                        MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete the customer for {customerToUpdate.CustomerFullName}?",
                                                          "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

                        if (result == MessageBoxResult.Yes)
                        {
                            customerRepo.DeleteCustomer(customerToUpdate);
                            LoadCusList();
                        }
                    }                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in deleting customer process: " + ex.Message, "Admin Window");
            }
        }

        private void lvCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Customer? selectedCustomer = lvCustomer.SelectedItem as Customer;
                if (selectedCustomer != null)
                {
                    customerToUpdate = null;
                    customerToUpdate = selectedCustomer;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when load customer selection: " + ex.Message, "Admin Window");
            }
        }

        //Room
        private void btnCreateRoom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Hide();
                EditRoomWindow w = new EditRoomWindow();
                w.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in creating room process: " + ex.Message, "Admin Window");
            }
        }

        private void btnUpdateRoom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(roomToUpdate == null)
                {
                    MessageBox.Show("Choose a room you want to update first", "Admin Window");
                }
                else
                {
                    this.Hide();
                    EditRoomWindow w = new EditRoomWindow(roomToUpdate);
                    w.Show();
                    this.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in creating room process: " + ex.Message, "Admin Window");
            }
        }

        private void btnDeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(roomToUpdate == null)
                {
                    MessageBox.Show("Choose a room you want to delete first", "Admin Window");
                }
                else
                {
                    if(bookingDetailsRepo.IsDeletableForRoom(roomToUpdate.RoomId) == true)
                    {
                        //nhớ thêm confirm box
                        MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete the room for {roomToUpdate.RoomNumber}?",
                                                          "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            roomInfoRepo.DeleteRoomInformation(roomToUpdate);
                        }
                        LoadRoomList();
                    }
                    else
                    {
                        MessageBox.Show("Cannot delete room " + roomToUpdate.RoomNumber + " , because it has been reserved in the future", "Admin Window");
                    }
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in creating room process: " + ex.Message, "Admin Window");
            }
        }

        private void lvRoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                RoomInformation? selectedRoom = lvRoomInfo.SelectedItem as RoomInformation;
                if (selectedRoom != null)
                {
                    roomToUpdate = null;
                    roomToUpdate = selectedRoom;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when load room selection: " + ex.Message, "Admin Window");
            }
        }
    }
}
