   M S B A M L   `   `   `  ����Y  USZBvizsgamunkaChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=07184af3e39363bdg8clr-namespace:SZBvizsgamunkaChat.View.Windows.MainWindow*SZBvizsgamunkaChat.View.Windows.MainWindow  5   	   M+clr-namespace:SZBvizsgamunkaChat.View.IconsSZBvizsgamunkaChat.View.Icons  5   	   ;    5SZBvizsgamunkaChat.View.Windows.MainWindow.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Jlocal8clr-namespace:SZBvizsgamunkaChat.View.Windows.MainWindow     5   	   =icons+clr-namespace:SZBvizsgamunkaChat.View.Icons     5   	   -   5          � Title$  
MainWindow��5	   	   $	��796��6   $
��1280��6)   $	��796��66   $
��1280��6F    � WindowStartupLocation$ CenterScreen=�6p   .��5
      � .+�5   
   �  � ColumnDefinitions 5      �� 5      $��80 �6#   �� 5      $��* �6#   .+�5      � -   5         �Name$ mainContent��5   #   $��1��6   5      � 5      $��0��6   
������� J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 15Q�6'      	Direction$	 -90Q�67      RenderingBias$ Quality=�6G      ShadowDepth$ 2Q�6_   	   Color$	 	#FFE8E8E8��6o   .+�5      �� $	��Top=�6   .+�5      � -   5        $	��117��5      
�������
 � Cursor$

 Hand��6;   .+�5      �� $��50��6$   $��50��60    �� RadiusY$ 40��6;    �� RadiusX$ 40��6H   
�������$��
15 15 15 0q�6f   $	��Top=�6z   �� 5      $��50��6$   $��50��60   $ 40��6;   $ 40��6H   $��
15 15 15 0q�6U   $	��Top=�6i   ��5      �� 5   "    j� Stretch$ UniformToFill=�6_    �� ImageSource 6-   ��  �� Path$ Picture� �� Mode$ TwoWay=�6_   5      5      �� 5       -   5         ��Name$ navigationBtns��5    !   .+�5!      � -   5        $ 
homeButton��5!      $��80��63   $

 Hand��6?   
�������.+�5"      �� $��50��6(   $��50��64   $ 40��6?   $ 40��6L   
�������$y�	Collapsed=�6k   *   $SZBvizsgamunkaChat.View.Icons.HomeUC  5#      $��20��6+   5$      � 5%      -   5        $ messagesButton��5%      $��80��67   $

 Hand��6C   
�������.+�5&      �� $��50��6(   $��50��64   $ 40��6?   $ 40��6L   
�������$y�	Collapsed=�6k   � 5'      -   5        $ notifyGR��5'   #   $	��Top=�65   $��Right=�6M   $��8q�6i   $y�	Collapsed=�6t   .+�5(   "   �� $��25��6,   $��25��68   $
 12.5��6C   $
 12.5��6R   ���#E2747F
�������$��2��6   �� 5)   "   $��12��61   $��Segoe UI)�6>   
�������$��11(�6g   $��Center=�6u   $��Center=�6�   5*      .   (SZBvizsgamunkaChat.View.Icons.MessagesUC  5+      $��20��6/      Fill
 �   �6;   5,      � 5-      -   5        $ settingsButton��5-      $��80��67   $

 Hand��6C   
�������.+�5.      �� $��50��6(   $��50��64   $ 40��6?   $ 40��6L   
�������$y�	Collapsed=�6k   .   (SZBvizsgamunkaChat.View.Icons.SettingsUC  5/      $��20��6/   50      51      52      � 53      -	   5        $ logOut��53      $

 Hand��6'   $��Bottom=�65   $��80��6P   
�������.+�54      *   $SZBvizsgamunkaChat.View.Icons.ExitUC  $��20��6#      Fill
 �   �6/   55      56      59      � 5:   
   -
   5        $ alertGR��5:      5<      5=      5>      