   M S B A M L   `   `   `  ����I  EQuizApp.Solver, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:QuizApp.SolverQuizApp.Solver  5   	   ;"clr-namespace:QuizApp.Solver.ViewsQuizApp.Solver.Views  64       QuizApp.Solver.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:QuizApp.Solver     5   	   5local1"clr-namespace:QuizApp.Solver.Views     64     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5	       �� MergedDictionaries �� Source�� 5
   
    5      �� 5      $ Styles.xaml?�6%   %    5      .��5      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��5* �6   �� 5      $��1* �6   .+�5   
   �� -   5         ��Name$ txtTitle��5      $��0��6&   $��Quiz Application��63   $��24(�6K   $��Center=�6Y   $��Center=�6v   � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $��1* �6#   �� 5      $��1* �6#   �� 5      $��1* �6#   .+�5       �� -   5         ��Name$ btnFileInput��5       $��Wczytaj quiz��6+   $	��100��6B   $��0��6N   ��6^   �� *LoadQuizCommand+�� 5!      -   5        $ btnStartQuiz��5!      $��Rozpocznij quiz��6+   $	��100��6E   $��1��6Q   ��6a   �� *StartQuizCommand+�� 5"      -   5        $ 
btnEndQuiz��5"      $��Zakończ quiz��6)   $	��100��6@   $��2��6L   ��6\   �� *CheckQuizCommand+5#       � 5$   
   -   5          �Name$ 	QuizFrame��5$      $��2��6#   	  � NavigationUIVisibility$	 Hidden=�60   �� 5%   
   $��4��6   $��24(�6E   $
��Bold"�6S   
���  ��$��Center=�6z   $��10q�6�   ��6!   �� *ElapsedTimeDisplay+6�   �� 5&   
   $��4��6   $��24(�6?   $
��Bold"�6M   
��� d �$��Right=�6v   $��10q�6�   ��6!   �� *ScoreDisplay+6�   5'      5(      