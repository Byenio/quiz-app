   M S B A M L   `   `   `  ����L  HQuizApp.Generator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:QuizApp.Generator.ViewsQuizApp.Generator.Views  5      *    $QuizApp.Generator.Views.QuestionList   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:QuizApp.Generator.Views     5        N� Title$  QuestionList��5	      .��5
      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Add Question��6   $��0��6(   $��Right=�65   $��	0,0,10,10q�6Q   $	��120��5      $��14(�6   $
��Bold"�6+   ��5      �� *AddQuestionCommand+�� 5   
   $��1��6   $
��Auto=�6$   $��Disabled=�6G   .��5      �� -   5         ��Name$ QuestionListView��5      ��61   �� *	Questions+��5      �� 5      .R�5      � $��5q�6    � ColumnDefinitions 5      �� 5   "   $��* �63   �� 5   "   $
��Auto �63   .+�5      �� 
�������$��1q�68    �� Padding$ 10q�6L   $��0��6Y   ._�5   "   �� .+�5   &   �� $��16(�6F   $��SemiBold"�6T   $
��Wrap=�6j   ��60   �� *Text+6j   �� 5    &   $��12(�6d   
���������60   �� *Points+ �� StringFormat$ Points: {0}��6r   5!   #   5"      �� 5#      $��Delete��6%   $��1��66   $��5,0,0,0q�6F   $��60��6W   ��5$   %   �� *#!DataContext.DeleteQuestionCommand+ �� RelativeSource ��  �� AncestorType ListView��5%   %   �� 5&      5'      ��5)      �� 5*       �� 
TargetType" ��6   .�5+      �� 	 �� Property	 � ��
 �� Value$
 Stretch=�6G   -   5        5-      5/      50      51      52      