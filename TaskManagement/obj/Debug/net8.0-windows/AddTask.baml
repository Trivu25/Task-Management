   M S B A M L   `   `   `  ����I  ETaskManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TaskManagementTaskManagement  5   	       TaskManagement.AddTask   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TaskManagement     5   	     � WindowStartupLocation$  CenterScreen=�5       � Title$ AddTask��5   	   $	��450��6   $	��400��6&   .��5	      � .+�5
   
   �� $��Add new Task��6   $��30(�6'   $��Center=�65   �� 5   
   
�������$	��300��6/   $	��300��6<   .+�5      �� $��Title:��6   $��5,0,0,0q�6%   �� 5      -   5         ��Name$ txtTitle��5      $	��280��6(   $
��Left=�64   $��10,0,0,0q�6O   �� 5      $��Description:��6   $��5,0,0,0q�6+   �� 5      $
��Auto=�6   $	��105��6>   $��
10,0,10,10q�6K   .��5      �� -   5        $ txtDescription��5      $��80��62   $	��300��6>    �� TextWrapping$
 Wrap=�6J    �� AcceptsReturn$
 True��6^   5      � 5      .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��	DeadLine:��6   $��5,0,0,0q�60   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ 
dpkDueDate��5   !   $
��Left=�65   $	��Top=�6P   $	��200��5   !   $��10,0,0,0q�6-      SelectedDate 5   !   �� *SelectedDate+ �� Mode$ TwoWay=�5      5      �� 5      $��	Priority:��6   $��5,0,0,0q�6(   � 5      .+�5      	� -   5        	 	�Name$
	 rbP1��5      $��1 - Nescessary��6,   $��5,0,0,0q�6E   	� 5      -   5        $
	 rbP2��5      $��
2 - Normal��6,   $��5,0,0,0q�6A   
 d� 	IsChecked$

 TrueY�6R   	� 5      -   5        $
	 rbP3��5      $��3 - Unnescessary��6,   $��5,0,0,0q�6G   5       �� 5!      -   5        $	��Add��5!      $��30��6#   $	��120��6/   $��0,10,0,0q�6;   
��� � �5"   '   5$      5%      5&      