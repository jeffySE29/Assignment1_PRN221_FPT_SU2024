   M S B A M L   `   `   `  ����O  KLaiNguyenMinhQuanWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:LaiNguyenMinhQuanWPFLaiNguyenMinhQuanWPF  5   	   ,    &LaiNguyenMinhQuanWPF.RentingRoomWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:LaiNguyenMinhQuanWPF     5   	     � Title$  RentingRoomWindow��5   	   $	��450��6#   $	��800��60   .��5	      � -   5         �Name$ WindowRentingRoom��5	      .+�5
   
   �� -   5         ��Name$ lbTitle��5
      $��RENTING TRANSACTION��6!   $��Center=�6?   $��0,19,0,0q�6\   $	��Top=�6n   $
��Bold"�6�   $��Arial)�6�   $��38(�6�   �� 5   
   -   5        $ lbTotal��5      $��Total Price��6!   $
��Left=�67   $��414,309,0,0q�6R   $	��Top=�6g   $
��Bold"�6   �� 5   
   -   5         ��Name$ lvSelectedRoom��5      $��28,92,412,145q�6+    �� SelectionMode$ Single=�6u    �� View 5      �� 5      .P�5      �� $��Room ID��6%    �� DisplayMemberBinding 66   ��  �� Path$ RoomId��� 5      $��	Room Type��6%    68   �� $ RoomType.RoomTypeName��� 5      $��Description��6%    6:   �� $ RoomDetailDescription��� 5      $��
RoomNumber��6%    69   �� $ 
RoomNumber��� 5      $��Room Max Capacity��6%    6@   �� $ RoomMaxCapacity��� 5      $��Room Status��6%    6:   �� $ 
RoomStatus��� 5      $��Room Price Per Day��6%    6A   �� $ RoomPricePerDay�5      5      �� 5   
   -   5        $ 
lbRoomList��5      $��Selected Room��6$   $
��Left=�6<   $��	28,66,0,0q�6W   $	��Top=�6j   $
��Bold"�6�   �� 5   
   -   5        $ lbTypeDetails��5      $��Room Type Details��6'   $
��Left=�6C   $��
414,66,0,0q�6^   $	��Top=�6r   $
��Bold"�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 
dpStartday��5      $
��Left=�6)   $��143,310,0,0q�6D   $	��Top=�6Y   $	��203��6q   6}     5   
   -   5        $ dpEndday��5      $
��Left=�6'   $��143,351,0,0q�6B   $	��Top=�6W   $	��203��6o   6{   �� 5   
   -	   5        $ 
lbStartday��5      $��Start Renting Day��6$   $
��Left=�6@   $��
28,308,0,0q�6[   $	��Top=�6o   $
��Bold"�6�   �� 5   
   -
   5        $ lbEndday��5      $��End Renting Day��6"   $
��Left=�6<   $��
28,349,0,0q�6W   $	��Top=�6k   $
��Bold"�6�   �� 5   
   -   5        	 ��Name$	 btnRent��5      $
��Rent��6"   $
��Left=�61   $��562,387,0,0q�6L   $	��Top=�6a   $��64��6y   6�   �� 5    
   -   5        $	 btnBack��5       $
��Back��6"   $
��Left=�61   $��673,387,0,0q�6L   $	��Top=�6a   $��65��6y   6�   �� 5!   
   -   5        $ lvTypeDetails��5!      $��414,92,26,145q�6*    5"      �� 5#      .P�5$      �� $��Room ID��6%    66   �� $ 
RoomTypeId��� 5%      $��	Room Type��6%    68   �� $ RoomTypeName��� 5&      $��Description��6%    6:   �� $ TypeDescription��� 5'      $��	Type Note��6%    68   �� $ TypeNote�5(      5*      5,      5-      