   M S B A M L   `   `   `  ���� K  GProyecto_Joyeria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Proyecto_Joyeria.ViewProyecto_Joyeria.View  8    2Proyecto_Joyeria.View.View_ReparationsAdminControl   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     5local#clr-namespace:Proyecto_Joyeria.View     .����   �� CornerRadius$  5������  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,0&�.���  � Color$ 	AliceBlue�� � Offset$ 1Q�� $ 	#FFF7CAD1��$ 0Q�._��  � RowDefinitions �� $��10 ��� $��50 ��� $��10 ��� $��* ��� $��50 � � ColumnDefinitions �� $��10 ��� $��* ��� $��10 �.+��� $��Center=�$��1��$��1��$��Center=� �� Orientation$ 
Horizontal=�.+��� $��Buscar por dueño: ��$��25(��� -   $��txtDueñoBuscar��$	��150��
������ 
���   �$��0,0,0,1q�$��Center=��� -    ��Name$ btnBuscarUsuario��$��20,0,0,0q�$��80��$��Buscar��$��20(�   botonNormal#��[  &   System.Windows.Controls.DataGrid  -   $#��dataGridMostrarProductosAdmin��$��1��$��3��	   AutoGenerateColumns$	 False��
�������
���   �
   CanUserAddRows$
 False��   CanUserResizeColumns$
 True��   CanUserResizeRows$ False��   CanUserSortColumns$ False��   RowBackground
 ����    HeadersVisibility$ Column=�   GridLinesVisibility$ 
Horizontal=�   HorizontalGridLinesBrush
 ����� � 	Resources =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value)  #System.Windows.Controls.DataGridRow*  $System.Windows.Controls.DataGridCell��%�   '        '  �     '  �     �� "  .���  � ��
 �������  � ��
 �������  � ��$ 18(���  � ��$
 Bold"���  � ��$ Center=��� "  .�-   �� "  .���  � ��$ Center=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Id��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
IdProducto+  $ Dueño��$ *  �� *NombrePersona+  $ Producto��$ *  �� *Nombre+  $ 
Depositado��$ *  �� *FechaDeposito+ �� StringFormat$ {0:d}��  $ Estado��$ *  �� *	Terminado+�� -   $ btnAgregarUsuario��$��5��$��1��$	��200��$��35��$
��Left=�$��30,0,0,0q�$��Eliminar Producto��$��25(�#��[  �� -   $ btnGenerarPDF��$	��200��$��Right=�$��5��$��1��$��35��$��0,0,30,0q�$��Generar Factura��$��25(�#��[  