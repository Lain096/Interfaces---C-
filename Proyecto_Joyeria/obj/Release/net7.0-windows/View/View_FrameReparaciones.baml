   M S B A M L   `   `   `  ���� K  GProyecto_Joyeria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Proyecto_Joyeria.ViewProyecto_Joyeria.View  2    ,Proyecto_Joyeria.View.View_FrameReparaciones   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     5local#clr-namespace:Proyecto_Joyeria.View       N� Title$  View_FrameReparaciones�� N� 
Background
 ���� .����  �� CornerRadius$ 5������  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,0&�.���  � Color$ 	AliceBlue�� � Offset$ 1Q�� $ 	#FFF7CAD1��$ 0Q�._�� -    �Name$ gridProductosUsuarios�� � ColumnDefinitions �� $��20 ��� �� �� �� �� $��20 �	 � RowDefinitions	 �� $��50 ��� $��20 ��� $��30 ��� $��20 ��� �� �� �� �� $��20 �.+��� $��0��$��6��$��	TUS COSAS��
���   �$��Right=�$��30(�$��Center=��� $��0��$��1��$��2��$��2��$��Buscar Producto:��$��23(�$��Center=�$
��Left=��� -   $��txtBuscarProducto��$��2��$��1��
 �� TextAlignment$
 Center=�$��20(�
������ $��Center=�
����i���� -    ��Name$ btnBuscarProductoUsuario��$��2��$��2��$��20(�$	��100��   botonNormal#��[  $
��Left=�$��10,0,0,0q�.���� $��Buscar��
�������$��20(��� -   $ btnAgregarProductoUsuario��$��2��$��3��$��20(�$��Right=�$��2��$��Añadir Producto��
������� � Cursor$
 Hand��#��[  &   System.Windows.Controls.DataGrid  -   $&�� dataGridMostrarProductosUsuarios��$��4��$��1��$��3��$��4��   AutoGenerateColumns$ False��
�������
���   �   CanUserAddRows$ False��   CanUserResizeColumns$
 True��   CanUserResizeRows$ False��   CanUserSortColumns$ False��   RowBackground
 ����    HeadersVisibility$ Column=�   GridLinesVisibility$ 
Horizontal=�   HorizontalGridLinesBrush
 ����� � 	Resources =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value)  #System.Windows.Controls.DataGridRow*  $System.Windows.Controls.DataGridCell��%�   '        '  �     '  �     �� "  .���  � ��
 �������  � ��
 �������  � ��$ 18(���  � ��$
 Bold"���  � ��$ Center=��� "  .�-   �� "  .���  � ��$ Center=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Id��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
IdProducto+  $ Producto��$ *  �� *Nombre+  $ Fecha Depósito��$ *  �� *FechaDeposito+ �� StringFormat$ {0:d}��  $ Estado��$ *  �� *	Terminado+ � -   $��introducirProducto��$��0��$��0��$��5��$��8��  � NavigationUIVisibility$ Hidden=�