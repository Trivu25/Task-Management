   M S B A M L   `   `   `  ����I  ETaskManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TaskManagementTaskManagement  5   	       TaskManagement.UpdateTask   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TaskManagement     5   	     � Title$  
UpdateTask��5   	   $	��450��6   $	��400��6)   .��5	      � -   5        .+�5
   
   �� $��Update Task��6   $��30(�6&   $��Center=�64   �� 5   
   
�������$	��300��6/   $��50,67,50,10q�6;   .+�5      �� $
��Bold"�6   $��Title:��6&   $��5,0,0,0q�67   �� 5      -   5         ��Name$ txtTitle��5      $	��200��6(   $
��Left=�64   $��10,0,0,0q�6O   �� 5      $
��Bold"�6   $��Description:��6&   $��5,0,0,0q�6=   �� 5      $
��Auto=�6   $	��105��6>   $��
10,0,10,10q�6K   .��5      �� -   5        $ txtDescription��5      $��80��62   $	��280��6>    �� TextWrapping$
 Wrap=�6J    �� AcceptsReturn$
 True��6^   5      � 5      .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $
��Bold"�6   $��	Deadline:��6.   $��5,0,0,0q�6B   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ 
dpkDueDate��5   !   $
��Left=�5   !   $	��Top=�5   !   $	��200��5   !   $��10,0,0,0q�5   !      SelectedDate 5   !   �� *SelectedDate+ �� Mode$ TwoWay=�5      5      �� 5      $��	Priority:��6   $��5,0,0,0q�6(   $
��Bold"�69   � 5      .+�5      	� -   5         	�Name$
 rbP1��5      $��1 - Necessary��6,   $��5,0,0,0q�6D   	� 5       -   5        $
 rbP2��5       $��
2 - Normal��6,   $��5,0,0,0q�6A   	� 5!      -   5        $
 rbP3��5!      $��3 - Unnecessary��6,   $��5,0,0,0q�6F   5"      � 5#      5%      �� 5&      -   5        $��Update��5&      $��30��6&   $��80��62   $��0,10,0,0q�6=   ���	#FFF4D24E5'   ,   �� 5(      -	   5        	 ��Name$	 btnDone��5(      $��	Done Task��6&   $��30��6:   $��80��6F   6i   5*      5+      5,      