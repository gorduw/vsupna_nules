using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Reflection;
using TemplateEngine.Docx;
using vstupna.Models;

namespace vstupna.Services
{
    public static class TemplateContentBuilder
    {
        public static HashSet<string> GetTemplateFieldNames(string templatePath)
        {
            var fieldNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            using (WordprocessingDocument doc = WordprocessingDocument.Open(templatePath, false))
            {
                var sdtElements = doc.MainDocumentPart.Document.Descendants<SdtElement>();
                foreach (var sdt in sdtElements)
                {
                    var tag = sdt.Descendants<Tag>().FirstOrDefault();
                    if (tag != null && !string.IsNullOrWhiteSpace(tag.Val))
                    {
                        fieldNames.Add(tag.Val);
                    }
                }
            }
            return fieldNames;
        }
        public static Content BuildDynamicContent(StudentRecord student, string templatePath)
        {
            // Отримуємо список тегів (імен полів) з шаблону
            var allowedFields = GetTemplateFieldNames(templatePath);
            var fieldContents = new List<FieldContent>();

            // Перебираємо всі публічні властивості моделі
            foreach (PropertyInfo prop in typeof(StudentRecord).GetProperties())
            {
                string fieldName = prop.Name;
                // Додаємо лише, якщо ім'я властивості присутнє серед тегів шаблону
                if (allowedFields.Contains(fieldName))
                {
                    string value = prop.GetValue(student)?.ToString() ?? "";
                    fieldContents.Add(new FieldContent(fieldName, value));
                }
            }

            var content = new Content();
            foreach (var fieldContent in fieldContents)
            {
                content.Fields.Add(fieldContent);
            }

            return content;
        }
    }
}
