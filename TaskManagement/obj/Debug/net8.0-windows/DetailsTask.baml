   M S B A M L   `   `   `  ����I  ETaskManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TaskManagementTaskManagement  5   	        TaskManagement.DetailsTask   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TaskManagement     5   	     � WindowStartupLocation$  CenterScreen=�5       � Title$ DetailsTask��5   	   $	��450��6   $	��400��6*   .��5	      � .+�5
   
   �� $��Details��6   $��30(�6"   $��Center=�60   �� 5   
   
�������$	��300��6/   $	��300��6<   .+�5      �� -   5         ��Name$ txtTitle��5      $��20(�6*   $
��auto��68   $
��Bold"�6E   
���<��$��Italic$�5      $
��Left=�6+   $��Center=�6F   $��10,0,0,0q�6a   �� 5      $��Description:��6   $��5,0,5,0q�6+   $��15(�6<   $
��Bold"�6J   �� 5      -   5        $ txtDescription��5      $
��auto��60   $
��auto��6>   ���	#FFFFBF86$
��Wrap=�6b   $��	10,0,10,0q�6v   � 5      .+�5      �� .+�5      �� $��	DeadLine:��6   $��5,0,0,0q�60   $��15(�6A   $
��Bold"�6O   �� 5      -   5        $ 
txtDueDate��5       $
��Left=�64   $	��top=�6O   $��10,0,0,0q�6g   ���	#FFFFBF866�   5      �� 5      $��75,0,0,0q�6   .+�5      �� $��Status:��6   $��5,0,0,0q�6.   $��15(�6?   $
��Bold"�6M   �� 5      -   5         ��Name$ cbStatus��5   .   $
��Done��6   ���	#FFFFBF86${�False��6W   5      5      � 5      .+�5      �� $��	Priority:��6   $��5,0,0,0q�6,   $��15(�6=   $
��Bold"�6K   �� 5      -   5        $ txtPriority��5      $��Center=�61   $��Center=�6L   ���	#FFFFBF866i   5      � 5      .+�5      �� .+�5       �� $��
Create On:��6   $��5,0,0,0q�61   $��15(�6B   $
��Bold"�6P   �� 5!      -   5        $ 	txtCreate��5!       $
��Left=�63   $	��top=�6N   $��10,0,0,0q�6f   ���	#FFFFBF86$	��135��6�   6�   5"      �� 5#      .+�5$      �� $��last modified:��6   $��5,0,0,0q�65   $��15(�6F   $
��Bold"�6T   �� 5%      -   5        $ 	txtModify��5%       $
��Left=�63   $	��top=�6N   $��10,0,0,0q�6f   ���	#FFFFBF86$	��130��6�   6�   5&      5'      �� 5)      -   5        $
��Back��5)      $��30��6$   $��40��60   $��0,10,0,0q�6;   ���	#FFF4D24E5*   (   5+      5,      5-      