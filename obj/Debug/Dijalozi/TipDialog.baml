   M S B A M L   `   `   `  ����R  NHCI2018PZ4.3EURA78-2015, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:HCI2018PZ4._3EURA78_2015.Dijalozi!HCI2018PZ4._3EURA78_2015.Dijalozi  5   	   C&clr-namespace:HCI2018PZ4._3EURA78_2015HCI2018PZ4._3EURA78_2015  5	   R   1    +HCI2018PZ4._3EURA78_2015.Dijalozi.TipDialog   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:HCI2018PZ4._3EURA78_2015.Dijalozi     5   	   <	namespace&clr-namespace:HCI2018PZ4._3EURA78_2015     5	   R     � Icon$0  *pack://application:,,,/Images/mainicon.png��5   
    � Title$ Napravi novi tip��5	   	   $	��330��6"   $	��420��6/    � 
ResizeMode$ 	CanResize=�6;   +  %HCI2018PZ4._3EURA78_2015.HelpProvider   HelpKey$ 
dijalogtip��5
   
    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.Help��5      6<   .��5      ��  �� Padding$ 10q�6   ._�5   
   �  � RowDefinitions 5      �� 5      $��* �6    �� 5      $��22 �6    .+�5      � $��0��6   .+�5      �� .+�5      �� -   5        $��idLabel��5       $
��Bold"�6/   Oznaka tipa:6O   �� 5      -   5        $��id��5      $��2q�6A   $��0 2 0 0q�6M   ��6(   ��  �� Path$ Id�6�   �� 5      -   5        $��
nazivLabel��5       $��0 5 0 0q�62   Naziv:6K   �� 5      -   5        $��naziv��5      $��2q�6G   $��0 2 0 0q�6S   ��6+   �� $ Naziv�6�   �� 5      $��0 5 0 0q�6    Opis:69   �� 5      $��2q�69   $��0 2 0 0q�6E   $��80��6V   ��6   �� $
 Opis�6d   �� 5       	 �� Orientation$	 
Horizontal=�6!   $��0 10 0 0q�6:   .+�5!      �� $��5 7 5 5q�6$   
Ikonica:6@   �� 5"      -   5        
 ��Name$
 
btnIzaberi��5"   !   $��5 5 10 5q�6N   $��8 2 9 2q�6`   .��6r   	Izaberi6{   �� 5#      $
��22px��6@   $
��22px��6N   ��6    �� $ Ikonica�6]   5$      5%      5&      �� 5)      $	 
Horizontal=�6   $��1��62   $��RightToLeft=�6?   .+�5,      � $	��160��6    � ColumnDefinitions 5-      �� 5.      �� 5/      .+�56      �� -   5        $
 btnEdit��56   -   $��1��6   $��0 0 0 0q�6T   $��75��6e   .��6p   Izmeni6x   �� 57      -   5        $
 btnAdd��57   -   $��1��6   $��0 0 0 0q�6S   $	��75 ��6d   .��6p   Dodaj6w   �� 58      -	   5        $
 	btnCancel��58   -   $��0��6   $��0 0 1 0q�6X   $��75��6i   .��6t   	Otkaži6|   5;      5<      5?      5D      5E      