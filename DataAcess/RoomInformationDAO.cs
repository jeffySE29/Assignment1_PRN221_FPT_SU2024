using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class RoomInformationDAO
    {
        private static RoomInformationDAO instance = null;
        private static object lockObject = new object();
        private FUMiniHotelManagementContext db = new FUMiniHotelManagementContext();

        private RoomInformationDAO() { }

        public static RoomInformationDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RoomInformationDAO();
                }
                return instance;
            }
        }

        //lấy thông tin all phòng for admin
        public List<RoomInformation> GetAllRoomInformation()
        {
            return db.RoomInformations.Include(f => f.RoomType).ToList();
        }

        //lấy thông tin all phòng for customer
        public List<RoomInformation> GetAllActiveRoomInformation()
        {
            return db.RoomInformations.Include(f => f.RoomType).Where(m => m.RoomStatus != 2).ToList();
        }

        public RoomInformation? GetRoomInformationByRoomId(int roomId)
        {
            return db.RoomInformations.Include(f => f.RoomType).SingleOrDefault(m => m.RoomId == roomId);
        }

        //thêm RoomInformation
        public void SaveRoomInformation(RoomInformation ri)
        {
            db.RoomInformations.Add(ri);
            db.SaveChanges();
        }

        //Cập nhật thông tin RoomInformation
        public void UpdateRoomInformation(RoomInformation ri)
        {
            db.RoomInformations.Update(ri);
            db.SaveChanges();
        }

        //xóa RoomInformation
        public void DeleteRoomInformation(RoomInformation ri)
        {
            var foundedRoom = db.RoomInformations.SingleOrDefault(m => m.RoomId == ri.RoomId);
            db.RoomInformations.Remove(foundedRoom);
            db.SaveChanges();
        }
    }
}
