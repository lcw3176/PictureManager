   M S B A M L   `   `   `  ����I  EPictureManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:PictureManagerPictureManager  5   	       PictureManager.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:PictureManager     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � WindowStyle$
 None=�65    � AllowsTransparency . $��1q�6c   .��5	      � .+�5
   
   � -   5        $
��Left=�5
      $��9��6/   $	��Top=�6:   $	��627��6R   ���	#FFC72626$��	171,0,0,0q�6u   6�   � 5   
   $
��Left=�6   $	��450��6/   $	��Top=�6<   $	��171��6T   ���	#FFAB2323 � Orientation$ Vertical=�6w   .+�5      �� -   5         ��Name$ label��5      $��Picture��6#   $	��105��65   $	��168��6B   $��36(�6N   $��Haan Sollip B)�6\   $��SemiBold"�6w   $��Center=�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   ���#FFF6�   �� 5      -   5         ��Name$ 
sortButton��5      $��55��6)   $	��171��65   ���	#FFC72626$��0q�6X   .��5      ��  �� Orientation$ 
Horizontal=�6   $	��171��66   .+�5      �� $��사진 정렬하기��6    $��15��6/   $	��110��6;    �� TextAlignment$
 Left=�6G   $��5q�6\   ���#FFF6{   �� 5      $��./resource/camera.png��6   $��5q�6;   6H   5      5      �� 5      -   5        $ 
loadButton��5      $��55��6)   $	��171��66   ���	#FFC72626$��0q�6Y   .��5      �� $ 
Horizontal=�6   $	��171��66   .+�5      �� $��폴더 불러오기��6    $��15��6/   $	��110��6;   $
 Left=�6G   $��5q�6\   ���#FFF6{   �� 5      $��./resource/directory.png��6   $��5q�6>   6K   5      5      �� 5      -   5        	 ��Name$	 listBox��5      $	��200��6'   ���	#FFB13D3D$��1q�6K   ���#FFF6_   � 5      -   5        
 �Name$
 progressBar��5      $��34��6/   $��0q�6;   5      �� 5    
   -   5        $ 
exitButton��5       $��Right=�6%   $��20��6A   $��	739,9,6,0q�6M   $	��Top=�6`   ���#FFF$��30��6�   $��0q�6�   .��5!      �� $ 
Horizontal=�6   .+�5"      �� -   5        $��./resource/power.png��5"      6g   5#      5$      �� 5%   
   -	   5         ��Name$ image��5%      $
��Left=�6   $	��353��6:   $��
214,40,0,0q�6G   $	��Top=�6[   $	��545��6s   �� 5&   
   -
   5        $ 
leftButton��5&      $��<-��6%   $
��Left=�65   $��422,393,0,15q�6P   $��50��6g   $��30(�6r   $��Center=�6�   $��0q�6�   
������ 6�   �� 5'   
   -   5        $ rightButton��5'      $��->��6&   $
��Left=�66   $��477,393,0,15q�6Q   $��50��6h   $��30(�6s   $��Center=�6�   $��0q�6�   
������ 6�   5*      5+      