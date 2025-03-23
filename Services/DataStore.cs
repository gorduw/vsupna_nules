using System.Collections.ObjectModel;
using vstupna.Models;

namespace vstupna.Services
{
    public static class DataStore
    {
        public static ObservableCollection<StudentRecord> Students { get; set; } = new ObservableCollection<StudentRecord>();
        public static StudentRecord? SelectedStudent { get; set; }

        // Шляхи до папок
        public static string TemplateFolder { get; set; } = "";
        public static string OutputFolder { get; set; } = "";

        // Шлях до обраного шаблону (повний шлях до файлу)
        public static string SelectedTemplatePath { get; set; } = "";

        public static bool IsDataLoaded => Students != null && Students.Count > 0;
    }
}
