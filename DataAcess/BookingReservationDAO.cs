using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class BookingReservationDAO
    {
        private static BookingReservationDAO instance = null;
        private static object lockObject = new object();
        private FUMiniHotelManagementContext db = new FUMiniHotelManagementContext();

        private BookingReservationDAO() { }

        public static BookingReservationDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new BookingReservationDAO();
                        }
                    }
                }
                return instance;
            }
        }

        //có thể trả ra nhiều bookingReser của 1 khách hàng
        public List<BookingReservation> GetBookingReservationsByCusID(int cusId)
        {
            return db.BookingReservations.Where(m => m.CustomerId == cusId).ToList();
        }

        public BookingReservation GetBookingReservationsByID(int bookingReservationId)
        {
            return db.BookingReservations.SingleOrDefault(m => m.BookingReservationId == bookingReservationId);
        }

        public List<BookingReservation> GetAllBookingReservation()
        {
            return db.BookingReservations.ToList();
        }

        public BookingReservation GetBookingReservation(int bookingId)
        {
            return db.BookingReservations.SingleOrDefault(m => m.BookingReservationId == bookingId);
        }

        //thêm BookingReservation
        public int SaveBookingReservation(BookingReservation br)
        {
            db.BookingReservations.Add(br);
            db.SaveChanges();
            return br.BookingReservationId;
        }

        //Cập nhật thông tin BookingReservation
        public void UpdateBookingReservation(BookingReservation br)
        {
            db.BookingReservations.Update(br);
            db.SaveChanges();
        }

        //xóa BookingReservation
        public void DeleteBookingReservation(BookingReservation br)
        {
            var foundedBookingReservation = db.BookingReservations.SingleOrDefault(m => m.BookingReservationId == br.BookingReservationId);
            db.BookingReservations.Remove(foundedBookingReservation);
            db.SaveChanges();
        }
    }
}
