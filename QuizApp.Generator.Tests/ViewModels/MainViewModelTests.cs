using Moq;
using QuizApp.Generator.Services.Interfaces;
using QuizApp.Generator.ViewModels;
using QuizApp.Models;
using Xunit;

namespace QuizApp.Generator.Tests.ViewModels;

public class MainViewModelTests
{
    [Fact]
    public void SaveQuiz_ShowsError_WhenQuizNameIsEmpty()
    {
        var dialogMock = new Mock<IDialogService>();
        var fileMock = new Mock<IFileService>();
        var vm = new MainViewModel(dialogMock.Object, fileMock.Object)
        {
            QuizName = "",
            QuizDescription = "Valid description"
        };

        vm.SaveQuizCommand.Execute(null);

        dialogMock.Verify(d => d.ShowError("Please enter a quiz name.", "Error"), Times.Once);
        fileMock.Verify(f => f.SaveQuiz(It.IsAny<Quiz>(), It.IsAny<string>()), Times.Never);
    }
    
    [Fact]
    public void SaveQuiz_ShowsError_WhenQuizDescriptionIsEmpty()
    {
        var dialogMock = new Mock<IDialogService>();
        var fileMock = new Mock<IFileService>();
        var vm = new MainViewModel(dialogMock.Object, fileMock.Object)
        {
            QuizName = "Valid Name",
            QuizDescription = ""
        };

        vm.SaveQuizCommand.Execute(null);

        dialogMock.Verify(d => d.ShowError("Please enter a quiz description.", "Error"), Times.Once);
    }

    [Fact]
    public void SaveQuiz_ShowsError_WhenNoFileSelected()
    {
        var dialogMock = new Mock<IDialogService>();
        dialogMock.Setup(d => d.ShowSaveFileDialog(It.IsAny<string>(), It.IsAny<string>())).Returns(string.Empty);

        var fileMock = new Mock<IFileService>();
        var vm = new MainViewModel(dialogMock.Object, fileMock.Object)
        {
            QuizName = "Valid Name",
            QuizDescription = "Valid Description"
        };

        vm.SaveQuizCommand.Execute(null);

        dialogMock.Verify(d => d.ShowError("No file selected.", "Error"), Times.Once);
    }

    [Fact]
    public void SaveQuiz_CallsFileService_WhenAllDataIsValid()
    {
        var dialogMock = new Mock<IDialogService>();
        dialogMock.Setup(d => d.ShowSaveFileDialog(It.IsAny<string>(), It.IsAny<string>())).Returns("quiz.quiz");

        var fileMock = new Mock<IFileService>();
        var vm = new MainViewModel(dialogMock.Object, fileMock.Object)
        {
            QuizName = "Valid Name",
            QuizDescription = "Valid Description"
        };

        vm.SaveQuizCommand.Execute(null);

        fileMock.Verify(f => f.SaveQuiz(It.IsAny<Quiz>(), "quiz.quiz"), Times.Once);
    }
    
    [Fact]
    public void LoadQuiz_ShowsError_WhenNoFileSelected()
    {
        var dialogMock = new Mock<IDialogService>();
        dialogMock.Setup(d => d.ShowOpenFileDialog(It.IsAny<string>(), It.IsAny<string>())).Returns("");

        var fileMock = new Mock<IFileService>();
        var vm = new MainViewModel(dialogMock.Object, fileMock.Object);

        vm.LoadQuizCommand.Execute(null);

        dialogMock.Verify(d => d.ShowError("No file selected.", "Error"), Times.Once);
    }

    [Fact]
    public void LoadQuiz_ShowsError_WhenFileServiceThrows()
    {
        var dialogMock = new Mock<IDialogService>();
        dialogMock.Setup(d => d.ShowOpenFileDialog(It.IsAny<string>(), It.IsAny<string>())).Returns("quiz.quiz");

        var fileMock = new Mock<IFileService>();
        fileMock.Setup(f => f.LoadQuiz(It.IsAny<string>())).Throws(new IOException("Boom"));

        var vm = new MainViewModel(dialogMock.Object, fileMock.Object);

        vm.LoadQuizCommand.Execute(null);

        dialogMock.Verify(d => d.ShowError("Error loading quiz: Boom", "Error"), Times.Once);
    }
}