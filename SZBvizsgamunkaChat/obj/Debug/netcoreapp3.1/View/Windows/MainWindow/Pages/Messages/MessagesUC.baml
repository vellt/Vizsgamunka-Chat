   M S B A M L   `   `   `  ����Y  USZBvizsgamunkaChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=07184af3e39363bd�Gclr-namespace:SZBvizsgamunkaChat.View.Windows.MainWindow.Pages.Messages9SZBvizsgamunkaChat.View.Windows.MainWindow.Pages.Messages  5      S.clr-namespace:SZBvizsgamunkaChat.View.Controls SZBvizsgamunkaChat.View.Controls  5      M+clr-namespace:SZBvizsgamunkaChat.View.IconsSZBvizsgamunkaChat.View.Icons  5      J    DSZBvizsgamunkaChat.View.Windows.MainWindow.Pages.Messages.MessagesUC   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      YlocalGclr-namespace:SZBvizsgamunkaChat.View.Windows.MainWindow.Pages.Messages     5      Ccontrols.clr-namespace:SZBvizsgamunkaChat.View.Controls     5      =icons+clr-namespace:SZBvizsgamunkaChat.View.Icons     5        � 	Resources  5       ��Name   Storyboard1 �� 
TargetName �� TargetProperty<  6System.Windows.Media.Animation.EasingThicknessKeyFrame p� KeyTime p� Value  Storyboard2��%�  &	        &	 r    �� 5   
   $ 
storyboard��6   .��5      r� $ menuBTN��6/   $ (FrameworkElement.Margin)�6O   .	�5        $ 00:00:00��6*   $ 0,0,10,0q�6=     5      $ 00:00:00.1000000��6*   $ 0,0,30,0q�6E     5      $ 00:00:00.2000000��6*   $ 0,0,70,0q�6E     5      $ 00:00:00.3000000��6*   $ 0,0,90,0q�6E   5      5      �� 5   
   .��5      r� $ menuBTN��6/   $ (FrameworkElement.Margin)�6O   .	�5        $ 00:00:00��6*   $ 0,0,90,0q�6=     5      $ 00:00:00.1000000��6*   $ 0,0,30,0q�6E     5      $ 00:00:00.2000000��6*   $ 0,0,0,0q�6E   5      5      5      .��5      � .+�5   
   � -   5         �Name$ uzenetContainerGR��5       � ColumnDefinitions 5      �� 5      $	��480 �6#   �� 5       $��* �6#   .+�5"      � -   5        $ MessageContentGR��5"      
�������$��1��6E   .+�5$      �  � RowDefinitions 5%      �� 5&      $��90 �6(   �� 5'      $��* �6(   �� 5(      $
��auto �6(   .+�5*      �� $��1��6$   $��Disabled=�61   $��Visible=�6Z   .��5+      �� -   5        $��messagesHolderSP��5+   K   $
��0 40q�6%   
�������6K   5,      � 5-      $��2��6   $��66��6(   $	��200��67   
������� 5.      �� 5/      $��* �6/   �� 50      $��80 �6/   .+�52      � $��0��6   
�������$��25 0 0 0q�6B   .+�53      �� -   5        	 ��Name$	 uzenetHatter��53   -   $(��"Üzenet írásához kattints ide..��6C   $��Center=�6l   $	��2 0q�6�   $��Segoe UI)�6�   $��14(�6�   ���#7070706�   �� 54      $
��Auto=�6+   $��Disabled=�6N   $
��0,18q�6w   .��55   "   �� -   5        
 ��Name$
 TextBoxUzenet��55   *   
������ $��0q�6Z   ���#707070$��Segoe UI)�6�   $��14(�6�   $��Center=�6�    �� TextWrapping$
 Wrap=�6�   6  56      57      � 58      -   5        $ sendButtonGR��58      $��2��65    � Cursor$
 Hand��6E   
�������$��Bottom=�6f   $��0 0 0 13q�6�   .+�59      �� $��40��6(   $��40��64    �� RadiusY$ 40��6?    �� RadiusX$ 40��6L   ���#96CBA46Y   *   $SZBvizsgamunkaChat.View.Icons.SendUC  5:      $��18��6+   $��5 0 0 0q�67   5;      5<      � 5=      -   5        $ headerGR��5=   ;   $��0��6   
������� J� Effect 5>      3  -System.Windows.Media.Effects.DropShadowEffect  5?         
BlurRadius$ 15Q�6/      	Direction$	 -90Q�6?      ShadowDepth$ 2Q�6O      Color$ 	#FFE8E8E8��6_      RenderingBias$ Quality=�6q    5A      �� 5B      $
��auto �6/   �� 5C      $��* �6/   .+�5E      � $��0��6    5F      �� 5G   "   $��* �60   �� 5H   "   $
��auto �60   �� 5I   "   $��* �60   .+�5K      �� $��0��6-   $��Bottom=�6i   $��Segoe UI)�6�   $��20(�6�   $
��25 0q�6�   ��6:   ��  �� Path$ Fullname� �� Mode$ TwoWay=�6�   �� 5L      $��1��6-   $��Bottom=�6e   $��Segoe UI)�6�   $��20(�6�   $
��25 0q�6�   ��6:   �� $
 Name�$ TwoWay=�6�   �� 5M      $��2��6)    �� Orientation$ 
Horizontal=�66   $
��25 0q�6O   .+�5N   "   �� $��Utoljára online: ��62   $	��Top=�6N   $��Segoe UI)�6f   $��14(�6|   ���#7070706�   �� 5O   "   $	��Top=�6h   $��Segoe UI)�6�   $��14(�6�   ���#707070��62   �� $ ProfileLastSeen�$ TwoWay=�6�   5P      5R      � 5S      -   5        $ deleteMessageBTN��5S      $��1��69   $��90��6I   $��Right=�6T   $
 Hand��6p   ���#EC6D6D.+�5T      )   #SZBvizsgamunkaChat.View.Icons.BinUC  $��22��6*   5U      � 5V      -	   5        $ menuBTN��5V      $��1��60   $��91��6@   $��Right=�6K   
�������$
 Hand��6z   $y�Visible=�6�   $��0,0,0,0q�6�   .+�5W      �� $��40��6(   $��40��64   $ 40��6?   $ 40��6L   
�������$y�	Collapsed=�6k   *   $SZBvizsgamunkaChat.View.Icons.MenuUC  5X      $��22��6+   5Y      5Z      5[      5\      � 5]      $��0��6   
������� 5_        5`      $ 15Q�6'   $	 -90Q�67   $ 2Q�6G   $ 	#FFE8E8E8��6W   $ Quality=�6i    5b      �� 5c      $��90 �6$   �� 5d      $��* �6$   .+�5f      � $��1��6   .+�5h      �� $
��Auto=�6#   $��Disabled=�6F   .��5i      �� .+�5j      �� -
   5         ��Name$ normalListaSP��5j   )   .+�5k   "   � -   5        $ NewMessageBox��5k   '   
�������6>   �� 5l   "   -   5        $ 
MessageBox��5l   -   
�������6A   5m      �� 5n      -   5        $ szurtListaSP��5n   )   5p      5q      5t      � 5u      -   5        $ 
plusButton��5u      $��Bottom=�6/   $��20q�6J   $��Right=�6V   $
 Hand��6r    5v        5w      $ 15Q�6/   $	 -90Q�6?   $ 2Q�6O   $ 	#FFE8E8E8��6_   $ Quality=�6q   .+�5y      �� $��50��6$   $��50��60   ���	#FF96CBA4$ 50��6L   $ 50��6Y   *   $SZBvizsgamunkaChat.View.Icons.PlusUC  5z      $��20��6'   5{      5|      � 5}      $��0��6   
�������.+�5      2   ,SZBvizsgamunkaChat.View.Controls.SearchBarUC  -   5          Name$ 	SearchBar��5   +   2   ,SZBvizsgamunkaChat.View.Controls.SearchBarUC   DataContextChanged$$ SearchBarUC_DataContextChanged��6L   $
��25 0q�6>   6L   5�      5�      � 5�      $��1��6   5�      5�      � 5�   
   -   5        $ fedlapGR��5�      $y�	Collapsed=�6!    5�      �� 5�      $��90 �6    �� 5�      $��* �6    .+�5�      � $��1��6   
�������.+�5�      �� $��Center=�6   $��Center=�68   .+�5�      � .+�5�      .	   (SZBvizsgamunkaChat.View.Icons.SecurityUC	  $��71��6+   5�      � 5�      $��	0 30 0 85q�6   .+�5�      �� $
��Wrap=�6$   $	��646��68   $��20(�6D   $��Segoe UI)�6R   ���#8D8D8D �� TextAlignment$ Center=�6}   $����Jelenleg nincsenek üzeneteid. A beszélgetések megkezdése előtt ajánlott bekapcsolni az "üzentek titkosítása"* funkciót.��6�   5�      � 5�      -   5        $ titkositasBeallBTN��5�      $��40��67   $	��227��6C   $
 Hand��6O   $
�� 0 5q�6�   .+�5�      �� ���#F7F8FA$ 19.167��64   $ 19.167��6E   �� 5�      $ ��Titkosítás beállítása��6)   $��Segoe UI)�6I   $��Center=�6_   $��Center=�6z   $��18(�6�   ���#8181816�   5�      � 5�      -   5        $ csevegesKezdeseBTN��5�      $��40��67   $	��227��6C   $
 Hand��6O   $	��0 5q�6�   .+�5�      �� ���#96CBA4$ 19.167��64   $ 19.167��6E   �� 5�      $��Csevegés megkezdése��6)   $��Segoe UI)�6G   $��Center=�6]   $��Center=�6x   $��18(�6�   
�������6�   5�      5�      �� 5�      $4��.*Bővebben erről az adatvédelemben olvashat.��6!   $��Segoe UI)�6W   $��14(�6m   ���#ACACAC$��Bottom=�6�   $��10q�6�   5�      � 5�      $��0��6   
������� 5�        5�      $ 15Q�6'   $	 -90Q�67   $ Quality=�6G   $ 2Q�6_   $ 	#FFE8E8E8��6o    5�      �� 5�      $	��224 �6'   �� 5�      $��* �6'   .+�5�      � $��0��6   .+�5�      �� $��	Üzenetek��6%   $��Center=�68   $
��Left=�6S   $��65 0 0 0q�6n   $��24(�6�   $��Segoe UI)�6�   $
��Bold"�6�   5�      5�      5�      5�      5�      