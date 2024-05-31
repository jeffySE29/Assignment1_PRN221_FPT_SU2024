using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObjects;

namespace Repositories
{
    public class RoomInfoRepo : IRoomInfoRepo
    {
        public List<RoomInformation> GetAllRoomInformation()
            => RoomInformationDAO.Instance.GetAllRoomInformation();

        public RoomInformation? GetRoomInformationByRoomId(int roomId)
            => RoomInformationDAO.Instance.GetRoomInformationByRoomId(roomId);

        public void SaveRoomInformation(RoomInformation ri)
            => RoomInformationDAO.Instance.SaveRoomInformation(ri);

        public void UpdateRoomInformation(RoomInformation ri)
            => RoomInformationDAO.Instance.UpdateRoomInformation(ri);

        public void DeleteRoomInformation(RoomInformation ri)
            => RoomInformationDAO.Instance.DeleteRoomInformation(ri);

        public List<RoomInformation> GetAllActiveRoomInformation()
            => RoomInformationDAO.Instance.GetAllActiveRoomInformation();
    }
}
