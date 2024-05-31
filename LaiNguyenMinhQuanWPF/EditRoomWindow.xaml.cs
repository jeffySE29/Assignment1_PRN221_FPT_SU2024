using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;
using BusinessObjects;
using Repositories;

namespace LaiNguyenMinhQuanWPF
{
    /// <summary>
    /// Interaction logic for EditRoomWindow.xaml
    /// </summary>
    public partial class EditRoomWindow : Window
    {
        IRoomInfoRepo roomInfoRepo = new RoomInfoRepo();
        IRoomTypeRepo roomTypeRepo = new RoomTypeRepo();
        private RoomInformation? roomInfo;
        public EditRoomWindow()
        {
            InitializeComponent();
        }

        public EditRoomWindow(RoomInformation roomInfo)
        {
            this.roomInfo = roomInfo;
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminWindow w = new AdminWindow();
            w.Show();
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Regex regex = new Regex(@"^\d+$");
                if (txtRoomnum.Text.Trim() == "")
                {
                    MessageBox.Show("Room num is required!");
                }
                else if (txtCapacity.Text.Trim() == "" || !regex.IsMatch(txtCapacity.Text))
                {
                    MessageBox.Show("Max capacity is required!");
                }
                else if (txtDescription.Text.Trim() == "")
                {
                    MessageBox.Show("Description is required!");
                }
                else if (cbRoomType.SelectedItem == null)
                {
                    MessageBox.Show("Room type is required!");
                }
                else if (txtStatus.Text.Trim() != "1" && txtStatus.Text.Trim() != "2")
                {
                    MessageBox.Show("Status must be 1 (Active) or 2 (Unactive)");
                }
                else if (txtPrice.Text.Trim() == "")
                {
                    MessageBox.Show("Price per day is required!");
                }
                else
                {
                    if (roomInfo != null)
                    {
                        var roomInfos = new RoomInformation
                        {
                            RoomId = roomInfo.RoomId,
                            RoomNumber = txtRoomnum.Text,
                            RoomMaxCapacity = int.Parse(txtCapacity.Text),
                            RoomPricePerDay = decimal.Parse(txtPrice.Text),
                            RoomStatus = byte.Parse(txtCapacity.Text),
                            RoomDetailDescription = txtDescription.Text,
                            RoomTypeId = (int)cbRoomType.SelectedValue,
                        };
                        roomInfoRepo.UpdateRoomInformation(roomInfos);
                    }
                    else
                    {
                        var roomInfos = new RoomInformation
                        {
                            RoomNumber = txtRoomnum.Text,
                            RoomMaxCapacity = int.Parse(txtCapacity.Text),
                            RoomPricePerDay = decimal.Parse(txtPrice.Text),
                            RoomStatus = 1,
                            RoomDetailDescription = txtDescription.Text,
                            RoomTypeId = (int)cbRoomType.SelectedValue,
                        };
                        roomInfoRepo.SaveRoomInformation(roomInfos);
                    }
                    this.Hide();
                    AdminWindow w = new AdminWindow();
                    w.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when save room: " + ex.Message, "Edit Room Window");
            }
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            try
            {
                List<RoomType> typeList = roomTypeRepo.GetAllRoomType();
                if(typeList.Count == 0 || typeList == null)
                {
                    cbRoomType.ItemsSource = null;
                    MessageBox.Show("Room type list empty!", "Edit Room Window");
                }
                else
                {
                    
                    if (roomInfo != null)
                    {
                        RoomType roomType = roomTypeRepo.GetRoomTypeByRoomTypeId(roomInfo.RoomTypeId);
                        int roomUpdateIndex = 0;
                        for (int i = 0; i < typeList.Count; i++)
                        {
                            if (roomType.RoomTypeId == typeList[i].RoomTypeId)
                            {
                                roomUpdateIndex = i;
                                break;
                            }    
                        }
                        if (roomType != null)
                        {
                            txtStatus.IsEnabled = true;
                            txtRoomnum.Text = roomInfo.RoomNumber;
                            txtStatus.Text = roomInfo.RoomStatus.ToString();
                            txtCapacity.Text = roomInfo.RoomMaxCapacity.ToString();
                            txtPrice.Text = roomInfo.RoomPricePerDay.ToString();
                            txtDescription.Text = roomInfo.RoomDetailDescription;
                            cbRoomType.ItemsSource = typeList;
                            cbRoomType.DisplayMemberPath = "RoomTypeName";
                            cbRoomType.SelectedValuePath = "RoomTypeId";
                            cbRoomType.SelectedIndex = roomUpdateIndex;
                        }
                    }
                    else if (roomInfo == null)
                    {
                        txtRoomnum.Clear();
                        txtStatus.Clear();
                        txtStatus.Text = "1";
                        txtStatus.IsEnabled = false;
                        txtCapacity.Clear();
                        txtPrice.Clear();
                        txtDescription.Clear();
                        cbRoomType.SelectedItem = null;
                        cbRoomType.ItemsSource = typeList;
                        cbRoomType.DisplayMemberPath = "RoomTypeName";
                        cbRoomType.SelectedValuePath = "RoomTypeId";
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when load edit room window: " + ex.Message, "Edit Room Window");
            }
        }
    }
}
