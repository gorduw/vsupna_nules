using System;
using System.IO;
using System.Windows;
using TemplateEngine.Docx;
using vstupna.Models;

namespace vstupna.Services
{
    public static class DocumentGeneratorService
    {
        public static void GenerateDocumentFromStudent(StudentRecord student)
        {
            // Зчитуємо шляхи з DataStore (SelectedTemplatePath і OutputFolder мають бути встановлені користувачем)
            string templatePath = DataStore.SelectedTemplatePath;
            string outputFolder = DataStore.OutputFolder;

            if (string.IsNullOrWhiteSpace(templatePath) || string.IsNullOrWhiteSpace(outputFolder))
            {
                MessageBox.Show("Шляхи до шаблону або вихідних документів не встановлено.");
                return;
            }

            if (!File.Exists(templatePath))
            {
                MessageBox.Show("Не знайдено шаблон: " + templatePath);
                return;
            }

            // Формування імені вихідного файлу:
            // Отримуємо ApplicantName, відкидаємо дату народження (якщо вона в кінці) і замінюємо пробіли на підкреслення
            string applicantName = student.ApplicantName ?? "Unknown";
            int lastSpaceIndex = applicantName.LastIndexOf(' ');
            if (lastSpaceIndex > 0)
            {
                applicantName = applicantName.Substring(0, lastSpaceIndex);
            }
            string formattedName = applicantName.Replace(" ", "_");

            // Отримуємо ім'я шаблону (без розширення)
            string templateName = Path.GetFileNameWithoutExtension(templatePath);

            // Формуємо ім'я файлу: ApplicationId_ApplicantName_TemplateName.docx
            string outputFileName = $"{student.ApplicationId}_{formattedName}_{templateName}.docx";
            string outputPath = Path.Combine(outputFolder, outputFileName);

            // Переконуємося, що директорія для вихідного файлу існує
            string outputDir = Path.GetDirectoryName(outputPath) ?? "";
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            try
            {
                // Створюємо набір даних для заповнення шаблону
                var valuesToFill = TemplateContentBuilder.BuildDynamicContent(student, templatePath);

                // Копіюємо шаблон у новий файл, щоб оригінал не змінювався
                File.Copy(templatePath, outputPath, overwrite: true);

                using (var outputDocument = new TemplateProcessor(outputPath).FillContent(valuesToFill))
                {
                    outputDocument.SaveChanges();
                }

                MessageBox.Show("Документ успішно згенеровано за адресою: " + outputPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при генерації документа: " + ex.Message);
            }
        }
    }
}
