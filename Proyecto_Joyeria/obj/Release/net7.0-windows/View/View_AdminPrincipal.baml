   M S B A M L   `   `   `  ���� K  GProyecto_Joyeria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Proyecto_Joyeria.ViewProyecto_Joyeria.View  G(clr-namespace:Proyecto_Joyeria.ViewModelProyecto_Joyeria.ViewModel  /    )Proyecto_Joyeria.View.View_AdminPrincipal   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5local#clr-namespace:Proyecto_Joyeria.View     7vm(clr-namespace:Proyecto_Joyeria.ViewModel     X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp    � Title$  View_AdminPrincipal��$	��450��$	��800�� � WindowStyle$
 None=� � AllowsTransparency$
 True�� � 
ResizeMode$ NoResize=�
������  � DataContext 1  +Proyecto_Joyeria.ViewModel.ViewModelChanges  .���� 
������ ._���  �� CornerRadius$ 10��$��3q�����  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,1&�.���  � Color$
 Pink��	 � Offset$	 0Q�� $ DeepPink��$		 0.5Q�� $ HotPink��$	 1Q�._�� 
 � ColumnDefinitions
 �� $	��170 ��� $��* �.+��� $ 
5, 0, 0, 5��$��0������  �� Color$ 	#FFEF8A9C��._��� .+���  �� Orientation$ Vertical=�$��65��$	��100��$
��Left=�$��	20,25,0,0q�.+��� $��../Assets/logo.png��$��50��$��50��$��Uniform=�$
��Left=��� -   $��userName��$��USUARIO��$��Medium"�$
��Left=�	� -      
navegacion#��[  
 � Tag$ 	AliceBlue������ *AdminUsersControlCommand+.���� $ 
Horizontal=�.+�!  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$
 User=�  menuButtonIcon#��[ �� $��Usuarios��  menuButtonText#��[ 	� -   #��[  $ 	AliceBlue������ * AdminReparationsControlCommand+.���� $ 
Horizontal=�.+�  $ Toolbox=�#��[ �� $��Reparaciones��#��[ $
��Wrap=�	� -     navegacionUser#��[ $ 	AliceBlue��.���� $ 
Horizontal=�.+�  $ LockOpen=�#��[ �� $��Log Out��#��[ �� $ 
0, 5, 5, 0��$��1������ $	 0,0&�$	 1,0&�.��� $ 	AliceBlue��$	 1Q�� $ 	LightPink��$	 0Q�._��  � RowDefinitions �� $��25 ��� $��10 ��� $��* �.+��� -   $��crlPanel��$ 
Horizontal=�$��0��$��RightToLeft=�
������ $��0,0,5,0q�.+��� -    ��Name$ btnClose��  btnNavegacion#��[ $	 Red�� � Cursor$
 Hand��.��  $ Xmark=�  ctrlButtonIcon#��[ �� -   $ btnMinimize��#��[ $ Yellow��$
 Hand��.��  $ WindowMinimize=�#��[ �� $��2��$��25q����� *CurrentView+