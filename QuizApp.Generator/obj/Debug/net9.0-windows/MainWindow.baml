   M S B A M L   `   `   `  ����L  HQuizApp.Generator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:QuizApp.GeneratorQuizApp.Generator  5   	   "    QuizApp.Generator.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:QuizApp.Generator     5   	     � Title$  Quiz Generator��5   	   $	��620��6    $
��1020��6-   .��5	      � $��10q�6    � ColumnDefinitions 5
   
   �� 5      $��3* �6   �� 5      $��7* �6   .+�5   
   � -   5         �Name$ QuizInfoGrid��5      $��0��6%   $��0, 120q�65    � RowDefinitions 5      �� 5      $��2* �6    �� 5      $��4* �6    �� 5      $��2* �6    .+�5      �� $��
Quiz name:��6   $��16(�6*   $
��Bold"�68   $��0��6J   �� 5      -   5         ��Name$ QuizName��5      $��0��5      $��0, 30, 0, 15q�5      $��16(�5      $��SemiBold"�5       �� 	MaxLength$ 32��5      ��5      �� *
QuizName+ �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5      $��Quiz description:��6   $��16(�61   $
��Bold"�6?   $��1��6Q   �� 5       -   5        $ QuizDescription��5       $��1��5!      $��0, 30, 0, 60q�5"      $��16(�5$      $��SemiBold"�5%      $��Disabled=�5&       �� TextWrapping$
 Wrap=�5'      $	 128��5(      ��5#      �� *QuizDescription+$ PropertyChanged=�5(      � 5*      -   5        $ FileServiceGrid��5*      $��2��6,    5+      �� 5,      $��* �6'   �� 5-      $��* �6'   .+�50      �� -   5         ��Name$ SaveFile��50      $
��Save��6+   $��Center=�6:   $��0��6W   $��0, 25, 0, 25q�51      $	��100��52      $��16(�54      $
��Bold"�55      �� 57      -   5        $ LoadFile��57      $
��Load��6+   $��Center=�6:   $��1��6W   $��0, 25, 0, 25q�58      $	��100��59      $��16(�5;      $
��Bold"�5<      5=      5>       � 5@   
   -   5        	  �Name$	 ContentGrid��5@      $��1��6%   
  � NavigationUIVisibility$
 Hidden=�65   5A      5B      