   M S B A M L   `   `   `  ����J  FWPF Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WPF_ApplicationWPF_Application  5   	   !    WPF_Application.BoiteDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WPF_Application     5   	     � Title$  BoiteDialog��5   	   $��306.11��6   $��550.4��6-   .��5	      � $��15q�6    � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ lblQuestion��5      $��1��6%   $A��;Choisissez un numéro de filtre parmi la liste ci-dessous :��65   �� 5   
   -   5        $��	txtAnswer��5      $��1��6#   $��1��63   $	��250��6@   6Q   � 5   
   $��2��6   $��2��6!   $��2��65   $��Right=�6G   $��0,184.2,0.2,-169.4q�6c   .+�5      �� -   5        $��btnDialogOk��5   &    �� 	IsDefault . $��60��69   $��0,0,10,0q�6G   .��6s   _Ok6x   �� 5       �� IsCancel . $��60��6%   .��63   	_Cancel6<   5      �� 5   
   $��2��6   $
��Left=�6(   $��0,10.2,0,-105.4q�6C   $��2��6\   $
��Wrap=�6i   $	��Top=�6}   $	��132��6�   $	��338��6�   �� 6�   $�1 --> Identité��6�   �� 6�   �� 6�   $�2 --> Détection��6�   �� 6�   $� des contours��6�   �� 6  $� n°1��6  �� 6'  �� 63  $�3 --> Détection��67  �� 6S  $� des contours��6W  �� 6n  $� n°2��6r  �� 6�  �� 6�  $�4 --> Détection��6�  �� 6�  $� des contours��6�  �� 6�  $� n°3��6�  �� 6�  �� 6�  $�5 --> ��6�  �� 6�  $�Netteté��6   �� 6  �� 6  $�6 --> ��6!  �� 64  $
�Flou��68  �� 6F  �� 6R  $�7 --> ��6V  �� 6i  $�Flou Gaussien 3x3��6m  �� 6�  �� 6�  $�8 --> ��6�  �� 6�  $�Flou Gaussien 5x5��6�  �� 6�  �� 6�  6�  5      5      