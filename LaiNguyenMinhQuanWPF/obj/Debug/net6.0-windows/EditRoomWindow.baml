   M S B A M L   `   `   `  ����O  KLaiNguyenMinhQuanWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:LaiNguyenMinhQuanWPFLaiNguyenMinhQuanWPF  5   	   )    #LaiNguyenMinhQuanWPF.EditRoomWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:LaiNguyenMinhQuanWPF     5   	     � Title$  EditRoomWindow��5   	   $	��400��6    $	��800��6-   .��5	      � .+�5
   
   �� -   5         ��Name$ btnBack��5
      $
��Back��6"   $
��Left=�61   $��686,286,0,0q�6L   $	��Top=�6a   $��60��6�   � 5   
   -   5         �Name$ WindowEditRoom��5      .+�5      �� -   5         ��Name$ lbTitle��5      $��	EDIT ROOM��6%   $��Center=�69   $��0,30,0,0q�6V   $	��Top=�6h   $��38(�6�   $
��Bold"�6�   $��Arial)�6�   �� 5      -   5        $ 	lbRoomNum��5      $��Room Number��6'   $
��Left=�6=   $��
35,113,0,0q�6X   $	��Top=�6l   $
��Bold"�6�   �� 5      -   5        $ lbDescription��5      $��Detail Description��6+   $
��Left=�6H   $��
35,225,0,0q�6c   $	��Top=�6w   $
��Bold"�6�   �� 5      -   5        $ 
lbCapacity��5      $��Max Capacity��6(   $
��Left=�6?   $��
35,175,0,0q�6Z   $	��Top=�6n   $
��Bold"�6�   �� 5      -   5        $ lbStatus��5      $��Status��6&   $
��Left=�67   $��412,171,0,0q�6R   $	��Top=�6g   $
��Bold"�6   �� 5      -   5        $ lbPricePerDay��5      $��Price Per Day��6+   $
��Left=�6C   $��412,225,0,0q�6^   $	��Top=�6s   $
��Bold"�6�   �� 5      -	   5        $ 
lbRoomType��5      $��RoomType��6(   $
��Left=�6;   $��412,113,0,0q�6V   $	��Top=�6k   $
��Bold"�6�   �� 5      -
   5        $ btnSave��5      $
��Save��6&   $
��Left=�65   $��581,286,0,0q�6P   $	��Top=�6e   $��60��6}   6�   �� 5      -   5         ��Name$ 
txtRoomnum��5      $
��Left=�6*   $��148,121,0,0q�6E    �� TextWrapping$
 Wrap=�6Z   $	��Top=�6n   $	��210��6�   �� 5      -   5        $ txtCapacity��5      $
��Left=�6+   $��148,177,0,0q�6F   $
 Wrap=�6[   $	��Top=�6o   $	��210��6�   �� 5      -   5        $ 	txtStatus��5      $
��Left=�6)   $��506,175,0,0q�6D   $
 Wrap=�6Y   $	��Top=�6m   $	��210��6�   �� 5      -   5        $ txtPrice��5      $
��Left=�6(   $��506,229,0,0q�6C   $
 Wrap=�6X   $
��123@��6l   $	��Top=�6x   $	��210��6�   ${�False��6�   �� 5      -   5        $ txtDescription��5       �� AcceptsReturn$
 True��6.   $
��Left=�6C   $��148,229,0,0q�6^   $
 Wrap=�6s   $	��Top=�6�   $	��210��6�   $��77��6�   �� 5      -   5         ��Name$ 
cbRoomType��5      $
��Left=�6+   $��506,115,0,0q�6F   $	��Top=�6[   $	��210��6s   5      5      5      