   M S B A M L   `   `   `  ����L  HQuizApp.Generator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:QuizApp.GeneratorQuizApp.Generator  5   	   "    QuizApp.Generator.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:QuizApp.Generator     5   	     � Title$  Quiz Generator��5   	   $	��620��6    $
��1020��6-   ���#0C0C0C���#FAF9F6 � Icon$ media/cogs.ico��5	   3    � 	Resources 5
       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ Styles.xaml?�6%   %    5      .��5      � $��10q�6    � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $��7* �6   .+�5   
   � -   5         �Name$ QuizInfoGrid��5      $��0��6%   $��0, 120q�65    � RowDefinitions 5      �� 5      $��2* �6    �� 5      $��4* �6    �� 5      $��2* �6    �� 5      $��1* �6    .+�5       �� $��
Quiz name:��6   $��0��6*   �� 5!      -   5         ��Name$ QuizName��5!      $��0��5"      $��0, 30, 0, 15q�5#      	 �� 	MaxLength$	 32��5%      $��Center=�5&      ��5$      �� *
QuizName+
 �� UpdateSourceTrigger$
 PropertyChanged=�5&      �� 5(      $��Quiz description:��6   $��1��61   �� 5)      -   5        $ QuizDescription��5)      $��1��5*      $��0, 40, 0, 50q�5+      $��Disabled=�5-       �� TextWrapping$
 Wrap=�5.      $		 128��5/      ��5,      �� *QuizDescription+$
 PropertyChanged=�5/      � 51      -   5        $ FileServiceGrid��51      $��2��6,    52      �� 53      $��* �6'   �� 54      $��* �6'   .+�57      �� -   5         ��Name$ SaveFile��57      $
��Save��6+   $��Center=�6:   $��0��6W   $��0��6g   $��0, 25, 0, 25q�58      $	��100��59      $��16(�5;      $
��Bold"�5<      �� 5>      -   5        $ LoadFile��5>      $
��Load��6+   $��Center=�6:   $��1��6W   $��0��6g   $��0, 25, 0, 25q�5?      $	��100��5@      $��16(�5B      $
��Bold"�5C      5D      �� 5F      -   5        $ ClearButton��5F      $��	Clear All��6*   $��Center=�6>   $��3��6[   $	��250��5G      $��16(�5I      $
��Bold"�5J      5K       � 5M   
   -   5          �Name$ ContentGrid��5M      $��1��6%     � NavigationUIVisibility$ Hidden=�65   5N      5O      