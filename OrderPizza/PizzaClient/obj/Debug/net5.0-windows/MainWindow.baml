   M S B A M L   `   `   `  ����F  BPizzaClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:PizzaClientPizzaClient  5   	       PizzaClient.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:PizzaClient     5   	     � Title$  
MainWindow��5   	   $	��500��6   $	��400��6)   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��4* �6    � RowDefinitions 5   
   �� 5      $��3* �6   �� 5      $��3* �6   �� 5      $��3* �6   �� 5      $��3* �6   �� 5      $��3* �6   �� 5      $��3* �6   �� 5      $��4* �6   .+�5   
   �� $��0��6   $��7��6   ���	#FFF1E7BD6H   �� 5   
   $��0��6   $��Center=�6   $��20(�6:   $��0,15,0,0q�6H   $��Center=�6Z   .��6u   Enter order information:6�   ]� 5   
   $��1��6   $��50,0,0,0q�6!   .+�5      �� $��30��6   $��0,0,0,0q�6    $��14(�6:   .��6I   Name:6P   �� 5      -   5        $��nameTxt��5      $	��200��6%   $��20��61   
�������6R   5       ]� 5"   
   $��2��6   $��50,0,0,0q�6!   .+�5#      �� $��30��6   $��0,0,0,0q�6    $��14(�6:   .��6I   
Surname:6S   �� 5$      -   5        $��
surnameTxt��5$      $	��200��6(   $��20��64   $��0,0,20,0q�6@   
�������6g   5%      ]� 5'   
   $��3��6   $��50,0,0,0q�6!   .+�5(      �� $��30��6   $��0,0,0,0q�6    $��14(�6:   .��6I   
Address:6S   �� 5)      -   5        $��
addressTxt��5)      $	��200��6(   $��20��64   $��0,0,20,0q�6@   
�������6g   5*      ]� 5,   
   $��4��6   $��50,0,0,0q�6!   .+�5-      �� $��30��6   $��0,0,0,0q�6    $��14(�6:   .��6I   	Number:6R   �� 5.      -   5        $��	phonesTxt��5.      $	��200��6'   $��20��63   $��0,0,20,0q�6?   
�������6f   5/      ]� 51   
   $��5��6   $��50,0,0,0q�6!   .+�52      �� $��30��6   $��0,0,0,0q�6    $��14(�6:   .��6I   Pizza:6Q   �� 53      -   5        $��pizzaNameTxt��53      $	��200��6*   $��20��66   
�������6W   54      ]� 56   
   $��6��6   .+�57      �� -   5        $��orderBtn��57      $��70,0,0,0q�6%   $	��120��67   $��30��6C   $��14(�6O   
�������.��6�   Make an Order6�   �� 58      -   5        $��exitBtn��58      $��60��6$   $��30��6/   $��14(�6;   
�������.��6q   Exit6w   59      5:      5;      