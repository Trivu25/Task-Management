   M S B A M L   `   `   `  ����I  ETaskManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TaskManagementTaskManagement  5   	       TaskManagement.Login   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TaskManagement     5   	     � Title$  Login��5   	   $	��450��6   $	��800��6$   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� 
������$��0��6)   $��5��69   �� 5   
   $��0��6   $��1��6!   $��Center=�6.   $��Bottom=�5      $��30(�6(   
����  �$��impact)�6H   $��Task management��5      �� 5   
   $��0��6   $��2��6!   $��Center=�6.   $	��Top=�5      $��15(�6   
����  �$��impact)�6=   $&�� Please login to join our service��5      �� 5   
   $��0��6   $��3��6%   $��2��62   $��40q�6C   .+�5      �� $��Center=�6   $	��Top=�5       $��15(�6)   
����  �$��impact)�6I   $��Dont have account?��5!      �� 5"      -   5         ��Name$ txtRegister��5"      $��Regsiter��6*   $��80��5#      $��30��6   $��Center=�6(   $��Center=�6E   
����  �
�������5$   #   5%      � 5&   
   $��1��6   $��1��6$   $��3��61   $��0,40,0,0q�6E   .+�5'      �� $��20(�6   $	��Top=�6'   $��Right=�5(      $��10q�6-   
User Name:6E   �� 5)      -   5         ��Name$ txtUsername��5)      $	��380��5*      $��30��6   $
��Left=�6)   $	��Top=�6D   $��5q�5+      $��Center=�6   $��20(�6>   6N   5,      � 5-   
   $��1��6   $��2��6$   $��2��61   $��0,43,0,0q�6E   .+�5.      �� $��20(�5/      $	��Top=�6#   $��Roboto)�6;   $��Right=�50      $��10q�61   	Password:6H   G� 51      -   5         G�Name$ txtPassword��51      $	��380��52      $��30��6!   $
��Left=�6-   $	��Top=�6H   $��20,5,5,5q�53      $��Center=�6'   $��20(�6I   6Y   54      �� 55   
   -   5        $ txtLogin��55      $��Login��6#   $��1��63   $��3��6C   $��2��6P   $��2��6d   $��80��56      $��30��6   $��Center=�6$   $��Center=�6A   
����  �
�������57      58      59      