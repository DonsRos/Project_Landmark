   M S B A M L   `   `   `  ����J  FWpfApp_Landmark, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApp_LandmarkWpfApp_Landmark  5   	   $    WpfApp_Landmark.Table_Category   5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApp_Landmark     5   	     � Title$  Table_Category��5	   	   $	��450��5
   	   $	��800��5   	   .��5      � .+�5   
   �� -   5        $
��Left=�5      $��1��5      $��
Назад��5      $	��200��5      5   *   �� 5   
   -   5        $��Center=�5      $��1��5      
��� � �
��� � �$��Добавить��5      $	��200��5      5   &   �� 5   
   -   5        $��Right=�5      $��1��5      
���  ��$��Удалить��5      $	��200��5      
���  ��5   )   � 5    
   $��0��6   .+�5!      &   System.Windows.Controls.DataGrid  -   5          Name$ CategoryList��5#      $��3��5!      $��0��5"         
IsReadOnly$
 True��5$         AutoGenerateColumns$ False��5%         CanUserResizeColumns$
 True��5&         CanUserResizeRows$ False��5'         CanUserReorderColumns$ False��5(         Columns 5*      0  *System.Windows.Controls.DataGridTextColumn  5+      ,  &System.Windows.Controls.DataGridColumn   Header$# Номер категории��6)   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 150 6[   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6B   �� *c_id+6i     5,      $ Название��6)   $		 170 6V   
 6;   �� *c_name+6d     5-      $ Описание��6)   $		 700 6]   
 6;   �� *c_description+6k   5/       � ColumnDefinitions 50      �� 51      $��50 �6#   60   �� 52      6%   �� 53      6%   55       � RowDefinitions 56   
   �� 57      $	��330 �6   6+   �� 58      6   5:      5;      