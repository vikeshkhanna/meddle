   M S B A M L   `   `   `  ����  iTunesHello    iTunesHello.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
MainWindow��5   	   $	��625��6   $
��1035��6)    J� Opacity$
 0.95Q�66    � WindowStyle$
 None=�6E   
���   � � 
ResizeMode$ CanMinimize=�5   	    � AllowsTransparency .  � WindowState$ 	Maximized=�6=    � 	Resources 5       �� 
TargetType �� Property	 �� Value
 �� BasedOn   LeftPaneStyle��%�   '��       &	  q     7���� 5   
   " ��6   .�5	      ��  � ��
	 �����6+   �� 5
       � ��$	 Segoe)�6+   5      �� 5   
   8
   " ��6:   .�5      ��  � ��$	 Right=�64   �� 5       � ��$	 14(�6)   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��20px �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ songTitleMainLabel��5      $��20,0,0,0q�5      $��1��6"   $��1��6/   $	��Top=�6?   $
��Left=�6W   $��28(�5      .��6:   Title6A   �� 5    
   $��40,0,0,0q�6   $��2��6(   $��0��65    �� Orientation$ Vertical=�6E   .+�5!      �� -   5         ��Name$ artworkImage��5!   0   $��Right=�6   $
��Auto��6F   $
��Auto��6S   $	��256��6a   $	��256��6p   $7��1/iTunesHello;component/images/default_artwork.png��6�   �� 5"      $��0,10,0,0q�6   $ Vertical=�6+   $��Right=�6B   .+�5#      �� -   5        $ songTitleLabel��5#   ?   #��[  6   .��6W   " Jenny from the black feath adada6y   �� 5$      -   5        $ songArtistLabel��5$   ?   #��[  6   .��6X   Artist6`   5%      5&      �� 5'   
   $	��Top=�6T   $��2��5(      $��1��6"   $
��Left=�62   ��5'      ��  �� ElementName$ songTitleMainLabel�� �� Path$ Margin�.+�5)      �� $
��Auto=�6   $
��Auto��6>   $	��400��6L   $	��600��6[   .��5*      �� -   5        $ songLyricsLabel��5*      $��12(�61   6A   5+      �� 5,      $	��400��6    �� Orientation$ Vertical=�6%     MetroScrollBar#��[ 6<   5-      5.      50      51      