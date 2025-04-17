using Microsoft.Win32;
using QuizApp.Model;
using System.IO;
using System.Text.Json;

namespace QuizApp.Generator.Services
{
    public static class FileService
    {
        public static void SaveQuiz(Quiz quiz)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Quiz files (*.quiz)|*.quiz",
                DefaultExt = "quiz"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    var json = JsonSerializer.Serialize(quiz, new JsonSerializerOptions { WriteIndented = true });
                    var encryptedData = EncryptionService.Encrypt(json);
                    File.WriteAllBytes(saveFileDialog.FileName, encryptedData);
                }
                catch (Exception ex)
                {
                    throw new IOException("Failed to save quiz.", ex);
                }
            }
        }

        public static Quiz LoadQuiz()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Quiz files (*.quiz)|*.quiz"
            };

            if (openFileDialog.ShowDialog() == true) { 
                try
                {
                    var encrypted = File.ReadAllBytes(openFileDialog.FileName);
                    var json = EncryptionService.Decrypt(encrypted);
                    return JsonSerializer.Deserialize<Quiz>(json);
                }
                catch (Exception ex)
                {
                    throw new IOException("Failed to load quiz.", ex);
                }
            }

            return null;
        }
    }
}
