   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	    Youtube music"   Youtube_music_WPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   -   5          � 
ResizeMode$  NoResize=�5	   	    � Title$ 
MainWindow��5   	   $	��720��6   $
��1000��6)   .��5      � .+�5   
   �� -   5        $
��Send��5      $��50��5      $��right=�5      $��0,5,10,0q�5      $	��Top=�5      $	��120��5      $��18(�5      .��5   '   Search6/   �� 5   
   -   5        $��	searchBox��5      $
��Left=�5      $��50��5      $��10,5,0,0q�5       �� TextWrapping$
 Wrap=�5      $��SEARCH MUSIC HERE    :)��5      $	��Top=�5      $	��840��5      $��32(�5      
�������.��5"   *   5$      �� 5(   
   -   5         ��Name$ cResData��5(      $��Right=�5)      $	��400��5*      $��	0,60,10,0q�6   $	��Top=�5+      $	��260��6%   $��Disabled=�5,      ��5.      �� 5/      .R�50      ��  �� Orientation$ 
Horizontal=�6!   .+�51      �� $��64��6=   ��6    �� *	thumbnail+6=   �� 52       �� TextAlignment$ Center=�6$   $��18(�6;   $��	10,16,0,0q�6I   ��6\   �� *name+53      54      57      �� 59   
   -   5        $ vResData��59      $
��Left=�5:      $	��560��5;      $	��700��6   $��	10,60,0,0q�5<      $	��Top=�5=      $��Disabled=�5>      $��Hidden=�5?      ��5A      �� 5B      .R�5C      �� $ 
Horizontal=�6!   .+�5D      �� $	��128��6=   ��6    �� *	thumbnail+6K   � 5E      .+�5F      �� $��18(�6D   $��10,5,0,0q�6R   ��6(   �� *	videoname+6R   �� 5G      $
 Left=�6F   $��12(�6[   $��	10,40,0,0q�6i   ��6(   �� *channelname+6i   5H      5I      5J      5N      (  "System.Windows.Controls.WebBrowser  5O   
   -   5          Name$ wbMain��5O      $��Bottom=�6'   $��65��6B   $��Disabled=�6N   $��0,0,0,-5q�6�   �� 5P   
   -   5         ��Name$ labelOption��5P      $��
Options : ��6%   $
��Left=�6:   $��720,460,0,0q�6U   $	��Top=�6j   $	��100��6�   $��15(�6�   $��31��6�   �� 5Q   
   -   5         ��Name$ themeSwitch��5Q      $��
Dark Theme��6(   $
��Left=�6=   $��727,496,0,0q�6X   $	��Top=�6m   $��12(�6�   6�   �� 5R   
   -	   5        	 ��Name$	 CheckUpdates_Button��5R      $��Check For Updates��6.   $
��Left=�6J   $��727,559,0,0q�6e   $	��Top=�6z   $	��123��6�   
 J� RenderTransformOrigin$
 0.48,1.2&�6�   �� 5S   
   -
   5        $ checkBox_Loop��5S      $��
Loop music��6*   $
��Left=�6?   $��727,526,0,0q�6Z   $	��Top=�6o   6�   5U      5Z      