using QuizApp.Models;
using System.IO;
using System.Text.Json;

namespace QuizApp.Solver.Services
{
    public static class FileService
    {

        public static Quiz LoadQuiz(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));

            try
            {
                var encrypted = File.ReadAllBytes(filePath);
                var json = EncryptionService.Decrypt(encrypted);
                var quiz = JsonSerializer.Deserialize<Quiz>(json);
                if (quiz == null)
                    throw new IOException("Failed to deserialize quiz data.");
                return quiz;
            }
            catch (JsonException ex)
            {
                throw new IOException("Failed to deserialize quiz data.", ex);
            }
            catch (IOException ex)
            {
                throw new IOException("Failed to read quiz file.", ex);
            }
        }
    }
}