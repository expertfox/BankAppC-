   M S B A M L   `   `   `  ����K  GPresentationTier, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:PresentationTierPresentationTier  5   	   #    PresentationTier.Transactions   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:PresentationTier     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	    � Title$ Bank Application��5   	   $	��450��6"   $	��800��6/   .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ -2,-2&�63   .��5      �  � Color$ 	#FFA0BAFF��6    � Offset$	 0.7Q�61   � 5      $ 	#FF4C1BF1��6   $ 1Q�61   5      .+�5    
   #  MaterialDesignThemes.Wpf.Card    PrimaryHueDarkBrush#���  5!       ! PrimaryHueDarkForegroundBrush#���  5"      $��8q�5#         UniformCornerRadius$ 0Q�5$      $��10,10,647,348q�6'   .��5%      �� -   5         ��Name$ UserIDHolder��5%      $
��Wrap=�5&      5(      5)      � 5,   
   $
��Left=�6   $	��156��6*   $��	0,76,0,10q�66   	 � RowDefinitions	 5-      �� 5.      $
��167* �6    �� 5/      $
��166* �6    .+�53      �� -   5         $  MaterialDesignRaisedAccentButton#��[ 54      $	��150��55      +  %MaterialDesignThemes.Wpf.ButtonAssist
   CornerRadius$
 	0 10 10 0��56      $��Center=�57   &   $��USER DETAILS��6J   $��0,7,0,10q�6a   ���	#FFFFFFFF$��Microsoft JhengHei UI)�6�   ��58      �� 59      $
 0,-2&�6*   $	 1,2&�6:   .��5:      � $ 	#FF8F8F8F��6'   � 5;      $ 	#FF6E9ADA��6'   $ 0.513Q�69   5<      5>      �� 5?      -   5        #��[ 5@      $
��Auto��5A      $
 	0 10 10 0��5B      $��1��5C      $��Center=�65   $��BANK ACCOUNTS��6Y   ���	#DDFFFFFF$��14(�6�   $��Microsoft JhengHei UI)�6�   $��0,6,0,10q�6�   ��5D      �� 5E      $
 0,-2&�6*   $	 1,2&�6:   .��5F      � $ 	#FF8F8F8F��6'   � 5G      $ 	#FF6E9ADA��6'   $ 0.513Q�69   5H      5L      5M      � 5N   
   $
��Left=�6   $	��279��6*   $��177,130,0,0q�67   $	��Top=�6L   $	��255��6d   .+�5P      � $
��Left=�6   $	��279��6.   $	��Top=�6;   $	��255��6S   ���	#41FFFFFF.+�5Q        $��Center=�5R      #���  5S      #���  5T      $��8q�5U      $ 0Q�5V      $��	0,0,0,244q�6/   $	��255��6B   .��5W      �� $
��Wrap=�5X      $��Transactions��6)   $��
81,0,80,-6q�6=   $��Microsoft YaHei UI)�6Q   5Y      �� 5Z      $��	0,40,0,62q�6   .��5[      �� -   5         ��Name$ TransactionListView��5[   5   ���	#FFFFFFFF��6R   �� ��5\      �� 5]      .R�5^   "   ��  �� Orientation$ 
Horizontal=�6-   $��2q�6F   .+�5_   &   �� ��60   �� 5`   #   5a      5c      5d      �� 5e      $
��Wrap=�5f      $o��iCreate transactions and Update with Receiver account ID and amount. Processing is Automated after closing��6)   $��10,222,10,0q�6�   $��Microsoft YaHei UI)�6�   ���	#DDEEDBDB6�   5h      5j      � 5k   
   $
��Left=�6   $��49��6*   $��
177,76,0,0q�66   $	��Top=�6J   $	��255��6b   ���	#FF512DA8 � ColumnDefinitions 5l      �� 5m      $
��196* �6#   �� 5n      $	��59* �6#   .+�5p      ��  $  MaterialDesignHeadline5TextBlock#��[ 5q      $��Microsoft JhengHei UI)�6K    �� TextAlignment$ Center=�6n   $��Add Transaction��6�   $��	3,10,0,10q�6�   ���	#DDFFFFFF6�   �� 5r      -   5         . *MaterialDesignFloatingActionMiniDarkButton#��[ 5s       � ToolTip$ Click to Deposit��5t      $��5,0,0,0q�66   ���	#FF6F9AD7$��1��6z   $��49��6�   $
��Auto��6�   $	��Top=�6�   .��5v      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	AddCircle=�5w   !   $��24��5x   !   $��24��5y   !   5z      5|      � 5}   
   $
��Left=�6   $	��333��6*   $��
432,76,0,0q�67   $	��Top=�6K   $	��350��6c   .+�5~      � $
��Left=�6   $��40��6.   $��	23,10,0,0q�6:   $	��Top=�6M   $	��301��6e    5      �� 5�      $��4* �6'   �� 5�      $��3* �6'   .+�5�      �� $��Transacation ID: ��6   ���	#FFE8E8E8$��Microsoft JhengHei UI)�6L   $��22(�6o   �� 5�      -   5        $ transactionIDHolder��5�      $��1��69   $��18(�6I   $��Corbel)�6W   
�������$��10,0,0,0q�6   5�      � 5�      $
��Left=�6   $	��206��6.   $��	23,55,0,0q�6;   $	��Top=�6N   $	��301��6f   	 5�      �� 5�      $	��34* �6$   �� 5�      $	��34* �6$   �� 5�      $	��35* �6$   .+�5�      �� -   5         ��Name$ 	txtSender��5�      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Enter Sender ID��5�      .  (MaterialDesignThemes.Wpf.TextFieldAssist   TextBoxViewMargin$ 1 0 1 0q�5�         FloatingScale$
 0.50Q�5�       % !MaterialDesignFloatingHintTextBox#��[ 5�      $��24(�5�      ���	#DDFFFFFF6%   �� 5�      -	   5        $ txtReceiver��5�      $ Enter Receiver ID��5�      $ 1 0 1 0q�5�      $
 0.50Q�5�      #��[ 5�      $��24(�5�      ���	#DDFFFFFF$��1��6<   �� 5�      -
   5        $ 	txtAmount��5�      $ Amount(Rs.)��5�      $ 1 0 1 0q�5�      $
 0.50Q�5�      #��[ 5�      $��24(�5�      ���	#DDFFFFFF$��0,2,0,0q�6<   $��2��6M   5�      � 5�      $
��Left=�6   $��46��6.   $��
23,277,0,0q�6:   $	��Top=�6N   $	��301��6f    5�      �� 5�      $
��150* �6'   �� 5�      $
��151* �6'   .+�5�      �� -   5         ��Name$ UpdateButton��5�       " MaterialDesignRaisedDarkButton#��[ 5�      {�.  $��46��5�      $
 25��5�      $ Updates details��5�      $	��Top=�6M   $��	40,0,10,0q�6e   .��5�      �� $��UPDATE��5�      5�      �� 5�      -   5        $ ClearButton��5�      #��[ 5�      $��46��5�      {�.  $
 25��5�      $ Clears the fields��5�      $��	10,0,41,0q�6N   $��1��6a   $	��Top=�6q   .��5�      �� $��CLEAR��5�      5�      5�      5�      � 5�   
   $
��Left=�6   $��61��6*   $��
261,10,0,0q�66   $	��Top=�6J   $	��439��6b   .+�5�      �� #��[ 5�      $��Microsoft JhengHei UI)�6K   $ Center=�6n   $��TRANSACTIONS��6�   $��	3,10,0,10q�6�   ���	#CCECECEC$
��Bold"�6�   $��36(�6�   5�      5�      5�      