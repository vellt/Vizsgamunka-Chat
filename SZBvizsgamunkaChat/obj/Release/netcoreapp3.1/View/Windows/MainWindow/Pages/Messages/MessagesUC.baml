   M S B A M L   `   `   `  ���� Y  USZBvizsgamunkaChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=07184af3e39363bd�Gclr-namespace:SZBvizsgamunkaChat.View.Windows.MainWindow.Pages.Messages9SZBvizsgamunkaChat.View.Windows.MainWindow.Pages.Messages  S.clr-namespace:SZBvizsgamunkaChat.View.Controls SZBvizsgamunkaChat.View.Controls  M+clr-namespace:SZBvizsgamunkaChat.View.IconsSZBvizsgamunkaChat.View.Icons  J    DSZBvizsgamunkaChat.View.Windows.MainWindow.Pages.Messages.MessagesUC   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     YlocalGclr-namespace:SZBvizsgamunkaChat.View.Windows.MainWindow.Pages.Messages     Ccontrols.clr-namespace:SZBvizsgamunkaChat.View.Controls     =icons+clr-namespace:SZBvizsgamunkaChat.View.Icons       � 	Resources   ��Name   Storyboard1 �� 
TargetName �� TargetProperty<  6System.Windows.Media.Animation.EasingThicknessKeyFrame p� KeyTime p� Value  Storyboard2��%�  &	        &	 �     �� $ 
storyboard��.��r� $ menuBTN��$ (FrameworkElement.Margin)�.	�  $ 00:00:00��$ 0,0,10,0q�  $ 00:00:00.1000000��$ 0,0,30,0q�  $ 00:00:00.2000000��$ 0,0,70,0q�  $ 00:00:00.3000000��$ 0,0,90,0q��� .��r� $ menuBTN��$ (FrameworkElement.Margin)�.	�  $ 00:00:00��$ 0,0,90,0q�  $ 00:00:00.1000000��$ 0,0,30,0q�  $ 00:00:00.2000000��$ 0,0,0,0q�.��� .+�� -    �Name$ uzenetContainerGR�� � ColumnDefinitions �� $	��480 ��� $��* �.+�� -   $ MessageContentGR��
�������$��1��.+��  � RowDefinitions �� $��90 ��� $��* ��� $
��auto �.+��� $��1��$��Disabled=�$��Visible=�.���� -   $��messagesHolderSP��$
��0 40q�
�������� $��2��$��66��$	��200��
������� �� $��* ��� $��80 �.+�� $��0��
�������$��25 0 0 0q�.+��� -   	 ��Name$	 uzenetHatter��$(��"Üzenet írásához kattints ide..��$��Center=�$	��2 0q�$��Segoe UI)�$��14(����#707070�� $
��Auto=�$��Disabled=�$
��0,18q�.���� -   
 ��Name$
 TextBoxUzenet��
������ $��0q����#707070$��Segoe UI)�$��14(�$��Center=� �� TextWrapping$
 Wrap=�� -   $ sendButtonGR��$��2�� � Cursor$
 Hand��
�������$��Bottom=�$��0 0 0 13q�.+��� $��40��$��40�� �� RadiusY$ 40�� �� RadiusX$ 40�����#96CBA4*   $SZBvizsgamunkaChat.View.Icons.SendUC  $��18��$��5 0 0 0q�� -   $ headerGR��$��0��
������� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 15Q�   	Direction$	 -90Q�   ShadowDepth$ 2Q�   Color$ 	#FFE8E8E8��   RenderingBias$ Quality=� �� $
��auto ��� $��* �.+�� $��0�� �� $��* ��� $
��auto ��� $��* �.+��� $��0��$��Bottom=�$��Segoe UI)�$��20(�$
��25 0q�����  �� Path$ Fullname� �� Mode$ TwoWay=��� $��1��$��Bottom=�$��Segoe UI)�$��20(�$
��25 0q����� $
 Name�$ TwoWay=��� $��2�� �� Orientation$ 
Horizontal=�$
��25 0q�.+��� $��Utoljára online: ��$	��Top=�$��Segoe UI)�$��14(����#707070�� $	��Top=�$��Segoe UI)�$��14(����#707070���� $ ProfileLastSeen�$ TwoWay=�� -   $ deleteMessageBTN��$��1��$��90��$��Right=�$
 Hand�����#EC6D6D.+�)   #SZBvizsgamunkaChat.View.Icons.BinUC  $��22��� -	   $ menuBTN��$��1��$��91��$��Right=�
�������$
 Hand��$y�Visible=�$��0,0,0,0q�.+��� $��40��$��40��$ 40��$ 40��
�������$y�	Collapsed=�*   $SZBvizsgamunkaChat.View.Icons.MenuUC  $��22��� $��0��
�������   $ 15Q�$	 -90Q�$ 2Q�$ 	#FFE8E8E8��$ Quality=� �� $��90 ��� $��* �.+�� $��1��.+��� $
��Auto=�$��Disabled=�.���� .+��� -
    ��Name$ normalListaSP��.+�� -   $ NewMessageBox��
��������� -   $ 
MessageBox��
��������� -   $ szurtListaSP��� -   $ 
plusButton��$��Bottom=�$��20q�$��Right=�$
 Hand��   $ 15Q�$	 -90Q�$ 2Q�$ 	#FFE8E8E8��$ Quality=�.+��� $��50��$��50�����	#FF96CBA4$ 50��$ 50��*   $SZBvizsgamunkaChat.View.Icons.PlusUC  $��20��� $��0��
�������.+�2   ,SZBvizsgamunkaChat.View.Controls.SearchBarUC  -     Name$ 	SearchBar��2   ,SZBvizsgamunkaChat.View.Controls.SearchBarUC   DataContextChanged$$ SearchBarUC_DataContextChanged��$
��25 0q�� $��1��� -   $ fedlapGR��$y�	Collapsed=� �� $��90 ��� $��* �.+�� $��1��
�������.+��� $��Center=�$��Center=�.+�� .+�.	   (SZBvizsgamunkaChat.View.Icons.SecurityUC	  $��71��� $��	0 30 0 85q�.+��� $
��Wrap=�$	��646��$��20(�$��Segoe UI)����#8D8D8D �� TextAlignment$ Center=�$����Jelenleg nincsenek üzeneteid. A beszélgetések megkezdése előtt ajánlott bekapcsolni az "üzentek titkosítása"* funkciót.��� -   $ titkositasBeallBTN��$��40��$	��227��$
 Hand��$
�� 0 5q�.+��� ���#F7F8FA$ 19.167��$ 19.167���� $ ��Titkosítás beállítása��$��Segoe UI)�$��Center=�$��Center=�$��18(����#818181� -   $ csevegesKezdeseBTN��$��40��$	��227��$
 Hand��$	��0 5q�.+��� ���#96CBA4$ 19.167��$ 19.167���� $��Csevegés megkezdése��$��Segoe UI)�$��Center=�$��Center=�$��18(�
��������� $4��.*Bővebben erről az adatvédelemben olvashat.��$��Segoe UI)�$��14(����#ACACAC$��Bottom=�$��10q�� $��0��
�������   $ 15Q�$	 -90Q�$ Quality=�$ 2Q�$ 	#FFE8E8E8�� �� $	��224 ��� $��* �.+�� $��0��.+��� $��	Üzenetek��$��Center=�$
��Left=�$��65 0 0 0q�$��24(�$��Segoe UI)�$
��Bold"�