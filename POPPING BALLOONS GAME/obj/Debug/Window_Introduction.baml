   M S B A M L   `   `   `  ����P  LPOPPING BALLOONS GAME, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:POPPING_BALLOONS_GAMEPOPPING_BALLOONS_GAME  5   	   /    )POPPING_BALLOONS_GAME.Window_Introduction   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:POPPING_BALLOONS_GAME     5   	   -   5          � Title$  POPPING BALLOONS GAME��5	   	   $	��670��6'   $	��450��64    � 
ResizeMode$ CanMinimize=�6@   .��5
      �� -   5        $��MyCanvas��5
      |�. ���#1C2833.+�5   
   �� -   5        $��lblTitle��5      $��27(�6   $��POPPING BALLOONS GAME��6.   
�������$��	ExtraBold"�6a   
 �� Top$ 28��6x    �� Left$ 29��6�   �� 5   
   $��/images/ICON.png��6   $	��200��6*   $	��200��66   $	 109��6C   $ 68��6U   �� 5   
   -   5        $��lblInstructions��5      $��20(�6   $n��hInstructions: Pop all balloons as long as 
you can and if you missed 10 balloons,
the game will be over.��65   
�������$��Normal"�6�   $	 281��6�   $ 42��6�   $	��112��6�   �� 5   
   -   5        $��lblControls��5      $��20(�6   $R��LControls: Use your mouse to move 
around and left click to pop the balloons.��61   
�������$��Normal"�6�   $	 386��6�   $ 42��6�   $	��112��6�   �� 5   
   -   5        $��btnPlay��5      $
��PLAY��6    
�������$��16(�6B   $
��Bold"�6P    � Cursor$
 Hand��6y   $	 125��6�   $	 488��6�   $��48��6�   $	��193��6�   ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value �#05A2D063   �� 5       � �� 5      �� 5       �� 
TargetType" ��6.   .R�5   "   �� #��z��6)   
���   �$��1q�6g   ._�5   &   �� $��Center=�67   $��Center=�6T   5   #   5      5      	 �� Triggers	 5      P� 5      
 P� Property
 �@J�IsMouseOver P� Value . . �5      ��  � �� �#07B5E86;   5       5"      5$      �� 5&   
   -   5        $��btnHighScores��5&      $��HIGH SCORES��6&   
�������$��16(�6O   $
��Bold"�6]   $
 Hand��6�   $	 125��6�   $	 549��6�   $��48��6�   $	��193��6�   ��5'      �� 5(      " ��6   .�5)      ��  � �� �#05A2D063   �� 5*       � �� 5+      �� 5,      " ��6.   .R�5-   "   �� #��z��6)   
���   �$��1q�6g   ._�5.   &   �� $��Center=�67   $��Center=�6T   5/   #   50      52      	 53      P� 54      
 �@J�IsMouseOver . . �55      ��  � �� �#07B5E86;   56      58      5:      �� 5<   
   -   5        $��btnAudio��5<      $��50��6!   $��50��6,   
������ $
 Hand��6i   $	 385��6w   $	 580��6�   .��5=      �� $/��)pack://application:,,,/Images/unmuted.png��6   5>      5@      5A      