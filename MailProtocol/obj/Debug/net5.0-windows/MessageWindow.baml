   M S B A M L   `   `   `  ����G  CMailProtocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MailProtocolMailProtocol  5   	        MailProtocol.MessageWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:MailProtocol     5   	     � Title$  MessageWindow��5   	   $	��450��6   $	��800��6,   .��5	      ]� .+�5
   
   � $	��Top=�6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $��40 �6    �� 5      $��40 �6    .+�5      �� $��Center=�6   $��0��66   $��0��6F   .��6S   To:6X   �� 5      -   5        $��toTxtBox��5      $��5q�6&   $��Center=�61   $��1��6S   $��0��6c   ���	#FFE7E5E56�   �� 5      $��Center=�6   $��0��66   $��1��6F   .��6S   
Subject:6]   �� 5      -   5        $��subjectTxtBox��5      $��5q�6+   $��Center=�66   $��1��6X   $��1��6h   ���	#FFE5E2E26�   5      �� 5   
   $	��Top=�6    �� TextAlignment$ Center=�6)   $��32(�6@   Enter your text here:6e   �� 5   
   -   5        $��Bottom=�5   '   $��8q�6?   $��20(�6K   $
��Bold"�6Y   ���	#FF5C9199.��6�   Send6�   �� 5   
   -   5        $��
bodyTxtBox��5      $��5q�6$    �� TextWrapping$
 Wrap=�6/    �� AcceptsReturn$
 True��6C   ���	#FFCEDDD66q   5      5      