   M S B A M L   `   `   `  ���� Y  USZBvizsgamunkaChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=07184af3e39363bdi9clr-namespace:SZBvizsgamunkaChat.View.Windows.FirstWindow+SZBvizsgamunkaChat.View.Windows.FirstWindow  O,clr-namespace:SZBvizsgamunkaChat.View.AlertsSZBvizsgamunkaChat.View.Alerts  S.clr-namespace:SZBvizsgamunkaChat.View.Controls SZBvizsgamunkaChat.View.Controls  9    3SZBvizsgamunkaChat.View.Windows.FirstWindow.LoginUC   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Klocal9clr-namespace:SZBvizsgamunkaChat.View.Windows.FirstWindow     ?dialog,clr-namespace:SZBvizsgamunkaChat.View.Alerts     Bcontrol.clr-namespace:SZBvizsgamunkaChat.View.Controls     $	��620��$
��1076��  � 	Resources     termsVisibleSB �� 
TargetName �� TargetProperty<  6System.Windows.Media.Animation.EasingThicknessKeyFrame p� KeyTime p� Value8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value R� KeyTime  System.Windows.Visibility   Visible	 R� Value  termsCloseSB
   	Collapsed��%*  &	        &	     �� .��r� $ termsDialogUC��$ (FrameworkElement.Margin)�.	�  $ 00:00:00��$ 	0,600,0,0q�  $ 00:00:00.2000000��$ 	0,100,0,0q�  $ 00:00:00.4000000��$ 0,0,0,0q��� $ termsGR��$0 *(Panel.Background).(SolidColorBrush.Color)�.g�  $ 00:00:00��$ Transparent��  $ 00:00:00.2000000��$ Transparent��  $ 00:00:00.4000000��$C =sc#0.09999996, 4.76837158E-07, 4.76837158E-07, 4.76837158E-07��T� $ termsGR��$ (UIElement.Visibility)�..�i� $ 00:00:00��#	 Z �� .��r� $ termsDialogUC��$ (FrameworkElement.Margin)�.	�  $ 00:00:00��$ 0,0,0,0q�  $ 00:00:00.2000000��$ 	0,100,0,0q�  $ 00:00:00.4000000��$ 	0,600,0,0q��� $ termsGR��$0 *(Panel.Background).(SolidColorBrush.Color)�.g�  $ 00:00:00��$C =sc#0.09999996, 4.76837158E-07, 4.76837158E-07, 4.76837158E-07��  $ 00:00:00.2000000��$ Transparent��  $ 00:00:00.4000000��$ Transparent��T� $ termsGR��$ (UIElement.Visibility)�..�i� $ 00:00:00.4000000��#	 Z
 .��� .+��  � RowDefinitions �� $��60 ��� $	��440 ��� $��* �.+�� $��0��.+�-   'SZBvizsgamunkaChat.View.Controls.LogoUC  -     Name$
 logo��   SubName$$ Éld át a közösség erejét��$
��60 0q�$��Bottom=�$
��Left=�
�������$
��auto�� � Cursor$
 Hand��� $��1�� � ColumnDefinitions �� $��50 ��� $��* ��� $	��648 �.+�� -   $��	formsGrid��$��1��.+��� $��Center=�.+�0   *SZBvizsgamunkaChat.View.Controls.TextBoxUC  -     Name$ usernameOrEmailTXT��0   *SZBvizsgamunkaChat.View.Controls.TextBoxUC   DataContextChanged$+ %usernameOrEmailTXT_DataContextChanged��   PlaceHolder$" Felhasználónév vagy email��$
��0 10q�/   )SZBvizsgamunkaChat.View.Controls.PwdBoxUC  -     Name$ passwordTXT��/   )SZBvizsgamunkaChat.View.Controls.PwdBoxUC   DataContextChanged$$ passwordTXT_DataContextChanged��   PlaceHolder$ Jelszó��$
��0 10q�� .+��� $
��Left=� �� Orientation$ 
Horizontal=�$	��0 5q�.+�1	   +SZBvizsgamunkaChat.View.Controls.CheckBoxUC	  1
   +SZBvizsgamunkaChat.View.Controls.CheckBoxUC 
  DataContextChanged$( "CheckBoxControl_DataContextChanged��$��21.5 0 10 0q��� $��Emlékezz rám��$��Segoe UI)����#707070$��15(�$��Center=�� $��Right=�$��21.5 0q�
�������$
 Hand��.+��� $��Elfelejtetted a jelszót?��$��Segoe UI)����#707070$��15(�$��Center=�2   ,SZBvizsgamunkaChat.View.Controls.BigButtonUC  2   ,SZBvizsgamunkaChat.View.Controls.BigButtonUC   PreviewMouseUp$ BigButton_PreviewMouseUp��   Text$ 	Belépés��$��	0 35 0 15q�� .+��� $ 
Horizontal=�$��Center=�.+��� $��Még nincs fiókod? ��$��Segoe UI)�$��15(����#707070� -   $��regGrid��
�������$
 Hand��.+��� $��Kattints ide��$��Segoe UI)�$��15(����#96CBA4��}� � $��2��.+��� $��Bottom=�$��11q�$ 
Horizontal=�.+��� -    ��Name$ termsBTN��$!��felhasználási feltételek��$��Segoe UI)�$��11(����#B2B2B2
�������$
 Hand����}� �� $�� • ��$��Segoe UI)�$��11(����#B2B2B2�� -   $ 
privacyBTN��$��adatvédelmi szabályzat��$��Segoe UI)�$��11(����#B2B2B2
�������$
 Hand����}� �� $�� • ��$��Segoe UI)�$��11(����#B2B2B2�� $��CHAT APP © 2021��$��Segoe UI)�$��11(����#B2B2B2� .+�-   'SZBvizsgamunkaChat.View.Alerts.DialogUC  -     Name$ dialogUC��$y�	Collapsed=�� -	    �Name$ termsGR��
������ $y�	Collapsed=�$��0,0,0,0q�.+�2   ,SZBvizsgamunkaChat.View.Alerts.TermsDialogUC  -
     Name$ termsDialogUC��$��Bottom=�$��0,0,0,0q�