   M S B A M L   `   `   `  ���� K  GProyecto_Joyeria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Proyecto_Joyeria.ViewProyecto_Joyeria.View  4    .Proyecto_Joyeria.View.View_AñadirProductoUser   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5local#clr-namespace:Proyecto_Joyeria.View     -     � Title$  View_AñadirProductoUser��$	��450��$	��800�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=�
������  � AllowsTransparency$
 True��.����  �� CornerRadius$ 50��._��� $ 50��$��3q�����  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,1&�.���  � Color$
 Pink�� � Offset$ 0Q�� $ DeepPink��$	 0.5Q�� $ HotPink��$ 1Q����� $	 0,1&�$	 1,0&�.��� $ 	AliceBlue��$ 1Q�� $ 	LightPink��$ 0Q�._�� 	 � ColumnDefinitions	 �� $��20 ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��20 �
 � RowDefinitions
 �� $��20 ��� $��70 ��� $��20 ��� �� �� �� �� �� $��20 �.+��� $��1��$��1��$��6��$��Añadir Producto��$��35(�$
��Bold"�$��Center=�$��Center=�
���   �$
��Wrap=�$��0,0,0,0q��� -   $��5��$��7��$��2��$��Añadir��$��center=�$��25(�$��Center=�$��50��$	��120��   botonNormal#��[  �� -   $��1��$��1��$��2��$��Regresar��$��center=�$��25(�$��Center=�$��50��$	��120��#��[  �� $��1��$��3��$��1��$��Nombre del Producto��$��20(�$
��Bold"�$
��Left=�$��Center=�
���   �$
��Wrap=��� -    ��Name$ añadirNombreProducto��$��3��$��2��$��2��
�������$��30��$��10,0,0,0q�$	��250��
������ $��0,0,0,2q��� $��1��$��4��$��1��$��2��$��Información del Producto��$��20(�$
��Bold"�$
��Left=�$��Center=�
���   �$
��Wrap=��� -   $  añadirInformacionProducto��$
��Left=�$��2��$��4��$��2�� �� TextWrapping$
 Wrap=�$��3��
�������$��30��$��10,0,0,0q�$	��300��
������ $��0,0,0,2q��� $��1��$��5��$��1��$��2��$��Modificacion a realizar��$��20(�$
��Bold"�$
��Left=�$��Center=�
���   �$
��Wrap=��� -   $! añadirModificacionProducto��$��2��$��5��$��2��$��3��$
��Left=�
�������$
 Wrap=�$��30��$��10,0,0,0q�$	��300��
������ $��0,0,0,2q��� $��1��$��6��$��1��$��2��$��Tipo del Producto��$��20(�$
��Bold"�$
��Left=�$��Center=�
���   �$
��Wrap=��� -    ��Name$ cbAñadirTipoProducto��$��2��$��6��$��2��$��3��$
��Left=�$��30��$��10,0,0,0q�$	��150���� -   $��añadirImagenProducto��$��2��$��5��$��3��$��2��$
��Fill=��� -	    ��Name$ btnBuscarImagen��$��5��$��5��$��2��$��Buscar Imagen��$��20(�$��30��$	��150��
�������#��[  