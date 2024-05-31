using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookingDetailsRepo : IBookingDetailsRepo
    {
        public void DeleteBookingDetailBy2Id(BookingDetail bd)
         => BookingDetailsDAO.Instance.DeleteBookingDetailBy2Id(bd);

        public void DeleteBookingDetailByBookingId(int bookingId)
         => BookingDetailsDAO.Instance.DeleteBookingDetailByBookingId(bookingId);

        public void DeleteBookingDetailByRoomId(int roomId)
         => BookingDetailsDAO.Instance.DeleteBookingDetailByRoomId(roomId);

        public List<BookingDetail> GetBookingDetailsByBookingId(int bookingId)
         => BookingDetailsDAO.Instance.GetBookingDetailsByBookingId(bookingId);

        public List<BookingDetail> GetBookingDetailsByRoomId(int roomId)
         => BookingDetailsDAO.Instance.GetBookingDetailsByRoomId(roomId);

        public void SaveBookingDetail(BookingDetail bd)
         => BookingDetailsDAO.Instance.SaveBookingDetail(bd);

        public void UpdateBookingDetail(BookingDetail bd)
         => BookingDetailsDAO.Instance.UpdateBookingDetail(bd);

        public Boolean IsRoomOccupied(DateTime start, DateTime end, int roomId)
            => BookingDetailsDAO.Instance.IsRoomOccupied(start, end, roomId);

        public List<BookingDetail> BookingReservationIDListInDuration(DateTime start, DateTime end)
            => BookingDetailsDAO.Instance.BookingReservationIDListInDuration(start, end);

        public Boolean IsDeletable(int reservationId)
            => BookingDetailsDAO.Instance.IsDeletable(reservationId);

        public Boolean IsDeletableForRoom(int roomId)
            => BookingDetailsDAO.Instance.IsDeletableForRoom(roomId);
    }
}
