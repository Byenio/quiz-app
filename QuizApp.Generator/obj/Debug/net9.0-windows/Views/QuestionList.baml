   M S B A M L   `   `   `  ����L  HQuizApp.Generator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:QuizApp.Generator.ViewsQuizApp.Generator.Views  5      *    $QuizApp.Generator.Views.QuestionList   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:QuizApp.Generator.Views     5        N� Title$  QuestionList��5	       N� 
Background �#0C0C0C N� 
Foreground �#FAF9F6 � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Styles.xaml?�6%   %    5      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Add Question��6   $��0��6(   $��Right=�65   $��	0,0,10,10q�6Q   $	��120��5      $��14(�6   $
��Bold"�6+   ��5      �� *AddQuestionCommand+�� 5   
   -   5         ��Name$ QuestionListView��5      $��1��5      ��5       �� *	Questions+��5"      �� 5#      .R�5$      � $��5q�6    � ColumnDefinitions 5%      �� 5&      $��* �6/   �� 5'      $
��Auto �6/   .+�5)      �� 
�������$��1q�64   	 �� Padding$	 10q�6H   $��0��6U   ._�5*      �� .+�5+   "   �� $��16(�6B   $��SemiBold"�6P   $��NoWrap=�6f   $	��540��6|   $
��Left=�6�   ��6,   �� *Text+6�   �� 5,   "   $��12(�6`   
���������6,   �� *Points+
 �� StringFormat$
 Points: {0}��6n   5-      5.      �� 5/      $��Delete��6!   $��1��62   $��5,0,0,0q�6B   $��60��6S   ��50   !   �� *#!DataContext.DeleteQuestionCommand+ �� RelativeSource ��  �� AncestorType ListView��51   !   �� 52      53      ��55      �� 56       �� 
TargetType" ��6   .�57      ��  �� Property � �� �� Value$ Stretch=�6C   -   5        59      5;      5=      5>      