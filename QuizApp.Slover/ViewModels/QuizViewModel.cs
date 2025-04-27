using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using QuizApp.Models;
using QuizApp.Slover.Helpers;

namespace QuizApp.Slover.ViewModels;
public class QuizViewModel : BaseViewModel
{
    private Quiz _quiz;

    private ObservableCollection<Question> _questions;

    private readonly NavigationService _navigationService;



    public QuizViewModel(Quiz loadedQuiz, NavigationService navigationService)
    {
        _quiz = loadedQuiz;
        _navigationService = navigationService;
        _questions = new ObservableCollection<Question>(_quiz.Questions);

    }

    public ObservableCollection<Question> Questions
    {
        get => _questions;
        set
        {
            _questions = value;
            OnPropertyChanged(nameof(Questions));
        }
    }

    private bool _isQuizStarted;
    public bool IsQuizStarted
    {
        get => _isQuizStarted;
        set
        {
            _isQuizStarted = value;
            OnPropertyChanged(nameof(IsQuizStarted));
        }
    }

    public int CheckQuiz()
    {
        int score = 0;

        foreach (var question in Questions)
        {
            bool allCorrect = true;

            foreach (var answer in question.Answers)
            {
                if (answer.IsCorrect)
                {
                    answer.State = AnswerState.Correct;
                }
                else if (!answer.IsCorrect && answer.IsSelected)
                {
                    answer.State = AnswerState.Wrong;
                    allCorrect = false;
                }
                else
                {
                    answer.State = AnswerState.None;
                }
            }

            bool allCorrectlySelected = question.Answers.All(a =>
                (a.IsCorrect && a.IsSelected) || (!a.IsCorrect && !a.IsSelected));

            if (allCorrectlySelected)
                score+=question.Points;
        }
        return score;
    }



}

