   M S B A M L   `   `   `  ����P  LPOPPING BALLOONS GAME, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:POPPING_BALLOONS_GAMEPOPPING_BALLOONS_GAME  5   	   -    'POPPING_BALLOONS_GAME.Window_HighScores   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:POPPING_BALLOONS_GAME     5   	   -   5          � Title$  POPPING BALLOONS GAME��5	      $	��560��6*   $	��525��67    � 
ResizeMode$ CanMinimize=�6C   .��5
      �� -   5        $��MyCanvas��5
      |�. ���#1C2833.+�5   
   �� -   5        $��lblTitle��5      $��30(�6   $��HIGH SCORES��6.   
�������$
��Bold"�6W   
 �� Top$ 13��6i    �� Left$	 150��6y   $	��112��6�   �� 5   
   -   5        $��lblTop10Only��5      $��23(�6   $��Top 10 only��62   ���#05A2D0$
��Bold"�6]   $ 63��6o   $	 193��6   $	��112��6�   �� 5   
   -   5        $��lblRankHeaderAndContent��5      $��20(�6   $
��Rank��6>   
�������$��Normal"�6`   $	 110��6t   $ 60��6�   $	��315��6�   �� 5   
   -   5        $��lblDateHeaderAndContent��5      $��20(�6   $��	     Date��6=   
�������$��Normal"�6d   $	 110��6x   $	 193��6�   $	��315��6�   �� 5   
   -   5        $��lblScoreHeaderAndContent��5      $��20(�6   $��Score��6>   
�������$��Normal"�6a   $	 110��6u   $	 382��6�   $	��315��6�   �� 5   
   -   5        $��btnBack��5      $
��BACK��6    
�������$��16(�6B   $
��Bold"�6P    � Cursor$
 Hand��6b   $ 20��6�   $	 455��6�   $��48��6�   $	��130��6�    J� RenderTransformOrigin$ 0,0.479&�6�   ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value �#05A2D063   �� 5       � �� 5      �� 5      	 �� 
TargetType"	 ��6.   .R�5   "   �� #��z��6)   
���   �$��1q�6g   ._�5   &   �� $��Center=�67   $��Center=�6T   5   #   5      5      
 �� Triggers
 5      P� 5        P� Property �@J�IsMouseOver P� Value . . �5!      ��  � �� �#07B5E86;   5"      5$      5&      5(      5)      