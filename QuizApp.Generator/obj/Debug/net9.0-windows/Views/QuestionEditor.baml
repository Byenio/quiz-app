   M S B A M L   `   `   `  ����L  HQuizApp.Generator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:QuizApp.Generator.ViewsQuizApp.Generator.Views  5      ,    &QuizApp.Generator.Views.QuestionEditor   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:QuizApp.Generator.Views     5        N� Title$  QuestionEditor��5	       N� 
Background �#0C0C0C N� 
Foreground �#FAF9F6 � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Styles.xaml?�6%   %    5      .��5      � $��40, 0, 20, 0q�6    � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��5* �6   �� 5      $��2* �6   �� 5      $��1* �6   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��4* �6   .+�5    
   �� -   5         ��Name$ QuestionNumber��5       $��0��6i   $��20(�5!      $��SemiBold"�6"   $��Center=�68   $��Center=�6S   $
��Wrap=�5"      ��5    ,   �� *QuestionNumber+ �� StringFormat$ Question {0}��5"      �� 5$   
   -   5        	 ��Name$	 QuestionTextBox��5$      $��1��6+   $��10, 10, 30, 10q�68   $��16(�5%      $��SemiBold"�6    
 �� TextWrapping$

 Wrap=�66    �� 	MaxLength$	 256��6J   ��5&      �� *QuestionText+ �� UpdateSourceTrigger$ PropertyChanged=�� 5(   
   -   5         �Name$ QuestionPointsGrid��5(      $��2��6+    � ColumnDefinitions 5)      �� 5*      $��2* �6#   �� 5+      $��8* �6#   .+�5.      �� $��Question points:��6   $��0��60   $��10, 0, 0, 0q�6@   $��Center=�5/      $��12(�63   $��SemiBold"�6A   �� 50      -   5        $	 QuestionPoints��50      $��1��6.   $��0, 10, 400, 10q�6>   $��Center=�51      ��52      �� *QuestionPoints+$ PropertyChanged=�53      � 55   
   -   5        $ AnswerTitleBar��55      $��3��6'    56      �� 57      $��1* �6#   �� 58      $��9* �6#   .+�5:      �� $��Correct��6   $��0��6'   
���iii�$��Bottom=�6L   $��Center=�6g   �� 5;      $��Answer��6   $��1��6&   
���iii�$��10, 0, 0, 0q�6K   $��Bottom=�6`   5<      � 5>   
   -   5        $ AnswerAGrid��5>      $��4��6$    5?      �� 5@      $��1* �6#   �� 5A      $��9* �6#   .+�5C      �� -   5         ��Name$ AnswerAIsCorrect��5C      $��Center=�61   $��Center=�6N    d� 	IsChecked 5D      �� *Answers[0].IsCorrect+�� 5E      -   5        $	 AnswerATextBox��5E      $��1��6.   $��Center=�6>   $��10, 10, 30, 10q�5F      $��16(�6.   $��SemiBold"�6<   $

 Wrap=�6R   $ 48��6f   ��5G      �� *Answers[0].Text+$ PropertyChanged=�5H      � 5J   
   -	   5        $ AnswerBGrid��5J      $��5��6$    5K      �� 5L      $��1* �6#   �� 5M      $��9* �6#   .+�5O      �� -
   5        $ AnswerBIsCorrect��5O      $��Center=�61   $��Center=�6N    5P      �� *Answers[1].IsCorrect+�� 5Q      -   5        $	 AnswerBTextBox��5Q      $��1��6.   $��Center=�6>   $��10, 10, 30, 10q�5R      $��16(�6.   $��SemiBold"�6<   $

 Wrap=�6R   $ 48��6f   ��5S      �� *Answers[1].Text+$ PropertyChanged=�5T      � 5V   
   -   5        $ AnswerCGrid��5V      $��6��6$    5W      �� 5X      $��1* �6#   �� 5Y      $��9* �6#   .+�5[      �� -   5        $ AnswerCIsCorrect��5[      $��Center=�61   $��Center=�6N    5\      �� *Answers[2].IsCorrect+�� 5]      -   5        $	 AnswerCTextBox��5]      $��1��6.   $��Center=�6>   $��10, 10, 30, 10q�5^      $��16(�6.   $��SemiBold"�6<   $

 Wrap=�6R   $ 48��6f   ��5_      �� *Answers[2].Text+$ PropertyChanged=�5`      � 5b   
   -   5        $ AnswerDGrid��5b      $��7��6$    5c      �� 5d      $��1* �6#   �� 5e      $��9* �6#   .+�5g      �� -   5        $ AnswerDIsCorrect��5g      $��Center=�61   $��Center=�6N    5h      �� *Answers[3].IsCorrect+�� 5i      -   5        $	 AnswerDTextBox��5i      $��1��6.   $��Center=�6>   $��10, 10, 30, 10q�5j      $��16(�6.   $��SemiBold"�6<   $

 Wrap=�6R   $ 48��6f   ��5k      �� *Answers[3].Text+$ PropertyChanged=�5l      � 5n   
   -   5        $ AnswerButtonGrid��5n      $��8��6)    5o      �� 5p      $��1* �6#   �� 5q      $��1* �6#   .+�5s      �� -   5         ��Name$ SaveQuestion��5s      $
��Save��6+   $��Right=�6:   $��0��6V   $��0, 40, 20, 30q�5t      $	��140��6,   $��16(�68   $
��Bold"�6F   ��5u      �� *SaveQuestionCommand+�� 5v      -   5        $ CancelQuestion��5v      $��Cancel��6-   $
��Left=�6>   $��1��6Y   $��20, 40, 0, 30q�5w      $	��140��6,   $��16(�68   $
��Bold"�6F   ��5x      �� *CancelQuestionCommand+5y      5z      5{      