   M S B A M L   `   `   `  ����I  ETaskManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TaskManagementTaskManagement  5   	       TaskManagement.Register   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TaskManagement     5   	     � Title$  Register��5   	   $	��450��6   $	��800��6'   .��5	      � 
������� � ColumnDefinitions 5
   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� 
�������$��0��6(   $��5��68   �� 5   
   $��0��6   $��1��6    $��Center=�6-   $��Bottom=�5      $��30(�6+   
���  ��$��Impact)�6J   $��Task Management��5      �� 5   
   $��0��6   $��2��6    $��Center=�6-   $	��Top=�5      $��15(�6(   
���  ��$��Impact)�6G   $)��#Please register to join our service��5      �� 5   
   $��0��6   $��3��6%   $��2��62   $��40q�6C   .+�5      �� $��Center=�6   $	��Top=�5       $��15(�6,   
���  ��$��Impact)�6K   $��Already have an account?��5!      �� 5"      -   5         ��Name$ txtLogin��5"      $��Login��6'   $��80��5#      $��30��6    $��Center=�6,   $��Center=�6I   
���  ��
�������5$   &   5%      � 5&   
   $��1��6   $��1��6$   $��3��61   $��0,40,0,0q�6E   .+�5'      �� $��20(�6   $	��Top=�6&   $��Right=�5(      $��10q�64   	Username:6K   �� 5)      -   5         ��Name$ txtUsername��5)      $	��380��5*      $��30��6"   $
��Left=�6.   $	��Top=�6I   $��5q�5+      $��Center=�6!   $��20(�6C   5,      � 5-   
   $��1��6   $��2��6$   $��2��61   $��0,43,0,0q�6E   .+�5.      �� $��20(�6   $	��Top=�6&   $��Roboto)�6>   $��Right=�5/      $��10q�64   	Password:6K   G� 50      -   5         G�Name$ txtPassword��50      $	��380��51      $��30��6&   $
��Left=�62   $	��Top=�6M   $��20,5,5,5q�52      $��Center=�6,   $��20(�6N   53      � 54   
   $��1��6   $��3��6$   $��2��61   $��0,43,0,0q�6E   .+�55      �� $��20(�6   $	��Top=�6&   $��Roboto)�6>   $��Right=�56      $��10q�64   Email:6H   �� 57      -   5        $ txtEmail��57      $	��380��58      $��30��6"   $
��Left=�6.   $	��Top=�6I   $��20,5,5,5q�59      $��Center=�6(   $��20(�6J   5:      �� 5;   
   -   5        $ txtRegister��5;      $��Register��6&   $��1��69   $��4��6I   $��2��6V   $��80��5<      $��30��6   $��Center=�6(   $��Center=�6E   
���  ��
�������5=   "   5>      5?      