   M S B A M L   `   `   `  ����Y  USZBvizsgamunkaChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=07184af3e39363bdS.clr-namespace:SZBvizsgamunkaChat.View.Controls SZBvizsgamunkaChat.View.Controls  5      /    )SZBvizsgamunkaChat.View.Controls.SwitchUC   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:SZBvizsgamunkaChat.View.Controls     5        � 	Resources  5	         moveAnimation �� 
TargetName �� TargetProperty R� KeyTime(  "System.Windows.HorizontalAlignment   Left R� Value   Right<  6System.Windows.Media.Animation.EasingThicknessKeyFrame p� KeyTime p� Value8  2System.Windows.Media.Animation.EasingColorKeyFrame	 �� KeyTime
 �� Value  moveAnimation2��%�  &	        &	 �    �� 5
   
   .��5      T� $
 ball��6,   $, &(FrameworkElement.HorizontalAlignment)�6I   ..�5      i� $ 00:00:00��6)   # Z 6<   i� 5      $ 00:00:00.2000000��6)   # Z 6D   i� 5      $ 00:00:00.3000000��6)   # Z 6D   5      r� 5      $
 ball��6/   $ (FrameworkElement.Margin)�6L   .	�5        $ 00:00:00��6*   $ 2,0,2,0q�6=     5      $ 00:00:00.2000000��6*   $ 40,0,2,0q�6E     5      $ 00:00:00.3000000��6*   $ 2,0,2,0q�6E   5      �� 5      $ 
background��6+   $* $(Shape.Fill).(SolidColorBrush.Color)�6N   .g�5        $	 00:00:00.2000000��6&   $
 	#FFE1E1E1��6A     5      $	 00:00:00.3000000��6&   $
 	#FF96CBA4��6A   5      5      �� 5   
   .��5      T� $
 ball��6,   $, &(FrameworkElement.HorizontalAlignment)�6I   ..�5      i� $ 00:00:00��6)   # Z 6<   i� 5      $ 00:00:00.2000000��6)   # Z 6D   i� 5      $ 00:00:00.3000000��6)   # Z 6D   5      r� 5       $
 ball��6/   $ (FrameworkElement.Margin)�6L   .	�5!        $ 00:00:00��6*   $ 2,0,2,0q�6=     5"      $ 00:00:00.2000000��6*   $ 2,0,30,0q�6E     5#      $ 00:00:00.3000000��6*   $ 2,0,2,0q�6E   5$      �� 5%      $ 
background��6+   $* $(Shape.Fill).(SolidColorBrush.Color)�6N   .g�5&        $	 00:00:00.2000000��6&   $
 	#FF96CBA4��6A     5'      $	 00:00:00.3000000��6&   $
 	#FFE1E1E1��6A   5(      5)      5*      .��5+      � -   5         �Name$ 
switchGrid��5+      $��30��6   $��60��6+    � Cursor$
 Hand��66   .+�5,   
   �� -   5         ��Name$ 
background��5,       �� RadiusY$ 40��6(    �� RadiusX$ 14��65   ���#E1E1E16C   �� 5-   
   -   5        $
 ball��5-      $
��Left=�6"   $	��2 0q�6=   $��26��6K   $��26��6V   $ 40��6b   $ 14��6o   $��Center=�6|   
�������6�   5/      50      