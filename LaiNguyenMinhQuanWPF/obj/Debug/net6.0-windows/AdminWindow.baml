   M S B A M L   `   `   `  ����O  KLaiNguyenMinhQuanWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:LaiNguyenMinhQuanWPFLaiNguyenMinhQuanWPF  5   	   &     LaiNguyenMinhQuanWPF.AdminWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:LaiNguyenMinhQuanWPF     5   	     � Title$  AdminWindow��5   	   $	��870��6   $	��800��6*   .��5	      � -   5         �Name$ WindowAdmin��5	      .+�5
   
   �� -   5         ��Name$ lbCustomerList��5
      $��Customer List��6(   $
��Left=�6@   $��	29,89,0,0q�6[   $	��Top=�6n   $
��Bold"�6�   �� 5   
   -   5        $ 
lbRoomList��5      $��Room Information List��6$   $
��Left=�6D   $��
405,89,0,0q�6_   $	��Top=�6s   $
��Bold"�6�   �� 5   
   -   5        $ lbTotal��5      $��Total:��6!   $
��Left=�62   $��545,428,0,0q�6M   $	��Top=�6b   $
��Bold"�6z   �� 5   
   -   5        $ lbStart��5      $��	Start Day��6!   $
��Left=�65   $��
29,428,0,0q�6P   $	��Top=�6d   $
��Bold"�6|   �� 5   
   -   5        $ 	lbEnd_Day��5      $��End Day��6#   $
��Left=�65   $��288,428,0,0q�6P   $	��Top=�6e   $
��Bold"�6}   �� 5   
   -   5         ��Name$ 
lvCustomer��5      $��29,115,402,552q�6L    �� SelectionMode$ Single=�6d   $ �� IsSynchronizedWithCurrentItem$ FalseY�6{   ��6'   �� *CustomerList+ �� View 5      �� 5      .P�5      �� $��Customer ID��6%    �� DisplayMemberBinding 6:   �� *
CustomerId+�� 5      $��Customer Full Name��6%    6A   �� *CustomerFullName+�� 5      $��	Telephone��6%    68   �� *	Telephone+�� 5      $��Email Address��6%    6<   �� *EmailAddress+�� 5      $��Customer Birthday��6%    6@   �� *CustomerBirthday+�� 5      $��Customer Status��6%    6>   �� *CustomerStatus+5      5      �� 5   
   -   5        $ 
lvRoomInfo��5      $��405,115,26,552q�6L   $ Single=�6d   $ FalseY�6{   ��6'   �� *RoomInfoList+ 5      �� 5      .P�5      �� $��Room ID��6%    66   �� *RoomId+�� 5      $��Room Number��6%    6:   �� *
RoomNumber+�� 5       $��Room Detail Description��6%    6F   �� *RoomDetailDescription+�� 5!      $��Room Max Capacity��6%    6@   �� *RoomMaxCapacity+�� 5"      $��	Room Type��6%    68   �� *RoomType.RoomTypeName+�� 5#      $��Room Status��6%    6:   �� *
RoomStatus+�� 5$      $��Room Price Per Day��6%    6A   �� *RoomPricePerDay+5%      5'      �� 5(   
   -	   5        $ lbTitle��5(      $��ADMIN WINDOW��6!   $
��Left=�68   $��
249,22,0,0q�6S   $	��Top=�6g   $
��Bold"�6   $��Arial)�6�   $��38(�6�   �� 5)   
   -
   5        $ lvBookingStatistic��5)      $��29,458,32,51q�6Z   $ FalseY�6p   ��6/   �� *BookingHistoryList+ 5*      �� 5+      .P�5,      �� $��Booking Reservation ID��6%    6E   �� *BookingReservationId+�� 5-      $��Booking Date��6%    6;   �� *BookingDate+�� 5.      $��Total Price��6%    6:   �� *
TotalPrice+�� 5/      $��Customer��6%    67   �� *
CustomerId+�� 50      $��Booking Status��6%    6=   �� *BookingStatus+51      53      �� 54   
   -   5        $ lbStatisticSection��54      $:��4Please choose start day, end day to make a statistic��6,   $
��Left=�6k   $��
29,402,0,0q�6�   $	��Top=�6�   $��Italic$�6�   �� 55   
   -   5         ��Name$ btnCreateRoom��55      $��Create Room��6(   $
��Left=�6>   $��408,352,0,0q�6Y   $	��Top=�6n   $	��103��6�   �� 56   
   -   5        $ btnUpdateRoom��56      $��Update Room��6(   $
��Left=�6>   $��538,352,0,0q�6Y   $	��Top=�6n   $	��103��6�   �� 57   
   -   5        $ btnDeleteCustomer��57      $��Delete Customer��6,   $
��Left=�6F   $��288,352,0,0q�6a   $	��Top=�6v   $	��103��6�   �� 58   
   -   5        $ 	btnLogOut��58      $��Log Out��6$   $
��Left=�66   $��
718,74,0,0q�6Q   $	��Top=�6e   $��50��6}   6�   (  "System.Windows.Controls.DatePicker  59   
   -   5        	  Name$	 dpStart��59      $
��Left=�6&   $��104,428,0,0q�6A   $	��Top=�6V   $	��170��6n   6z     5:   
   -   5        $	 dpEnd��5:      $
��Left=�6$   $��356,428,0,0q�6?   $	��Top=�6T   $	��170��6l   6x   �� 5;   
   -   5        $ btnCreateCustomer��5;      $��Create Customer��6,   $
��Left=�6F   $��
31,352,0,0q�6a   $	��Top=�6u   $	��103��6�   6�   �� 5<   
   -   5        $ btnUpdateCustomer��5<      $��Update Customer��6,   $
��Left=�6F   $��158,352,0,0q�6a   $	��Top=�6v   $	��103��6�   �� 5=   
   -   5        $ btnDeleteRoom��5=      $��Delete Room��6(   $
��Left=�6>   $��665,352,0,0q�6Y   $	��Top=�6n   $	��103��6�   5>      5?      