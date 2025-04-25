using QuizApp.Models;

namespace QuizApp.Generator.Services.Interfaces
{
    public interface IFileService
    {
        void SaveQuiz(Quiz quiz, string filePath);
        Quiz LoadQuiz(string filePath);
    }
}