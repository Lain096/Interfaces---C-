   M S B A M L   `   `   `  ����K  GProyecto_Joyeria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Proyecto_Joyeria.ViewProyecto_Joyeria.View  5      2    ,Proyecto_Joyeria.View.View_FrameReparaciones   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:Proyecto_Joyeria.View     5        N� Title$  View_FrameReparaciones��5	       N� 
Background
 ���� .��5      ��  �� CornerRadius$ 5��6   ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,0&�63   .��5      �  � Color$ 	AliceBlue��6    � Offset$ 1Q�61   � 5      $ 	#FFF7CAD1��6   $ 0Q�61   5      ._�5   
   � -   5         �Name$ gridProductosUsuarios��5       � ColumnDefinitions 5      �� 5      $��20 �6#   �� 5      �� 5      �� 5      �� 5      �� 5      $��20 �6#   	 � RowDefinitions	 5      �� 5       $��50 �6    �� 5!      $��20 �6    �� 5"      $��30 �6    �� 5#      $��20 �6    �� 5$      �� 5%      �� 5&      �� 5'      �� 5(      $��20 �6    .+�5-      �� $��0��6   $��6��6%   $��	TUS COSAS��5.      
���   �$��Right=�50      $��30(�51      $��Center=�52      �� 57      $��0��6   $��1��6%   $��2��65   $��2��58      $��Buscar Producto:��59      $��23(�5:      $��Center=�5;      $
��Left=�5<      �� 5@      -   5        $��txtBuscarProducto��5B      $��2��5@      $��1��6#   
 �� TextAlignment$
 Center=�5A      $��20(�5C      
������ $��Center=�5E      
����i��5F      �� 5I      -   5         ��Name$ btnBuscarProductoUsuario��5I      $��2��5J      $��2��6"   $��20(�5K      $	��100��5L         botonNormal#��[  5N      $
��Left=�5O      $��10,0,0,0q�5P      .��5R      �� $��Buscar��6   
�������$��20(�6=   5T      �� 5X      -   5        $ btnAgregarProductoUsuario��5X      $��2��5Y      $��3��6"   $��20(�5Z      $��Right=�5[      $��2��5\      $��Añadir Producto��5]      
������� � Cursor$
 Hand��5_      #��[  5a      &   System.Windows.Controls.DataGrid  5g      -   5        $&�� dataGridMostrarProductosUsuarios��5k      $��4��5g      $��1��5h      $��3��5i      $��4��5j         AutoGenerateColumns$ False��5l      
�������
���   �   CanUserAddRows$ False��5o         CanUserResizeColumns$
 True��5p         CanUserResizeRows$ False��5q         CanUserSortColumns$ False��5r         RowBackground
 ����    HeadersVisibility$ Column=�5t         GridLinesVisibility$ 
Horizontal=�5u         HorizontalGridLinesBrush
 ����� � 	Resources 5x      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value)  #System.Windows.Controls.DataGridRow*  $System.Windows.Controls.DataGridCell��%�  '        '  �     '      �� 5y      "  6   .�5z      ��  � ��
 �����67   �� 5{       � ��
 �����67   �� 5|       � ��$ 18(�65   �� 5}       � ��$
 Bold"�67   �� 5~       � ��$ Center=�6G   5      �� 5�      "  6   .�5�      -   5        5�      �� 5�      "  6   .�5�      ��  � ��$ Center=�6@   5�      5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   �� *
IdProducto+  5�      $ Producto��6)   $ * 6;    6E   �� *Nombre+  5�      $ Fecha Depósito��6)   $ * 6A    6K   �� *FechaDeposito+ �� StringFormat$ {0:d}��  5�      $ Estado��6)   $ * 69    6C   �� *	Terminado+5�       � 5�      -   5        $��introducirProducto��5�      $��0��5�      $��0��5�      $��5��5�      $��8��5�        � NavigationUIVisibility$ Hidden=�5�      5�      5�      5�      