﻿using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRoomInfoRepo
    {
        public List<RoomInformation> GetAllRoomInformation();

        public RoomInformation? GetRoomInformationByRoomId(int roomId);

        public void SaveRoomInformation(RoomInformation ri);

        public void UpdateRoomInformation(RoomInformation ri);

        public void DeleteRoomInformation(RoomInformation ri);

        public List<RoomInformation> GetAllActiveRoomInformation();
    }
}
