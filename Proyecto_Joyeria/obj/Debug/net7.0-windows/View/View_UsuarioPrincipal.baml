   M S B A M L   `   `   `  ����K  GProyecto_Joyeria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Proyecto_Joyeria.ViewProyecto_Joyeria.View  5   	   G(clr-namespace:Proyecto_Joyeria.ViewModelProyecto_Joyeria.ViewModel  5	   	   1    +Proyecto_Joyeria.View.View_UsuarioPrincipal   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Proyecto_Joyeria.View     5   	   X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5   	   1vm(clr-namespace:Proyecto_Joyeria.ViewModel  5	   	     � Title$  View_UsuarioPrincipal��5
   	   $	��450��6'   $	��800��64    � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��5   	    � 
ResizeMode$ NoResize=�5   	   
������ .��5      �� 
������ ._�5   
   ��  �� CornerRadius$ 10��6   $��3q�6#   ��5      �� 5       �� 
StartPoint$	 0,0&�5       �� EndPoint$	 1,1&�5      .��5      �  � Color$
 Pink��6#    � Offset$ 0Q�60   � 5      $ DeepPink��6#   $	 0.5Q�64   � 5      $ HotPink��6#   $ 1Q�63   5      ._�5      � 	 � ColumnDefinitions	 5       �� 5!      $	��170 �6'   �� 5"      $��* �6'   .+�5-      �� $ 
5, 0, 0, 5��6   $��0��63   ��5.      �� 5/      
 �� Color$
 	#FFEF8A9C��6*   ._�52      �� .+�55      ��  �� Orientation$ Vertical=�6%   $��65��6<   $	��100��6H   $
��Left=�6T   $��	20,25,0,0q�6o   .+�56      �� $��../Assets/logo.png��6$   $��50��6@   $��50��6L   $��Uniform=�6W   $
��Left=�6i   5:      	� 5>      -   5           navegacionUser#��[  5>   &   
 � Tag$ 	AliceBlue��5?   &   .��5B      �� $ 
Horizontal=�6)   .+�5C   "   !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$
 User=�6/     menuButtonIcon#��[ 6;   �� 5D   "   $��	Mi Cuenta��6,     menuButtonText#��[ 6=   5E      5I      	� 5J      -   5          
navegacion#��[ 5J   &   $ 	AliceBlue��5K   &   .��5M      �� $ 
Horizontal=�6)   .+�5N   "     $ Toolbox=�6/   #��[ 6>   �� 5O   "   $��Mis reparaciones��6,   #��[ 6D   $
��Wrap=�6l   5P      5R      	� 5T      -   5        #��[  5T   &   $ 	AliceBlue��5U   &   .��5X      �� $ 
Horizontal=�6)   .+�5Y   "     $ LockOpen=�6/   #��[ 6?   �� 5Z   "   $��Log Out��6,   #��[ 6;   5[      5_      5a      5c      �� 5f      $ 
0, 5, 5, 0��6   $��1��63   ��5g      �� 5h      $	 0,0&�6.   $	 1,0&�6?   .��5i      � $ 	AliceBlue��6+   $ 1Q�6=   � 5j      $ 	LightPink��6+   $ 0Q�6=   5k      ._�5n      �  � RowDefinitions 5o      �� 5p      $��25 �6,   �� 5q      $��10 �6,   �� 5r      $��* �6,   .+�5v      �� -   5        $��crlPanel��5v   %   $ 
Horizontal=�5w   %   $��0��5x   %   $��RightToLeft=�5y   %   
������ $��0,0,5,0q�5{   %   .+�5      �� -   5         ��Name$ btnClose��5   %     btnNavegacion#��[ 5�   %   $	 Red��5�   %    � Cursor$
 Hand��5�   %   .��5�   "     $ Xmark=�6/     ctrlButtonIcon#��[ 6<   5�      �� 5�      -   5        $ btnMinimize��5�   %   #��[ 5�   &   $ Yellow��5�   &   $
 Hand��5�   &   .��5�   "     $ WindowMinimize=�6/   #��[ 6E   5�      5�      �� 5�      $��
Bienvenido��6$   $��80(�5�   $   $
��Bold"�5�   $   
�������$��25,0,0,0q�5�   $   $��2��5�   $   $��Center=�5�   $   $��Center=�5�   $   $��3��5�   $   5�       � 5�      -   5        $��frameUserPrincipal��5�       $��2��6:   $��25q�6G     � NavigationUIVisibility$ Hidden=�6S   5�      5�      5�      5�      5�      5�      5�      