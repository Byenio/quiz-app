   M S B A M L   `   `   `  ����I  EQuizApp.Solver, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:QuizApp.Solver.ViewsQuizApp.Solver.Views  5      #    QuizApp.Solver.Views.QuizView   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:QuizApp.Solver.Views     5        N� Title$  QuizView��5	      .��5
      � .+�5   
   �� -   5         ��Name$ QuestionListView��5      ��6-   �� *	Questions+��5      �� 5      .R�5      �� $��10q�6%   .+�5      �� $��18(�5      $
��Bold"�5      $
��Wrap=�5      $��0,0,0,10q�5      $	��750��5      ��5   (   �� *Text+5      �� 5      ��6+   �� *	Answers+��5   "   �� 5   &   .R�5   *   �� $��16(�5   '   $
��10,5q�5   '   $	��750��5   '   ��5   3   �� *Text+ d� 	IsChecked 5   '   �� *
IsSelected+ �� Mode$ TwoWay=�{�5   '   �� *DataContext.IsQuizStarted+ �� RelativeSource ��  �� AncestorType Page��5    .   �� 5!   2    �� 
TargetType" ��68   .�5"   6   ��  �� Property � �� �� Value
 �   �6S   	 �� Triggers	 5#   6   �� 5$   :   
 �� Binding
 6F   �� *State+ �� Value Correct6`   .a�5%   >   ��  � ��
 � � �6[   5&   ;   �� 5'   :   
 6F   �� *State+	 Wrong6`   .a�5(   >   ��  � ��
 �  ��6[   5)   ;   5+   3   5.   +   5/   '   51      52      53      ��56      �� 57      " ��6   .�58      ��  � ��$ Stretch=�6G   59      5;      5=      5>      