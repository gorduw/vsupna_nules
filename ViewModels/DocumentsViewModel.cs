using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using vstupna.Commands;
using vstupna.Models;
using vstupna.Services;

namespace vstupna.ViewModels
{
    public class DocumentsViewModel : INotifyPropertyChanged
    {
        // Колекція документів або полів
        public ObservableCollection<DocumentField> DocumentFields { get; set; }

        // Команди для генерації, завантаження довідкових даних, вибору папок
        public ICommand GenerateDocumentsCommand { get; }
        public ICommand LoadReferencesCommand { get; }
        public ICommand SelectTemplateFolderCommand { get; }
        public ICommand SelectOutputFolderCommand { get; }

        // Для прикладу – обраний студент
        private StudentRecord? _currentStudent;
        public StudentRecord? CurrentStudent
        {
            get => _currentStudent;
            set { _currentStudent = value; OnPropertyChanged(); }
        }

        // Властивості для збереження вибраних шляхів
        private string _templateFolder;
        public string TemplateFolder
        {
            get => _templateFolder;
            set { _templateFolder = value; OnPropertyChanged(); }
        }

        private string _outputFolder;
        public string OutputFolder
        {
            get => _outputFolder;
            set { _outputFolder = value; OnPropertyChanged(); }
        }

        public DocumentsViewModel(StudentRecord student)
        {
            CurrentStudent = student;
            DocumentFields = new ObservableCollection<DocumentField>();
            // Заповнюємо DocumentFields на основі даних студента
            InitializeFieldsFromStudent();

            GenerateDocumentsCommand = new RelayCommand(_ => ExecuteGenerateDocuments());
            LoadReferencesCommand = new RelayCommand(_ => ExecuteLoadReferences());

            SelectTemplateFolderCommand = new RelayCommand(_ => SelectTemplateFolder());
            SelectOutputFolderCommand = new RelayCommand(_ => SelectOutputFolder());

            // За замовчуванням можна встановити порожні значення або попередньо задані шляхи
            TemplateFolder = ""; // користувач повинен обрати папку
            OutputFolder = "";
        }

        private void InitializeFieldsFromStudent()
        {
            DocumentFields.Clear();
            if (CurrentStudent == null)
                return;

            foreach (var prop in typeof(StudentRecord).GetProperties())
            {
                var rawValue = prop.GetValue(CurrentStudent);
                string stringValue = rawValue is bool boolVal ? (boolVal ? "Так" : "Ні") : rawValue?.ToString() ?? "";
                DocumentFields.Add(new DocumentField { FieldName = prop.Name, Value = stringValue });
            }
        }

        private void ExecuteGenerateDocuments()
        {
            // Перевіряємо, чи встановлено шляхи
            if (string.IsNullOrWhiteSpace(TemplateFolder) || string.IsNullOrWhiteSpace(OutputFolder))
            {
                System.Windows.MessageBox.Show("Будь ласка, виберіть папки для шаблонів та збереження документів.");
                return;
            }

            // Формуємо повний шлях до шаблону
            // Припустимо, що назва шаблону залишається "Template.docx"
            string templatePath = System.IO.Path.Combine(TemplateFolder, "Template.docx");

            // Формуємо повний шлях до вихідного файлу, можна додати унікальний ідентифікатор
            string outputPath = System.IO.Path.Combine(OutputFolder, "StudentDocument.docx");

            if (CurrentStudent != null)
            {
                DocumentGeneratorService.GenerateDocumentFromStudent(CurrentStudent);
            }
        }

        private void ExecuteLoadReferences()
        {
            var guarantors = ReferenceDataService.LoadGuarantors("path/to/guarantors.csv");
            // Реалізуйте логіку завантаження довідкових даних
        }

        // Вибір папки для шаблонів
        private void SelectTemplateFolder()
        {
            var dialog = new OpenFolderDialog();
            dialog.Title = "Оберіть папку з шаблонами";
            if (dialog.ShowDialog() == true)
            {
                TemplateFolder = dialog.FolderName;
            }
        }

        // Вибір папки для вихідних документів
        private void SelectOutputFolder()
        {
            var dialog = new OpenFolderDialog();
            dialog.Title = "Оберіть папку для збереження згенерованих документів";
            if (dialog.ShowDialog() == true)
            {
                OutputFolder = dialog.FolderName;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
