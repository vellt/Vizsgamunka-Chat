   M S B A M L   `   `   `  ���� Y  USZBvizsgamunkaChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=07184af3e39363bdg8clr-namespace:SZBvizsgamunkaChat.View.Windows.MainWindow*SZBvizsgamunkaChat.View.Windows.MainWindow  M+clr-namespace:SZBvizsgamunkaChat.View.IconsSZBvizsgamunkaChat.View.Icons  ;    5SZBvizsgamunkaChat.View.Windows.MainWindow.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Jlocal8clr-namespace:SZBvizsgamunkaChat.View.Windows.MainWindow     =icons+clr-namespace:SZBvizsgamunkaChat.View.Icons     -     � Title$  
MainWindow��$	��796��$
��1280��$	��796��$
��1280�� � WindowStartupLocation$ CenterScreen=�.��� .+��  � ColumnDefinitions �� $��80 ��� $��* �.+�� -    �Name$ mainContent��$��1��� $��0��
������� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 15Q�   	Direction$	 -90Q�   RenderingBias$ Quality=�   ShadowDepth$ 2Q�	   Color$	 	#FFE8E8E8��.+��� $	��Top=�.+�� -   $	��117��
�������
 � Cursor$

 Hand��.+��� $��50��$��50�� �� RadiusY$ 40�� �� RadiusX$ 40��
�������$��
15 15 15 0q�$	��Top=��� $��50��$��50��$ 40��$ 40��$��
15 15 15 0q�$	��Top=�����  j� Stretch$ UniformToFill=� �� ImageSource ��  �� Path$ Picture� �� Mode$ TwoWay=��� -    ��Name$ navigationBtns��.+�� -   $ 
homeButton��$��80��$

 Hand��
�������.+��� $��50��$��50��$ 40��$ 40��
�������$y�	Collapsed=�*   $SZBvizsgamunkaChat.View.Icons.HomeUC  $��20��� -   $ messagesButton��$��80��$

 Hand��
�������.+��� $��50��$��50��$ 40��$ 40��
�������$y�	Collapsed=�� -   $ notifyGR��$	��Top=�$��Right=�$��8q�$y�	Collapsed=�.+��� $��25��$��25��$
 12.5��$
 12.5�����#E2747F
�������$��2���� $��12��$��Segoe UI)�
�������$��11(�$��Center=�$��Center=�.   (SZBvizsgamunkaChat.View.Icons.MessagesUC  $��20��   Fill
 �   �� -   $ settingsButton��$��80��$

 Hand��
�������.+��� $��50��$��50��$ 40��$ 40��
�������$y�	Collapsed=�.   (SZBvizsgamunkaChat.View.Icons.SettingsUC  $��20��� -	   $ logOut��$

 Hand��$��Bottom=�$��80��
�������.+�*   $SZBvizsgamunkaChat.View.Icons.ExitUC  $��20��   Fill
 �   �� -
   $ alertGR��