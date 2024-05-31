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
    
    public class BookingHistoryViewModel : INotifyPropertyChanged
    {
        IBookingReservationRepo bookingReservationRepo = new BookingReservationRepo();
        private ObservableCollection<BookingReservation> bookingHistoryList;

        public ObservableCollection<BookingReservation> BookingHistoryList
        {
            get { return bookingHistoryList; }
            set
            {
                
                bookingHistoryList = value;
                OnPropertyChanged(nameof(BookingHistoryList));
            }
        }

        public BookingHistoryViewModel(int cusId)
        {
            BookingHistoryList = new ObservableCollection<BookingReservation>(bookingReservationRepo.GetBookingReservationsByCusID(cusId));
        }

        public BookingHistoryViewModel()
        {
            BookingHistoryList = new ObservableCollection<BookingReservation>(bookingReservationRepo.GetAllBookingReservation());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
