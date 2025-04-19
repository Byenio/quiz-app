using QuizApp.Model;
using System.IO;
using System.Text.Json;

namespace QuizApp.Generator.Services
{
    public static class FileService
    {
        public static void SaveQuiz(Quiz quiz, string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));

            try
            {
                var json = JsonSerializer.Serialize(quiz, new JsonSerializerOptions { WriteIndented = true });
                var encryptedData = EncryptionService.Encrypt(json);
                File.WriteAllBytes(filePath, encryptedData);
            }
            catch (JsonException ex)
            {
                throw new IOException("Failed to serialize quiz data.", ex);
            }
            catch (IOException ex)
            {
                throw new IOException("Failed to write quiz file.", ex);
            }
        }

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