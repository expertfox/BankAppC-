   M S B A M L   `   `   `  ����K  GPresentationTier, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:PresentationTierPresentationTier  5   	   "    PresentationTier.UserAccount   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:PresentationTier     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	    � Title$ Bank Application��5   	   $	��450��6"   $	��800��6/   .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ -2,-2&�63   .��5      �  � Color$ 	#FFA0BAFF��6    � Offset$	 0.7Q�61   � 5      $ 	#FF4C1BF1��6   $ 1Q�61   5      .+�5   
   #  MaterialDesignThemes.Wpf.Card    PrimaryHueDarkBrush#���  5       ! PrimaryHueDarkForegroundBrush#���  5       $��8q�5!         UniformCornerRadius$ 0Q�5"      $��10,10,647,348q�6'   .��5#      �� -   5         ��Name$ UserIDHolder��5#      $
��Wrap=�5$      5&      5'      � 5)   
   $
��Left=�6   $	��156��6*   $��	0,76,0,10q�66   	 � RowDefinitions	 5*      �� 5+      $
��167* �6    �� 5,      $
��166* �6    .+�5.      �� -   5         $  MaterialDesignRaisedAccentButton#��[ 5/      $	��150��50      +  %MaterialDesignThemes.Wpf.ButtonAssist
   CornerRadius$
 	0 10 10 0��51      $��Center=�52   &   $��USER DETAILS��6J   $��0,7,0,10q�6a   ���	#DD000000$��Microsoft JhengHei UI)�6�   $
��Bold"�6�   ��53      �� 54      $
 0,-2&�6*   $	 1,2&�6:   .��55      � $ 	#FF8F8F8F��6'   � 56      $ 	#FFF3F3F3��6'   $ 0.513Q�69   57      59      �� 5:      -   5        #��[ 5;      $
��Auto��5<      $
 	0 10 10 0��5=      $��Center=�6]   $��BANK ACCOUNTS��6�   ���	#DDFFFFFF$��14(�6�   $��Microsoft JhengHei UI)�6�   $��0,6,0,10q�6�   $��1��6�   ��5>      �� 5?      $
 0,-2&�6*   $	 1,2&�6:   .��5@      � $ 	#FF8F8F8F��6'   � 5A      $ 	#FF6E9ADA��6'   $ 0.513Q�69   5B      5F      5G      � 5H   
   $
��Left=�6   $	��399��6*   $��
182,10,0,0q�67   $	��Top=�6K   $	��600��6c    J� Opacity$	 0.9Q�6o   .+�5J      � $
��Left=�6   $��107,10,0,341q�6.   $	��386��6D   .+�5K      ��  $  MaterialDesignHeadline4TextBlock#��[ 5L      $��Center=�6O   $��Microsoft JhengHei UI)�6l   $
��Bold"�6�   ���	#DDCFCFCF$
��76,0q�6�   USER DETAILS5N      5O      � 5P      $	��234��6   $��107,80,107,0q�6    $	��Top=�66   .+�5R      � $��74��6   $��157,10,157,0q�6#   $	��Top=�69   .+�5S      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ AccountCircle=�6.   $��74��6C   $��72��6O   5T      � 5U      $
��Left=�6   $��52��62   $��	79,97,0,0q�6>   $	��Top=�6Q   $	��225��6i   .+�5V      �� -   5         ��Name$ txtFname��5W      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
First Name��5X      .  (MaterialDesignThemes.Wpf.TextFieldAssist   TextBoxViewMargin$ 1 0 1 0q�5Y         FloatingScale$
 0.50Q�5Z      $�� ��5[       % !MaterialDesignFloatingHintTextBox#��[ 5\      $��24(�5]      ���	#DDFFFFFF6%   5_      � 5`      $
��Left=�6   $��55��62   $��
79,154,0,0q�6>   $	��Top=�6R   $	��225��6j   .+�5a      �� -   5        $ txtLname��5b      $ 	Last Name��5c      $ 1 0 1 0q�5d      $
 0.50Q�5e      $�� ��5f      #��[ 5g      $��24(�5h      ���	#DDFFFFFF �� 
CaretBrush �	#FF46159B6<   5i      5j      � 5k      $��80��6   $��107,319,107,0q�6   $	��Top=�66   .+�5l      � $��49,0,202,10q�6   .+�5m      �� -   5         " MaterialDesignRaisedDarkButton#��[ 5n      $��50��5o      $
 25��5p       � ToolTip$ Clears the fields��5q      .��5r      �� $��CLEAR��5s      5t      5u      � 5v      $��202,0,49,10q�6   .+�5w      �� -   5        #��[ 5x      $��50��5y      $
 25��5z      $ Updates details��5{      .��5|      �� $��UPDATE��5}      5~      5      5�      5�      5�      5�      