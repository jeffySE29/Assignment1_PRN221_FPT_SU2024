   M S B A M L   `   `   `  ����O  KLaiNguyenMinhQuanWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:LaiNguyenMinhQuanWPFLaiNguyenMinhQuanWPF  5   	   )    #LaiNguyenMinhQuanWPF.CustomerWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:LaiNguyenMinhQuanWPF     5   	     � Title$  CustomerWindow��5   	   $	��450��6    $	��800��6-   .��5	      � -   5         �Name$ WindowCustomer��5	      .+�5
   
   �� -   5         ��Name$ lbHello��5
      $��Hello��6!   $
��Left=�61   $��	22,27,0,0q�6L   $	��Top=�6_   $
��Bold"�6w   $��15(�6�   �� 5   
   -   5         ��Name$ btnRentRoom��5      $��Rent A Room��6&   $
��Left=�6<   $��474,388,0,0q�6W   $	��Top=�6l   $��89��6�   6�   �� 5   
   -   5        $ btnEditProfile��5      $��Edit Profile��6)   $
��Left=�6@   $��594,388,0,0q�6[   $	��Top=�6p   $��89��6�   6�   �� 5   
   -   5        $ 	btnLogout��5      $��Log Out��6$   $
��Left=�66   $��713,388,0,0q�6Q   $	��Top=�6f   $��63��6~    J� RenderTransformOrigin$ 	0.142,0.6&�6�   6�   �� 5   
   -   5         ��Name$ lvRentHistory��5      $��10,106,417,67q�6*   $ �� IsSynchronizedWithCurrentItem$ FalseY�6l   ��6A   �� *BookingHistoryList+ �� View 5      �� 5      .P�5      �� $��
Booking ID��6%    �� DisplayMemberBinding 69   �� *BookingReservationId+�� 5      $��Booking Date��6%    6;   �� *BookingDate+�� 5      $��Total Price��6%    6:   �� *
TotalPrice+�� 5      $��Booking Status��6%    6=   �� *BookingStatus+5      5      �� 5   
   -   5        $ 
lvRoomList��5      $��417,105,10,67q�6'   $ FalseY�6c   	 �� SelectionMode$	 Multiple=�6�   ��6>   �� *RoomInfoList+ 5      �� 5      .P�5      �� $��Room ID��6%    66   �� *RoomId+�� 5      $��	Room Type��6%    68   �� *RoomType.RoomTypeName+�� 5      $��Description��6%    6:   �� *RoomDetailDescription+�� 5      $��
RoomNumber��6%    69   �� *
RoomNumber+�� 5      $��Room Max Capacity��6%    6@   �� *RoomMaxCapacity+�� 5       $��Room Status��6%    6:   �� *
RoomStatus+�� 5!      $��Room Price Per Day��6%    6A   �� *RoomPricePerDay+5#      5%      �� 5&   
   -   5        $ lbRentHistory��5&      $��Rent History��6'   $
��Left=�6>   $��	10,80,0,0q�6Y   $	��Top=�6l   $
��Bold"�6�   �� 5'   
   -	   5        $ lbRooms��5'      $��	Room List��6!   $
��Left=�65   $��
417,80,0,0q�6P   $	��Top=�6d   $
��Bold"�6|   5(      5)      