   M S B A M L   `   `   `  ����H  DUIBotTelegram, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:UIBotTelegramUIBotTelegram  5   	       UIBotTelegram.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -localclr-namespace:UIBotTelegram     5   	     � Title$  UI Telegram Bot��5   	   $	��600��6!   $	��800��6.   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5	      $	��130 �6   .+�5   
   �� -   5         ��Name$ listMessages��5      $��5q�5      $��Stretch=�5      $��Stretch=�5      $��Disabled=�5      ��5      �� 5      .R�5      �� 
���   �$��5q�61   $��1q�6<    �� CornerRadius$ 10��6P   ._�5      �� $��10q�6%   .+�5      �� $��0q�6C   $��12(�6N   ��6(   �� *	FirstName+6N   �� 5      $��0q�6=   $��14(�6H   $
��Wrap=�6V   ��6(   �� *Msg+6V   �� 5      $
��10 0q�5   (   $��10(�5   (   
������� �� TextAlignment$ Right=�5   (   ��5   (   �� *Time+5   (   5      5      5      5      �� 5    
   $��1��6   $��20)�5!      $)��#Отправка сообщений��5"      $��Stretch=�5#      $��Stretch=�5$      $��5q�5%      .��5&      ��  �� Orientation$ Vertical=�6   .+�5'      �� -   5         ��Name$ 
TargetSend��5'      $��5q�5)      $y�Visible=�5*      ��5(      ��  �� ElementName$ listMessages�� �� Path$ SelectedItem.Id�5*      �� 5+      -   5        	 ��Name$	 
txtMsgSend��5+      $��20(�6.   $��5q�6<   �� 5,      $ 
Horizontal=�6   .+�5-      �� -   5        
 ��Name$
 
btnMsgSend��5-      $��20(�5.      $��Отправить��5/      $	��150��50      $��5q�51      52      �� 53      -   5        $
 btnMessageSendAll��53      $��20(�54      $!��Отправить всем��55      $	��200��56      $��5q�57      58      �� 5:      -   5        $
 btnMessageLoad��5:      $��20(�5;      $)��#Загрузка сообщений��5<      $	��200��5=      $��5q�5>      5?      5@      5A      5B      5C      5D      