   M S B A M L   `   `   `  ����B  >fishing, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:fishingfishing  5   	   !clr-namespace:fishingfishing  5   	       fishing.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:fishing     5   	   (local1clr-namespace:fishing     5   	   R NOxyPlot.Wpf, Version=2.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0 oxyhttp://oxyplot.org/wpf  5   	     � Title$  
MainWindow��5
   	   $
��1018��6   $
��1000��6*    � 	Resources 5         FocusVisual �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 	
 Style �� 
TargetType �� 
TargetType	 ��Name
 ��Name �� Triggers P� Property P� Value �� 
TargetName��%  &	        &	 �     &	 �     &	 �     &	     &	 6    &	 Y    &	 |    &	 �    &		 �    &	
 �    7   7  7  7  7  7 	 �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$    . #��� ��6J   $��1��6�   $	 1 2R�6�   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FFBEE6FD��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FF2C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   " ��6   .�5      ��  �@�FocusVisualStyle8   61   �� 5        � ��8  6+   �� 5!       � ��8  6,   �� 5"       � ��# � ��6+   �� 5#       � ��$ 1q�60   �� 5$       � ��$ Center=�6;   �� 5%       � ��$ Center=�69   �� 5&       � ��$ 1q�6(   �� 5'       � �� 5(      �� 5)      " ��6&   .R�5*      �� $	 border��6!   #��z��61   #��z��6]   #��z��6�    . ._�5+      �� $
 contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. # z 6�   #��z��6  5,       5-      P� 5.       �@��IsDefaulted . . �5/   "   �� $ border��6@   # � ��6T    � ��50      P� 59       � {� .  . �5:   "   �� $ border��6?   8   � ��6S   �� 5;   "   $ border��6@   8   � ��6T   �� 5<   "   $ contentPresenter��6K   8   � ��6i   5=      5?      5A      5B      5C       � DataContext 5D        fishing.graphs  5E   
   .��5G      � .+�5H   
   � -   5         �Name$
 menu��5H      $
��Left=�6   $
��1000��68   $��-4,-4,-2.4,0q�6F   $	��Top=�6\   $
��1000��6t   ��5I      �� 5J       �� ImageSource$ image/ff_set.png��6   .+�5L      �� -   5         ��Name$ kol_weed��5L      $
��Left=�6(   $��94��6C   $��326,295,0,0q�6O    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��348��6�   $��48(�6�    �� TextAlignment$ Center=�6�    �� TextDecorations 6�   Z� .��6�   ��5M      �� 5N      $ image/ff_kol.png��6!   .��5O   &   5P      �� 5Q      -   5        $ OFish��5Q      $
��Left=�6%   $��93��6@   $��326,629,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $	��348��6�   $��48(�6�   $ Center=�6�   .��6�   ��5R      �� 5S      $ image/ff_kol.png��6!   .��5T   &   5U      �� 5V      -   5        $ BFish��5V      $
��Left=�6%   $��92��6@   $��326,463,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $	��348��6�   $ Center=�6�   $��48(�6�   .��6�   ��5W      �� 5X      $ image/ff_kol.png��6!   .��5Y   &   5Z      �� 5[      -   5         ��Name$ start��5[      $�� ��6$   $
��Left=�6/   $	��Top=�6J   $	��348��6b    �� Left$ 58��6�   
 �� Top$ 51��6�   $��92��6�   $��326,769,0,0q�6�   #��� 
 6�   ��5\      �� 5]      $ image/ff_start.png��6!   5_      5`      �� 5a   
   -   5         ��Name$ scene��5a      $
��Left=�6    $
��1000��6;   $��-4,-4,-2.4,0q�6I   $	��Top=�6_   $
��1000��6w   $y�Hidden=�6�   ��5b      �� 5c      $ image/fish_fon.jpg��6   .+�5e      �� -   5        $
 next��5e      $��
Next round��6#   $	��174��68   $	 722��6D   $ 32��6V   $��44��6f   $y�Hidden=�6r   6�   �� 5f      -   5        $ graph��5f      $��График��6$   $	��174��65   $	 100��6A   $ 32��6S   $��44��6c   $y�Hidden=�6o   6�   �� 5g      -	   5         ��Name$ lb��5g      $�� ��6    $	 450��6+   $ 32��6=   $��64��6M   $��98��6Y   $��18(�6d   5h      � 5j   
   -
   5        $ gf��5j      $
��Left=�6   $	��500��66   $	��Top=�6C   $	��500��6[   $��	97,97,0,0q�6g   $y�Hidden=�6z   .+�5k        OxyPlot.Wpf.Plot  -   5          Name$ plot1��5k      $��
24,0,10,48q�6>      Title 6&   �� *Title+   Series. 5l        OxyPlot.Wpf.LineSeries  ��6!   �� *	orangef+  5m      ��6!   �� *bluef+  5n      ��6!   �� *tango+5o      5p      5q      5v      