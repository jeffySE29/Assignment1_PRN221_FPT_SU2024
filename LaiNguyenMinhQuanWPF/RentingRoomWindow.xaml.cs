using BusinessObjects;
using Repositories;
using System;
using System.Collections;
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
    /// Interaction logic for RentingRoomWindow.xaml
    /// </summary>
    public partial class RentingRoomWindow : Window
    {
        private int customerId;
        IRoomTypeRepo typeRepo = new RoomTypeRepo();
        IBookingDetailsRepo detailsRepo = new BookingDetailsRepo();
        IBookingReservationRepo bookingReservationRepo = new BookingReservationRepo();

        private List<RoomInformation> roomToRent = new List<RoomInformation>();
        private List<RoomType> roomType = new List<RoomType>();
        private decimal? finalTotalPrice = 0;

        public RentingRoomWindow(int customerId, List<RoomInformation> rooms)
        {
            this.customerId = customerId;
            this.roomToRent = rooms;
            InitializeComponent();
        }

        private void UpdateTotal()
        {
            try
            {
                decimal? totalPriceOneDay = 0;
                for (int i = 0; i < roomToRent.Count; i++)
                {
                    totalPriceOneDay += roomToRent[i].RoomPricePerDay;
                }

                DateTime start = dpStartday.SelectedDate ?? DateTime.MinValue;
                DateTime end = dpEndday.SelectedDate ?? DateTime.MinValue;

                TimeSpan difference = end.Subtract(start);
                int totalDays = (int)difference.TotalDays;
                int duration = totalDays + 1;

                lbTotal.Content = "Total: " + totalPriceOneDay * duration + " $";
                finalTotalPrice = totalPriceOneDay * duration;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when update total price: " + ex.Message, "Renting Room Window");
            }
        }
        private void btnRent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime presentTime = DateTime.Now;
                DateTime start;
                DateTime end;
                List<int> roomIdsToRent = new List<int>();
                if (dpStartday.SelectedDate != null && dpEndday.SelectedDate != null)
                {
                    start = (DateTime)dpStartday.SelectedDate;
                    end = (DateTime)dpEndday.SelectedDate;
                    if(start < presentTime || end < presentTime)
                    {
                        MessageBox.Show("Start day or end day cannot before present", "Renting Room Window");
                    }else if(start <= end)
                    {
                        for (int i = 0; i < roomToRent.Count; i++)
                        {
                            if (detailsRepo.IsRoomOccupied(start, end, roomToRent[i].RoomId) == true)
                            {
                                MessageBox.Show("Room ID " + roomToRent[i].RoomId + " is occupied from " + start + " to " + end + " please choose another room or start/end day", "Renting Room Window");
                            }
                            else
                            {
                                //MessageBox.Show("Room free: " + roomToRent[i].RoomId);
                                roomIdsToRent.Add(roomToRent[i].RoomId);
                            }
                        }

                        if (roomToRent.Count == roomIdsToRent.Count)
                        {
                            //MessageBox.Show("CHeck point1");
                            var bookingHistory = new BookingReservation
                            {
                                BookingDate = DateTime.Now,
                                TotalPrice = finalTotalPrice,
                                CustomerId = customerId,
                                BookingStatus = 1
                            };
                            //MessageBox.Show("CHeck point2");

                            int bookingId = bookingReservationRepo.SaveBookingReservation(bookingHistory);
                            //MessageBox.Show("id " + bookingId);
                            for (int i = 0; i < roomToRent.Count; i++)
                            {
                                var rentingDetail = new BookingDetail
                                {
                                    BookingReservationId = bookingId,
                                    RoomId = roomToRent[i].RoomId,
                                    StartDate = start,
                                    EndDate = end,
                                    ActualPrice = roomToRent[i].RoomPricePerDay
                                };
                                detailsRepo.SaveBookingDetail(rentingDetail);
                            }
                            //MessageBox.Show("CHeck point3");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Start day cannot after end day", "Renting Room Window");
                    }

                }
                else
                {
                    MessageBox.Show("Start day, End day are required", "Renting Room Window");
                }
    
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error when renting room: " + ex.Message, "Renting Room Window");
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
                
                int defaultRoomTypeId = roomToRent[0].RoomTypeId;
                //lấy mặc định cái type của selected room đầu tiên show ra
                roomType.Add(typeRepo.GetRoomTypeByRoomTypeId(defaultRoomTypeId));
                lvSelectedRoom.ItemsSource = roomToRent;
                lvTypeDetails.ItemsSource = roomType;
                lbTotal.Content = "Total: 0 $";
            }catch(Exception ex)
            {
                MessageBox.Show("Error when load selected renting room: " + ex.Message, "Renting Room Window");
            }
        }

        private void lvSelectedRoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                roomType.Clear();
                RoomInformation selectedRoom = lvSelectedRoom.SelectedItem as RoomInformation;
                if (selectedRoom != null)
                {
                    roomType.Add(typeRepo.GetRoomTypeByRoomTypeId(selectedRoom.RoomTypeId));
                }
                lvTypeDetails.ItemsSource = null; // Reset the ItemsSource
                lvTypeDetails.ItemsSource = roomType;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error when load selected room: " + ex.Message, "Renting Room Window");
            }
        }

        private void dpStart_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if(dpStartday.SelectedDate != null && dpEndday.SelectedDate != null)
                {
                    if (dpStartday.SelectedDate > dpEndday.SelectedDate)
                    {
                        MessageBox.Show("Start day cannot after end day", "Renting Room Window");
                    }
                    else
                    {
                        UpdateTotal();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when select start date: " + ex.Message, "Renting Room Window");
            }
        }

        private void dpEndday_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dpStartday.SelectedDate != null && dpEndday.SelectedDate != null)
                {
                    if (dpEndday.SelectedDate < dpStartday.SelectedDate)
                    {
                        MessageBox.Show("End day cannot before start day", "Renting Room Window");
                    }
                    else
                    {
                        UpdateTotal();
                    }
                } 
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error when select end date: " + ex.Message, "Renting Room Window");
            }
        }
    }
}
