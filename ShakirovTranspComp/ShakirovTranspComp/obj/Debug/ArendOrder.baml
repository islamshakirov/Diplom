   M S B A M L   `   `   `  ����M  IShakirovTranspComp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ShakirovTranspCompShakirovTranspComp  5      #    ShakirovTranspComp.ArendOrder   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:ShakirovTranspComp     5        N� Title$  
ArendOrder��5	       N� 
Background
 �����.��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   � $��0��6   $	��400��5      $	��300��6   $��Bottom=�6&   $��Right=�5      $��2��5      ���#70BAE0 � RowDefinitions 5      �� 5      �� 5      �� 5      �� 5       5      �� 5      �� 5      $	��150 �6#   .+�5!      �� $��Тоннаж (кг)��6   $
��Wrap=�5"      $��25(�5#      $
��Bold"�5$      
������� �� TextAlignment$ Center=�5&      $��
105,20,0,0q�5'      �� 5)      -   5        $��	AmountBox��5-      $��0��5)      $��1��5*      $	��140��5+      $��50��5,      5-      �� 5/      -   5        $��SuitableCars��57      $+��%Проверить доступные��5/      $��1��50      $��2��51      $��
100,20,0,0q�52      $��20(�53      $
��Bold"�54      
�������$ Center=�56      58      �� 5:      $��Категория��6   $
��Wrap=�5;      $��25(�5<      $
��Bold"�5=      
�������$ Center=�5?      $��2��5@      $��
105,20,0,0q�5A      �� 5C      -   5        $��CarTypeSelector��5G      $��2��5C      $��1��5D      $	��140��5E      $��50��5F       �� SelectedIndex$ 0��5H      �� 5J      -   5        $��RequestButton��5U      $��Заказать��5J      $	��250��5K      $��45��5L      $��20(�5M      $��30,0,0,0q�5N      $
��Bold"�5O      ���#ff5a30
�������$��Times New Roman)�5R      $��3��5S      $��2��5T      5V      5X      � 5Z   
   $	��400��6   $	��300��6   $	��Top=�6(   $��2��5[      $
��Left=�5\      ���#c3f0f7 5^      �� 5_      $��50 �6    �� 5`      �� 5a      $��50 �6    �� 5b       5d      �� 5e      $	��100 �6#   �� 5f      .+�5i      �� $��1��6   $��70��5j      $��70��5k      $��./images/calendar.png��5l      �� 5n      $��Дата аренды��6   $��1��5o      $��25(�5p      ���#1515AA$
��Bold"�5r      $��Bottom=�5s      $��Center=�5t      (  "System.Windows.Controls.DatePicker  5v      -   5        $��	StartDate��5z      $��1��5v      $��1��5w      $��50��5x      $	��250��5y      
�������5{      �� 5~      $��3��6   $��70��5      $��70��5�      $��./images/clock1.png��5�      �� 5�      $"��Время аренды (ч)��6   $��2��5�      $��1��5�      $��25(�5�      ���#1515AA$
��Bold"�5�      $��Bottom=�5�      $��Center=�5�      �� 5�       �� Orientation$ 
Horizontal=�6   $��3��62   $��1��6?   $��30,0,0,0q�5�      .+�5�      �� -   5        $��MinusButton��5�      $��-��5�      $��50��6%   $��50��60   $��30(�5�      $
��Bold"�5�      
�������   RoundButton#��[  5�      ���#508ca3$��30,0,0,0q�5�      5�      �� 5�      -   5        $��
ArendHours��5�      $��0��5�      $��25(�5�      ���#1515AA$
��Bold"�5�      $��Center=�5�      $��	30,0,30,0q�5�      5�      �� 5�      -   5        $��
PlusButton��5�      $��+��5�      $��50��6%   $��50��60   $��30(�5�      $
��Bold"�5�      
�������#��[  5�      ���#508ca3$��00,0,0,0q�5�      5�      5�      5�      5�      5�      