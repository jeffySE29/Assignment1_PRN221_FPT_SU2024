   M S B A M L   `   `   `  ����O  KLaiNguyenMinhQuanWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:LaiNguyenMinhQuanWPFLaiNguyenMinhQuanWPF  5   	   -    'LaiNguyenMinhQuanWPF.EditCustomerWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:LaiNguyenMinhQuanWPF     5   	     � Title$  EditCustomerWindow��5   	   $	��400��6$   $	��800��61   .��5	      � -   5         �Name$ WindowEditCustomer��5	      .+�5
   
   �� -   5         ��Name$ lbTitle��5
      $��EDIT CUSTOMER��6!   $��Center=�69   $��0,30,0,0q�6V   $	��Top=�6h   $��38(�6�   $
��Bold"�6�   $��Arial)�6�   �� 5   
   -   5         ��Name$ btnBack��5      $
��Back��6"   $
��Left=�61   $��698,286,0,0q�6L   $	��Top=�6a   $��58��6�   �� 5   
   -   5        $ 
lbFullName��5      $��	Full Name��6$   $
��Left=�68   $��
40,113,0,0q�6S   $	��Top=�6g   $
��Bold"�6   �� 5   
   -   5        $ lbTelephone��5      $��	Telephone��6%   $
��Left=�69   $��
40,171,0,0q�6T   $	��Top=�6h   $
��Bold"�6�   �� 5   
   -   5        $ lbEmail��5      $��Email Address��6!   $
��Left=�69   $��
40,225,0,0q�6T   $	��Top=�6h   $
��Bold"�6�   �� 5   
   -   5        $ lbStatus��5      $��Status��6"   $
��Left=�63   $��412,171,0,0q�6N   $	��Top=�6c   $
��Bold"�6{   �� 5   
   -   5        $ 
lbPassword��5      $��Password��6$   $
��Left=�67   $��412,225,0,0q�6R   $	��Top=�6g   $
��Bold"�6   �� 5   
   -	   5        $ 
lbBirthday��5      $��
Birth Date��6$   $
��Left=�69   $��412,113,0,0q�6T   $	��Top=�6i   $
��Bold"�6�   �� 5   
   -
   5        $ btnSave��5      $
��Save��6"   $
��Left=�61   $��581,286,0,0q�6L   $	��Top=�6a   $��60��6y   6�   �� 5   
   -   5         ��Name$ txtName��5      $
��Left=�6#   $��148,121,0,0q�6>    �� TextWrapping$
 Wrap=�6S   $	��Top=�6g   $	��210��6   �� 5   
   -   5        $ txtPhone��5      $
��Left=�6$   $��148,177,0,0q�6?   $
 Wrap=�6T   $	��Top=�6h   $	��210��6�   �� 5   
   -   5        $ txtEmail��5      $
��Left=�6$   $��148,229,0,0q�6?   $
 Wrap=�6T   $	��Top=�6h   $	��210��6�   �� 5   
   -   5        $ 	txtStatus��5      $
��Left=�6%   $��506,175,0,0q�6@   $
 Wrap=�6U   $	��Top=�6i   $	��210��6�   �� 5   
   -   5        $ txtPassword��5      $
��Left=�6'   $��506,229,0,0q�6B   $
 Wrap=�6W   $
��123@��6k   $	��Top=�6w   $	��210��6�   ${�False��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dpBirth��5      $
��Left=�6&   $��506,118,0,0q�6A   $	��Top=�6V   $	��210��6n   5      5      