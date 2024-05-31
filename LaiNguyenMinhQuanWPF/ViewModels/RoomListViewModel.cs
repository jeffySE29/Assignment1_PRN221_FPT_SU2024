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

    public class RoomListViewModel : INotifyPropertyChanged
    {
        IRoomInfoRepo roomInfoRepo = new RoomInfoRepo();
        private ObservableCollection<RoomInformation> roomInfoList;

        public ObservableCollection<RoomInformation> RoomInfoList
        {
            get { return roomInfoList; }
            set
            {
                roomInfoList = value;
                OnPropertyChanged(nameof(RoomInfoList));
            }
        }

        private string userRole;

        public string UserRole
        {
            get { return userRole; }
            set
            {
                userRole = value;
                OnPropertyChanged(nameof(UserRole));
                LoadRoomList(); // Load lại danh sách phòng khi thay đổi vai trò
            }
        }

        public RoomListViewModel(string role)
        {
            UserRole = role;
            LoadRoomList();
        }

        private void LoadRoomList()
        {
            if (UserRole == "Admin")
            {
                RoomInfoList = new ObservableCollection<RoomInformation>(roomInfoRepo.GetAllRoomInformation());
            }
            else
            {
                RoomInfoList = new ObservableCollection<RoomInformation>(roomInfoRepo.GetAllActiveRoomInformation());
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
